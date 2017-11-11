using System.Windows;


namespace DoPaNoZe_Main
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller systemController;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            systemController = new Controller();
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
    }
}
