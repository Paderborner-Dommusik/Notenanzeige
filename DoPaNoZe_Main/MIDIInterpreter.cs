using System;
using r3ne.Multimedia;
using r3ne.Multimedia.Midi;
using System.Threading;
using System.Windows;

namespace NoZe_Main
{
    class MIDIInterpreter
    {

        //holds Singleton Midi Interpreter Instance
        private static MIDIInterpreter MIDIInterpreterInstance;

        /// <summary>
        /// Get /and create if needed/ Mdi Interpreter instance
        /// </summary>
        /// <returns>Singleton Midi Interpreter Instance</returns>
        public static MIDIInterpreter GetInstance()
        {
            if (MIDIInterpreterInstance == null)
            {
                MIDIInterpreterInstance = new MIDIInterpreter();
            }
            return MIDIInterpreterInstance;
        }

        private const int SysExBufferSize = 128;

        /// <summary>
        /// Holds input Device, if found
        /// </summary>
        private InputDevice inDevice = null;


        private SynchronizationContext context;

        /// <summary>
        /// Tries to connect to a Midi Device.
        /// If not found, Message Box with Error,
        /// If Found init Event Management
        /// </summary>
        private MIDIInterpreter()
        {
            if (InputDevice.DeviceCount == 0)
            {
                MessageBox.Show("Kein Gerät erkannt.", "Fehler!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow.mainwindowInstance.OutUser("Kein Gerät erkannt.");
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

                    startRecording(); //Lets just pretend everything is fine \o/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            
        }

        /// <summary>
        /// Disable Event Management and close connection to device
        /// Nulls Interpreter instance
        /// </summary>
        public void Destroy()
        {
            if (inDevice != null)
            {
                stopRecording();
                inDevice.Close();
            }
            MIDIInterpreterInstance = null;
        }

        /// <summary>
        /// Starts the Recording
        /// </summary>
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

        /// <summary>
        /// Stops the Recording
        /// </summary>
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

        /// <summary>
        /// Event For Errors in device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                NoZe_Main.MainWindow.mainwindowInstance.SwitchNote(Convert.ToInt32(e.Message.Data1));
                //e.Message.MessageType = what happend? o.O
                //e.Message.Data1 = ID
                //e.Message.Data2 = press harder!
                
            }, null);
        }


        /// <summary>
        /// Sys Messages, not needed yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
        }

        /// <summary>
        /// Sys Common Messages, not needed but fetched - just in case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
        }

        /// <summary>
        /// Realtime Messages - for some reason nothings working without fetching these
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
        }
    }
}
