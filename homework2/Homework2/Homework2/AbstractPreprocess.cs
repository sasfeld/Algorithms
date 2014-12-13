using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public abstract class AbstractPreprocess : Preprocess
    {
        protected Preprocess decoratingPreprocess;

        public AbstractPreprocess()
        {
            this.decoratingPreprocess = null;

            this.initialize();
        }

        public AbstractPreprocess(Preprocess decorating)
        {
            this.decoratingPreprocess = decorating;

            this.initialize();
        }

        protected virtual void initialize()
        {

        }

        public virtual void execute(Document document)
        {
            // execute if preprocess was decorated
            if (null != this.decoratingPreprocess)
            {
                this.decoratingPreprocess.execute(document);
            }
        }
    }
}
