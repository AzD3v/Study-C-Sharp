using System;

namespace InheritanceDemo
{
    internal class StatusChecker
    {
        private int v;

        public StatusChecker(int v)
        {
            this.v = v;
        }

        internal void CheckStatus(object state)
        {
            throw new NotImplementedException();
        }
    }
}