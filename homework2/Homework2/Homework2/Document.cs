using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// A document is the model for extracted documents such as corpus files.
    /// 
    /// It contains all contained sentences and can build N-Gram indices on those.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Available N-Grams that the document will generate separate indexes for.
        /// </summary>
        public enum NGrams
        {
            UNIGRAM, BIGRAM, TRIGRAM
        }

        protected Dictionary<NGrams, Dictionary<String, HashSet<int>>> index;

        protected List<String> sentences;

        public Document()
        {
            this.initialize();
        }

        protected void initialize()
        {
            this.sentences = new List<String>();

            this.index = new Dictionary<NGrams, Dictionary<string, HashSet<int>>>();

            // add N-Gram dictionaries
            this.index.Add(NGrams.UNIGRAM, new Dictionary<string, HashSet<int>>());
            this.index.Add(NGrams.BIGRAM, new Dictionary<string, HashSet<int>>());
            this.index.Add(NGrams.TRIGRAM, new Dictionary<string, HashSet<int>>());
        }

        /// <summary>
        /// Add a sentence to the document.
        /// </summary>
        /// <param name="sentence"></param>
        public void addSentence(String sentence)
        {
            if (null == sentence)
            {
                throw new ArgumentNullException("Argument 'sentence' must be of type string.");
            }

            this.sentences.Add(sentence);
        }

        public void setSentences(List<String> sentences)
        {
            this.sentences = sentences;
        }

        /// <summary>
        /// Get a list of sentences, where the position is the position of the sentence within the document.
        /// 
        /// Therefore, index positions are references on the index in the returned list.
        /// </summary>
        /// <returns></returns>
        public List<String> getSentences()
        {
            return this.sentences;
        }

        /// <summary>
        /// Get a map of N-Gram mapping to a set of indices. 
        /// 
        /// The index is a reference to a sentence number returned by getSentences().
        /// </summary>
        /// <returns></returns>
        public Dictionary<NGrams, Dictionary<String, HashSet<int>>> getIndex()
        {
            return this.index;
        }
    }
}
