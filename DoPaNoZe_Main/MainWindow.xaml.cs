using System.Windows;
using r3ne.Multimedia;
using r3ne.Multimedia.Midi;
using System.Threading;
using System;

namespace DoPaNoZe_Main
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const int SysExBufferSize = 128;

        private InputDevice inDevice = null;

        private SynchronizationContext context;


        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if (InputDevice.DeviceCount == 0)
            {
                MessageBox.Show("Kein Gerät erkannt.", "Fehler!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
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
                    Close();
                }
            }
            startRecording();


        }

        protected override void OnClosed(EventArgs e)
        {
            if (inDevice != null)
            {
                stopRecording();
                inDevice.Close();
            }

            base.OnClosed(e);
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

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                switch (e.Message.Data1)
                {
                    case 48:
                        if (note_c.Content.ToString() == "")
                            note_c.Content = "ø";
                        else
                            note_c.Content = "";
                        break;
                    case 50:
                        if (note_d.Content.ToString() == "")
                            note_d.Content = "o";
                        else
                            note_d.Content = "";
                        break;
                    case 52:
                        if (note_e.Content.ToString() == "")
                            note_e.Content = "o";
                        else
                            note_e.Content = "";
                        break;
                    case 53:
                        if (note_f.Content.ToString() == "")
                            note_f.Content = "o";
                        else
                            note_f.Content = "";
                        break;
                    case 55:
                        if (note_g.Content.ToString() == "")
                            note_g.Content = "o";
                        else
                            note_g.Content = "";
                        break;
                    case 57:
                        if (note_a.Content.ToString() == "")
                            note_a.Content = "o";
                        else
                            note_a.Content = "";
                        break;
                    case 59:
                        if (note_h.Content.ToString() == "")
                            note_h.Content = "o";
                        else
                            note_h.Content = "";
                        break;
                    case 60:
                        if (note_c2.Content.ToString() == "")
                            note_c2.Content = "o";
                        else
                            note_c2.Content = "";
                        break;
                }
            }, null);
        }

        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                string result = "\n\n"; ;

                foreach (byte b in e.Message)
                {
                    result += string.Format("{0:X2} ", b);
                }

                //sysExRichTextBox.Text += result;
            }, null);
        }

        private void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                /*sysCommonListBox.Items.Add(
                    e.Message.SysCommonType.ToString() + '\t' + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                sysCommonListBox.SelectedIndex = sysCommonListBox.Items.Count - 1;*/
            }, null);
        }

        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                /*sysRealtimeListBox.Items.Add(
                    e.Message.SysRealtimeType.ToString());

                sysRealtimeListBox.SelectedIndex = sysRealtimeListBox.Items.Count - 1;*/
            }, null);
        }

    }
}
