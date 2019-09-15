using System;
using r3ne.Multimedia;
using r3ne.Multimedia.Midi;
using System.Threading;
using System.Windows;

namespace Notenleuchte_Main.views
{
    /// <summary>
    /// Interaktionslogik für midiDebug.xaml
    /// </summary>
    /// 


    public partial class midiDebug : Viewbase
    {
        public static bool isActive = false;
        private bool advancedMode;
        private static MIDIInterpreter MIDIInterpreterInstance;

        public static midiDebug activeInstance = null;

        public midiDebug(bool advancedMode)
        {
            this.advancedMode = advancedMode;
            InitializeComponent();
            MIDIInterpreterInstance = MIDIInterpreter.GetInstance();
        }


        public void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            MIDIInterpreterInstance.context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add(
                    e.Message.Command.ToString() + '\t' + '\t' +
                    e.Message.MidiChannel.ToString() + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);
        }

        public void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            MIDIInterpreterInstance.context.Post(delegate (object dummy)
            {
                string result = "\n\n"; ;

                foreach (byte b in e.Message)
                {
                    result += string.Format("{0:X2} ", b);
                }

                sysExRichTextBox.Items.Add(result);
            }, null);
        }

        public void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
            MIDIInterpreterInstance.context.Post(delegate (object dummy)
            {
                sysCommonListBox.Items.Add(
                    e.Message.SysCommonType.ToString() + '\t' + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                sysCommonListBox.SelectedIndex = sysCommonListBox.Items.Count - 1;
            }, null);
        }

        public void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            MIDIInterpreterInstance.context.Post(delegate (object dummy)
            {
                sysRealtimeListBox.Items.Add(
                    e.Message.SysRealtimeType.ToString());

                sysRealtimeListBox.SelectedIndex = sysRealtimeListBox.Items.Count - 1;
            }, null);
        }


    }
}
