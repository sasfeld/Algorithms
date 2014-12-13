using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// Preprocess for lower-casing words.
    /// </summary>
    public class LowerCasePreprocess : AbstractPreprocess
    {
        public LowerCasePreprocess() : base()
        {
        }

        public LowerCasePreprocess(Preprocess decorating)
            : base(decorating) 
        {

        }
        public override void execute(Document document)
        {
            // apply decorating preprocesses first
            base.execute(document);

            // apply own filter
            List<String> preprocessedSentences = new List<String>();

            foreach (String sentence in document.getSentences())
            {
                preprocessedSentences.Add(this.makeWordsLowerCase(sentence));
            }

            document.setSentences(preprocessedSentences);
        }

        protected String makeWordsLowerCase(String inputSentence)
        {
            return inputSentence.ToLower();
        }
    }
}
