using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NoZe_Main
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainwindowInstance = null;
        private Controller systemController;
  
        private Dictionary<int, Image> midiToView = new Dictionary<int, Image>();

        
        
        public MainWindow()
        {
            InitializeComponent();
            mainwindowInstance = this;

            version.Content = "b_0-18012211";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Init midiToView
            systemController = new Controller();
            systemController.Run();
        }

        public void SetNoteOn(int midiID)
        {
            Image glowElement = null;
            midiToView.TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                glowElement.Opacity = 1.0;

            }
        }

        public void SetNoteOff(int midiID)
        {
            Image glowElement = null;
            midiToView.TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                glowElement.Opacity = 0.0;

            }
        }

        public bool IsNoteOn(int midiID)
        {
            Image glowElement = null;
            midiToView.TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                return glowElement.Opacity == 0.0 ? false : true;
            }

            return false;
        }

        public void SwitchNote(int midiID)
        {
            if (IsNoteOn(midiID))
                SetNoteOff(midiID);
            else
                SetNoteOn(midiID);
        }

        public void OutUser(string com)
        {
            userCom.Content = com;
        }

        private void _Loaded(object sender, RoutedEventArgs e)
        {
            midiToView.Add(57, note_1);
            midiToView.Add(58, hnote_1);
            midiToView.Add(59, note_2);
            midiToView.Add(60, note_3);
            midiToView.Add(61, hnote_2);
            midiToView.Add(62, note_4);
            midiToView.Add(63, hnote_3);
            midiToView.Add(64, note_5);
            midiToView.Add(65, note_6);
            midiToView.Add(66, hnote_4);
            midiToView.Add(67, note_7);
            midiToView.Add(68, hnote_5);
            midiToView.Add(69, note_8);
            midiToView.Add(70, hnote_6);
            midiToView.Add(71, note_9);
            midiToView.Add(72, note_10);
            midiToView.Add(73, hnote_7);
            midiToView.Add(74, note_11);
            midiToView.Add(75, hnote_8);
            midiToView.Add(76, note_12);
            midiToView.Add(77, note_13);
            midiToView.Add(78, hnote_9);
            midiToView.Add(79, note_14);
            midiToView.Add(80, hnote_10);
            midiToView.Add(81, note_15);
            midiToView.Add(82, hnote_11);
            midiToView.Add(83, note_16);
            midiToView.Add(84, note_17);
            midiToView.Add(85, hnote_12);

            foreach (int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }

           
        }
    }
}
