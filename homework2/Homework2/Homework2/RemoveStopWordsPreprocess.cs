using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework2
{
    /// <summary>
    /// Preprocess for lower-casing words.
    /// </summary>
    public class RemoveStopWordsPreprocess : AbstractPreprocess
    {
        const String ENGLISH_STOPWORDS_FILE = "../../../data/english_stopwords.txt"; 

        protected List<String> englishStopwords;

        public RemoveStopWordsPreprocess() : base()
        {
        }
    
        public RemoveStopWordsPreprocess(Preprocess decorating) : base(decorating) 
        {

        }
            
        protected override void initialize()
        {
            base.initialize();

            try
            {
                this.englishStopwords = readStopWordsFromFile(ENGLISH_STOPWORDS_FILE);
            }
            catch (Exception e)
            {
                // file could not be read
                Console.WriteLine("RemoveStopWordsPreprocess::initialize(): Could not read stopwords from file: " + ENGLISH_STOPWORDS_FILE);
            }
        }

        protected List<String> readStopWordsFromFile(String filePath)
        {
            List<String> stopWordList = new List<String>();

            String[] rawTxt = System.IO.File.ReadAllLines(filePath);

            // start at third line
            for (int i = 2; i < rawTxt.Count(); i++)
            {
                String line = rawTxt[i].Trim();

                // only add non-empty lines
                if (!("".Equals(line)))
                {
                    stopWordList.Add(line);
                }
            }


            return stopWordList;
        }

        public override void execute(Document document)
        {
            // apply decorating preprocesses first
            base.execute(document);

            // apply own filter
            List<String> preprocessedSentences = new List<String>();

            foreach (String sentence in document.getSentences())
            {
                String processedSentence = this.removeStopWords(sentence);
                processedSentence = this.removeDoubleWhitespaces(processedSentence);

                preprocessedSentences.Add(processedSentence);                                
            }

            document.setSentences(preprocessedSentences);
        }

        protected String removeStopWords(String inputSentence)
        {
            String replaced = inputSentence;

            if (null != this.englishStopwords)
            {
                foreach (String stopWord in this.englishStopwords)
                {
                    String regex = @"\b?\b";
                    // use quoting instead of string concatenation - otherwise the pattern will be backslashed incorrectly for some reason
                    regex = regex.Replace("?", stopWord);

                    // replace matched stopword optionally followed by whitespace by whitespace
                    replaced = Regex.Replace(replaced, regex, "", RegexOptions.IgnoreCase);
                }
            } else {
                 Console.WriteLine("RemoveStopWordsPreprocess::removeStopWords(): no english stop words were set. Will not remove any.");
            }

            return replaced;
        }

        protected String removeDoubleWhitespaces(String processed)
        {
            String replaced = Regex.Replace(processed, @"\s+", " ", RegexOptions.IgnoreCase);           

            return replaced;
        }
    }
}
