using System;
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
        /// Add an extracted document by its filename.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="document"></param>
        public void addDocumentByFileName(String fileName, Document document)
        {
            this.documents.Add(fileName, document);
        }
    }
}
