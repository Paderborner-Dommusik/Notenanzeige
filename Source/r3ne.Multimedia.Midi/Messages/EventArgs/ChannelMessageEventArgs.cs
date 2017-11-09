using System;
using System.Collections.Generic;
using System.Text;

namespace r3ne.Multimedia.Midi
{
    public class ChannelMessageEventArgs : EventArgs
    {
        private ChannelMessage message;

        public ChannelMessageEventArgs(ChannelMessage message)
        {
            this.message = message;
        }

        public ChannelMessage Message
        {
            get
            {
                return message;
            }
        }
    }
}
