using System;

namespace FaceMatching.Services
{
    internal class WaitUntil
    {
        private Func<bool> p;

        public WaitUntil(Func<bool> p)
        {
            this.p = p;
        }
    }
}