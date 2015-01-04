using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// A document collection is a singleton container for extracted documents.
    /// 
    /// Later, N-Gram searches over multiple documents should be triggered here.
    /// </summary>
    public class DocumentCollection
    {
        protected Dictionary<String, Document> documents;
        protected static DocumentCollection instance;
        protected Preprocess decoratedPreprocess;
        protected IndexCreator indexCreator;

        /// <summary>
        /// Get singleton instance.
        /// </summary>
        /// <returns></returns>
        public static DocumentCollection getInstance()
        {
            if (null == instance)
            {
                instance = new DocumentCollection();
            }

            return instance;
        }

        protected DocumentCollection()
        {
            this.initialize();
        }

        protected void initialize()
        {
            this.documents = new Dictionary<String, Document>();

            // initialize preprocess chain
            this.decoratedPreprocess = new LowerCasePreprocess(new RemoveStopWordsPreprocess());

            this.indexCreator = new IndexCreator();
        }

        /// <summary>
        /// Get an document by its filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>null or Document instance</returns>
        public Document getDocumentByFileName(String fileName)
        {
            return this.documents[fileName];
        }

        /// <summary>
        /// Get all collected documents.
        /// </summary>
        /// <returns></returns>
        public Dictionary<String, Document> getAllDocuments()
        {
            return this.documents;
        }

        /// <summary>
        /// Add an extracted document by its filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="document"></param>
        public void addDocumentByFileName(String fileName, Document document)
        {
            this.documents.Add(fileName, document);
        }

        /// <summary>
        /// Apply the preprocesses on each document.
        /// </summary>
        public void applyPreprocesses()
        {
            foreach (Document doc in this.documents.Values)
            {
                this.decoratedPreprocess.execute(doc);
            }
        }

        public void createIndex(Document.NGrams ngramType)
        {
            // iterate over documents
            foreach (Document doc in this.documents.Values)
            {
                SentenceIndex sentenceIndex = doc.getSentenceIndex();

                this.indexCreator.createIndex(doc, ngramType);
            }
        }

        /// <summary>
        /// Search terms by delegating to all documents.
        /// 
        /// Use N-Gram search.
        /// </summary>
        /// <param name="nGrams">The input term sequence which will be split into n-grams.</param>
        /// <returns>Dictionary of key = document name and sentence indices array.</returns>
        public Dictionary<String, long[]> searchTerms(String nGrams)
        {
            Dictionary<String, long[]> searchResults = new Dictionary<String, long[]>();
            int docNumber = 0;

            foreach (Document doc in this.documents.Values)
            {
                long[] indices = doc.searchTerms(nGrams);

                searchResults.Add(doc.getName(), indices);
                docNumber++;
            }

            return searchResults;
        }

        public Dictionary<Document, SortedDictionary<int, HashSet<long>>> searchSimilarSentences(String sentence, long maxDistance)
        {
            // map of document -> (map of levenshtein distance -> sentences indices)
            Dictionary<Document, SortedDictionary<int, HashSet<long>>> searchResults = new Dictionary<Document, SortedDictionary<int, HashSet<long>>>();

            foreach (Document doc in this.documents.Values)
            {
                // map of levenshtein distance -> sentences indices
                SortedDictionary<int, HashSet<long>> documentResults = new SortedDictionary<int, HashSet<long>>();

                // get indices of sentences that have same n-grams
                long[] indices = doc.searchTerms(sentence);
   
                // calculate Levenshtein distance between found sentences and given one
                foreach (long sentenceIndex in indices) 
                {
                    String otherSentence = doc.getSentences()[(int) sentenceIndex];

                    int distance = LevenshteinDistance.compute(sentence, otherSentence);

                    if (distance < maxDistance) {
                        if (!documentResults.ContainsKey(distance)) {
                            documentResults.Add(distance, new HashSet<long>());
                        }

                        documentResults[distance].Add(sentenceIndex);
                    }
                }

                searchResults.Add(doc, documentResults);
            }

            return searchResults;
        }
    }
}
