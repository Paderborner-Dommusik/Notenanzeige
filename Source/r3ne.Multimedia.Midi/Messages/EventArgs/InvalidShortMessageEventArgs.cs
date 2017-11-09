using System;
using System.Collections.Generic;
using System.Text;

namespace r3ne.Multimedia.Midi
{
    public class InvalidShortMessageEventArgs : EventArgs
    {
        private int message;

        public InvalidShortMessageEventArgs(int message)
        {
            this.message = message;
        }

        public int Message
        {
            get
            {
                return message;
            }
        }
    }
}
