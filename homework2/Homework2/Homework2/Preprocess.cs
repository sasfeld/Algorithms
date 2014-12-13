using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// A preprocess should be applied on a Document before it is indexed.
    /// </summary>
    public interface Preprocess
    {
        /// <summary>
        /// Apply the preprocess on the given document per reference.
        /// 
        /// This will change the stored sentences.
        /// </summary>
        /// <param name="document"></param>
        void execute(Document document);
    }
}
