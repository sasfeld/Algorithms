using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework2;

namespace HomeWork1Test
{
    [TestClass]
    public class RemoveStopWordsPreprocessTest
    {

        protected Document getDummyDocument()
        {
            Document doc = new Document();

            doc.addSentence("This is a dummy sentence");

            return doc;
        }

        protected Preprocess givenAPreprocess()
        {
            RemoveStopWordsPreprocess preprocess = new RemoveStopWordsPreprocess();

            return preprocess;
        }

        [TestMethod]
        public void TestRemoveStopWords()
        {
            Preprocess preprocess = this.givenAPreprocess();
            Document doc = this.getDummyDocument();

            this.whenExecuteIscalled(preprocess, doc);

            // then assert
            String firstSentence = doc.getSentences()[0];

            Assert.AreEqual("This dummy sentence", firstSentence);
        }

        protected void whenExecuteIscalled(Preprocess pre, Document document)
        {
            pre.execute(document);
        }
    }
}
