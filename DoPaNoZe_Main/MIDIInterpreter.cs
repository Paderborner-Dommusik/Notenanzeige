using System;
using r3ne.Multimedia;
using r3ne.Multimedia.Midi;
using System.Threading;
using System.Windows;

namespace NoZe_Main
{
    class MIDIInterpreter
    {
        private static MIDIInterpreter MIDIInterpreterInstance;
        public static MIDIInterpreter GetInstance()
        {
            if (MIDIInterpreterInstance == null)
            {
                MIDIInterpreterInstance = new MIDIInterpreter();
            }
            return MIDIInterpreterInstance;
        }

        private const int SysExBufferSize = 128;

        private InputDevice inDevice = null;

        private SynchronizationContext context;

        private MIDIInterpreter()
        {
            if (InputDevice.DeviceCount == 0)
            {
                MessageBox.Show("Kein Gerät erkannt.", "Fehler!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;

                    inDevice = new InputDevice(0);
                    inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
                    inDevice.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                    inDevice.SysExMessageReceived += HandleSysExMessageReceived;
                    inDevice.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                    inDevice.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            startRecording(); //Lets just pretend everything is fine \o/
            
        }

        public void Destroy()
        {
            if (inDevice != null)
            {
                stopRecording();
                inDevice.Close();
            }
            MIDIInterpreterInstance = null;
        }

        private void startRecording()
        {
            try
            {
                inDevice.StartRecording();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void stopRecording()
        {
            try
            {
                inDevice.StopRecording();
                inDevice.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void inDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!",
                   MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        /// <summary>
        /// Key Press and Release Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                MainWindow.mainwindowInstance.Visibility = null;
                //e.Message.MessageType = what happend? o.O
                //e.Message.Data1 = ID
                //e.Message.Data2 = press harder!
                
            }, null);
        }

        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            //dont think we need this
        }

        private void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
            //wont need this either
        }

        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            //pew pew

        }
    }
}
