using System.Windows;


namespace NoZe_Main
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window mainwindowInstance = null;
        private Controller systemController;

        public MainWindow()
        {
            InitializeComponent();
            mainwindowInstance = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            systemController = new Controller();
            systemController.Run();
        }

        public void SetNoteOn(int midiID)
        {

        }

        public void SetNoteOff(int midiID)
        {

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
