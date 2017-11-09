using System;
using System.Collections;
using System.Text;

namespace r3ne.Multimedia.Midi
{
    public class StoppedEventArgs : EventArgs
    {
        private ICollection messages;

        public StoppedEventArgs(ICollection messages)
        {
            this.messages = messages;
        }

        public ICollection Messages
        {
            get
            {
                return messages;
            }
        }
    }
}
