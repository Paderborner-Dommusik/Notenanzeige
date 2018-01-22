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
            midiToView.Add(55, note_1);
            midiToView.Add(56, null);
            midiToView.Add(57, note_2);
            midiToView.Add(58, null);
            midiToView.Add(59, note_3);
            midiToView.Add(60, note_4);
            midiToView.Add(61, null);
            midiToView.Add(62, note_5);
            midiToView.Add(63, null);
            midiToView.Add(64, note_6);
            midiToView.Add(65, note_7);
            midiToView.Add(66, null);
            midiToView.Add(67, note_8);
            midiToView.Add(68, null);
            midiToView.Add(69, note_9);
            midiToView.Add(70, null);
            midiToView.Add(71, note_10);
            midiToView.Add(72, note_11);
            midiToView.Add(73, null);
            midiToView.Add(74, note_12);
            midiToView.Add(75, null);
            midiToView.Add(76, note_13);
            midiToView.Add(77, note_14);
            midiToView.Add(78, null);
            midiToView.Add(79, note_15);
            midiToView.Add(80, null);
            midiToView.Add(81, note_16);
            midiToView.Add(82, note_17);

            foreach (int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }

           
        }
    }
}
