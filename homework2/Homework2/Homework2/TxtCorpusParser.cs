using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Homework2
{
    /// <summary>
    /// Extract a txt corpus.
    /// 
    /// The corpus should contain sentences per line. Each line should have the following structure:
    /// 
    /// ...
    /// 23	The entree, like the politicking and gossiping, varies each week.
    /// ...
    ///  
    /// </summary>
    public class TxtCorpusParser : DocumentParser
    {     
        public Document extractDocument(String documentAddress)
        {
            try
            {
                String[] rawContent = this.parseFile(documentAddress);
                List<String> sentences = this.fetchSentences(rawContent);

                Document extractedDocument = this.generateDocument(sentences, documentAddress);

                return extractedDocument;
            }
            catch (Exception e)
            {
                Console.WriteLine("TxtCorpusParser::extractDocument(): File " + documentAddress + " could not be extracted.");

                return null;
            }           
        }

        protected String[] parseFile(String documentAddress)
        {           
            String[] rawTxt = System.IO.File.ReadAllLines(documentAddress);

            return rawTxt;
        }

        protected List<String> fetchSentences(String[] rawContent)
        {
            List<String> preparedLines = new List<String>();

            foreach (String line in rawContent)
            {
                String parsedLine = this.parseLine(line);

                preparedLines.Add(parsedLine);
            }

            return preparedLines;
        }

        protected String parseLine(String extractedLine)
        {
            // pattern: sentenceNumber sentence
            String linePattern = @"([0-9]+)\s+(.*)";

            Regex lineRegex = new Regex(linePattern);

            Match mLine = lineRegex.Match(extractedLine);

            while (mLine.Success)
            {
                // success, only return the sentence, don't care about the sentence number because sentences are ordered in original file
                Group sentenceNumber = mLine.Groups[1];
                Group sentence = mLine.Groups[2];

                return sentence.Value;
            }

            // no success: throw exception
            throw new FormatException("Malformed line: " + extractedLine);
        }

        protected Document generateDocument(List<String> sentences, String documentAddress)
        {
            Document doc = new Document(documentAddress);
            doc.setSentences(sentences);

            return doc;
        }
    }
}
