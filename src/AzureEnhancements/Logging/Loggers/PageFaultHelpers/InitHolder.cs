using System;
using System.Collections.Generic;
using System.Text;

namespace AzRedisEnhancements.Logging
{
    abstract public class InitHolder
    {
        Action initAction;
        volatile bool inited;
        object lo = new object();

        protected void DefineCreate(Action initAction)
        {
            this.initAction = initAction;
        }

        protected bool EnsureInit()
        {
            if (inited) return true;
            lock (lo)
            {
                initAction();
                inited = true;
                return true;
            }
        }

    }
}
