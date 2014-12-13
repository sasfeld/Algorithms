using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// Interface for all document parsers.
    /// 
    /// Document parsers can extract real documents and generate a Document record for it.
    /// </summary>
    public interface DocumentParser
    {
        /// <summary>
        /// Extract a document that can be accessed by the given documentAddress.
        /// </summary>
        /// <returns></returns>
        Document extractDocument(String documentAddress);
    }
}
