using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public static class NGramUtil
    {
        /// <summary>
        /// Get NGram by the given terms.
        /// </summary>
        /// <param name="nGramType"></param>
        /// <param name="terms"></param>
        /// <returns></returns>
        public static String[] splitNGramsByType(Document.NGrams nGramType, String terms)
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

            String[] splitted = terms.Split(delimiterChars);

            HashSet<String> finishedNGrams = new HashSet<string>();

            // iterate through splitted words
            for (int i = 0; i < splitted.Length; i++)
            {
                String nGrams = "";

                // append words that are within current word index + numberWords (-1)
                for (int j = i; i - 1 + numberWords < splitted.Length
                    && j < i + numberWords && j < splitted.Length; j++)
                {
                    nGrams += " " + splitted[j];
                }

                if (nGrams.Trim().Count() > 0)
                {
                    finishedNGrams.Add(nGrams.Trim());
                }
            }

            return finishedNGrams.ToArray();
        }
    }
}
