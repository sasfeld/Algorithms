﻿using System;
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
    }
}