using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// Strategy for creating NGram indices.
    /// 
    /// This class uses Document instances directly.
    /// </summary>
    public class IndexCreator
    {

        /// <summary>
        /// Create the ngram index.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="ngramType"></param>
        public void createIndex(Document doc, Document.NGrams ngramType)
        {
            SentenceIndex sentenceIndex = doc.getSentenceIndex();

            // iterate over processed sentenences, store the ngrams according to the indicies
            int sentenceNumber = 0;
            foreach (String sentence in doc.getProcessedSentences())
            {
                String[] nGrams = this.splitNGramsByType(ngramType, sentence);

                // store sentence in index
                foreach (String nGram in nGrams)
                {
                    doc.getSentenceIndex().addIndex(ngramType, nGram, sentenceNumber);
                }

                sentenceNumber++;
            }
        }

        protected String[] splitNGramsByType(Document.NGrams nGramType, String sentence)
        {
            // define number of nGrams (words in sequence) that will be taken as index
            int numberWords = 0;
            switch (nGramType)
            {
                case Document.NGrams.UNIGRAM:
                    numberWords = 1;
                    break;
                case Document.NGrams.BIGRAM:
                    numberWords = 2;
                    break;
                case Document.NGrams.TRIGRAM:
                    numberWords = 3;
                    break;
                default:
                    numberWords = 0;
                    break;
            }

            // the following characters will be taken for splitting
            char[] delimiterChars = { ' ', ',', '.', ':', '?', '!', ';', '\t' };

            String[] splitted = sentence.Split(delimiterChars);

            HashSet<String> finishedNGrams = new HashSet<string>();

            // iterate through splitted words
            for (int i = 0; i < splitted.Length; i++)
            {
                String nGrams = "";

                for (int j = i; j < i + numberWords && j < splitted.Length; j++)
                {
                    nGrams += " " + splitted[j];
                }

                finishedNGrams.Add(nGrams);
            }

            return finishedNGrams.ToArray();
        }
    }
}
