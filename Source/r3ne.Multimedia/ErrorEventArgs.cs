using System;
using System.Collections.Generic;
using System.Text;

namespace r3ne.Multimedia
{
    public class ErrorEventArgs : EventArgs
    {
        private Exception ex;

        public ErrorEventArgs(Exception ex)
        {
            this.ex = ex;
        }

        public Exception Error
        {
            get
            {
                return ex;
            }
        }
    }
}
