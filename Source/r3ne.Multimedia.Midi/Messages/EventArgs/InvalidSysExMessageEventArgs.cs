using System;
using System.Collections;
using System.Text;

namespace r3ne.Multimedia.Midi
{
    public class InvalidSysExMessageEventArgs : EventArgs
    {
        private byte[] messageData;

        public InvalidSysExMessageEventArgs(byte[] messageData)
        {
            this.messageData = messageData;
        }

        public ICollection MessageData
        {
            get
            {
                return messageData;
            }
        }
    }
}
