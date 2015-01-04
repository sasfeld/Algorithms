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
            return NGramUtil.splitNGramsByType(nGramType, sentence);
        }
    }
}
