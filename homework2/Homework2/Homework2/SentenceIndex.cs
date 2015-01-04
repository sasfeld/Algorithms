using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2;

namespace Homework2
{  

    public class SentenceIndex
    {
        protected Dictionary<Document.NGrams, Dictionary<String, HashSet<long>>> indices;

        public SentenceIndex()
        {
            this.initialize();
        }

        protected void initialize()
        {
            this.indices = new Dictionary<Document.NGrams, Dictionary<String, HashSet<long>>>();
        }

        /// <summary>
        /// Get the hash set of indices according to the given nGram type (such as UNIGRAM, BIGRAM, TRIGRAM)
        /// and the ngram(s) themselves.
        /// </summary>
        /// <param name="nGramType"></param>
        /// <param name="nGram"></param>
        /// <returns>null if no matches</returns>
        public HashSet<long> getIndices(Document.NGrams nGramType, String nGram)
        {
            // no entry for ngram type
            if (!this.indices.ContainsKey(nGramType))
            {
                throw new KeyNotFoundException("No key for ngram type " + nGramType);
            }

            // no entry for ngrams (keys)
            if (!this.indices[nGramType].ContainsKey(nGram))
            {
                return null;
            }

            return this.indices[nGramType][nGram];
        }

        public void addIndex(Document.NGrams nGramType, String nGram, long index)
        {
            this.createNGramTypeIfNotExists(nGramType);

            this.createNGramIfNotExists(nGramType, nGram);

            this.indices[nGramType][nGram].Add(index);
        }

        protected void createNGramTypeIfNotExists(Document.NGrams nGramType)
        {
            if (!this.indices.ContainsKey(nGramType))
            {
                this.indices.Add(nGramType, new Dictionary<String, HashSet<long>>());
            }
        }

        protected void createNGramIfNotExists(Document.NGrams nGramType, String nGram)
        {
            if (!this.indices[nGramType].ContainsKey(nGram))
            {
                this.indices[nGramType].Add(nGram, new HashSet<long>());
            }
        }
    }
}
