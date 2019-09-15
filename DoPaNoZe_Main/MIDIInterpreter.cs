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


        public SynchronizationContext context;

        /// <summary>
        /// Tries to connect to a Midi Device.
        /// If not found, Message Box with Error,
        /// If Found init Event Management
        /// </summary>
        private MIDIInterpreter()
        {
            if (InputDevice.DeviceCount == 0)
            {
                MessageBox.Show("Keyboard anschließen!.", "Keyboard Fehler!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;
                    inDevice = new InputDevice(0);

                    if (views.midiDebug.isActive == true)
                    {
                        inDevice.ChannelMessageReceived += views.midiDebug.activeInstance.HandleChannelMessageReceived;
                        inDevice.SysCommonMessageReceived += views.midiDebug.activeInstance.HandleSysCommonMessageReceived;
                        inDevice.SysExMessageReceived += views.midiDebug.activeInstance.HandleSysExMessageReceived;
                        inDevice.SysRealtimeMessageReceived += views.midiDebug.activeInstance.HandleSysRealtimeMessageReceived;
                        inDevice.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                    }
                    else
                    {
                        inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
                        inDevice.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                        inDevice.SysExMessageReceived += HandleSysExMessageReceived;
                        inDevice.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                        inDevice.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);
                    }


                    StartRecording(); //Lets just pretend everything is fine \o/
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
                StopRecording();
                inDevice.Close();
            }
            MIDIInterpreterInstance = null;
        }

        /// <summary>
        /// Starts the Recording
        /// </summary>
        private void StartRecording()
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
        private void StopRecording()
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
                //NoZe_Main.MainWindow.ActiveInstance.SwitchNote(Convert.ToInt32(e.Message.Data1));

                //Do not uncomment. Seriously.
                //MessageBox.Show(e.Message.Command.ToString());



                //MessageBox.Show("Note: " + e.Message.Data1.ToString() + ", Velo: " + e.Message.Data2.ToString());
                if (NoZe_Main.MainWindow.IsInMainWindow)
                {
                    NoZe_Main.MainWindow.MWInstance.handleMidiKeyboard(e.Message.Data1);
                }
                else if (views.Viewbase.launchpad_mode)
                {
                    if (Convert.ToInt32(e.Message.Data2.ToString()) > 0)
                        NoZe_Main.MainWindow.ActiveInstance.SetNoteOn(Convert.ToInt32(e.Message.Data1));
                    else
                        NoZe_Main.MainWindow.ActiveInstance.SetNoteOff(Convert.ToInt32(e.Message.Data1));
                }
                else
                {
                    if (e.Message.Command.ToString() == "NoteOn")
                        NoZe_Main.MainWindow.ActiveInstance.SetNoteOn(Convert.ToInt32(e.Message.Data1));
                    else
                        NoZe_Main.MainWindow.ActiveInstance.SetNoteOff(Convert.ToInt32(e.Message.Data1));
                }

                //e.Message.Command = DOITNAAAAUH
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
        /// Realtime Messages - for some reason nothing works without fetching these
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
        }
    }
}
