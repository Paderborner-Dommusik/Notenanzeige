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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Init midiToView
            midiToView.Add(55, glow_55);
            midiToView.Add(56, null);
            midiToView.Add(57, glow_57);
            midiToView.Add(58, null);
            midiToView.Add(59, glow_59);
            midiToView.Add(60, glow_60);
            midiToView.Add(61, null);
            midiToView.Add(62, glow_62);
            midiToView.Add(63, null);
            midiToView.Add(64, glow_64);
            midiToView.Add(65, glow_65);
            midiToView.Add(66, null);
            midiToView.Add(67, glow_67);
            midiToView.Add(68, null);
            midiToView.Add(69, glow_69);
            midiToView.Add(70, null);
            midiToView.Add(71, glow_71);
            midiToView.Add(72, glow_72);
            midiToView.Add(73, null);
            midiToView.Add(74, glow_74);
            midiToView.Add(75, null);
            midiToView.Add(76, glow_76);
            midiToView.Add(77, glow_77);
            midiToView.Add(78, null);
            midiToView.Add(79, glow_79);
            midiToView.Add(80, null);
            midiToView.Add(81, glow_81);
            midiToView.Add(82, glow_82);

            foreach(int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }

            systemController = new Controller();
            systemController.Run();
        }

        public void SetNoteOn(int midiID)
        {

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
    }
}
