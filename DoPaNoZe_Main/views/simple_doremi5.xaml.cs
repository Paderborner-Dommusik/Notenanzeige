using System.Windows;

namespace Notenleuchte_Main.views
{
    /// <summary>
    /// Interaktionslogik für simple_mainview.xaml
    /// </summary>
    public partial class simple_doremi5 : Viewbase
    {
        public simple_doremi5()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void _Loaded(object sender, RoutedEventArgs e)
        {
            CreateView();
            LoadedView();
            RefreshView();
        }

        private void CreateView()
        {
            if (Viewbase.launchpad_mode)
            {
                midiToView.Clear();
                midiToView.Add(-1, back);
                midiToView.Add(23, note_5);
                midiToView.Add(32, note_6);
                midiToView.Add(34, note_7);
                midiToView.Add(36, note_8);
                midiToView.Add(38, note_9);
                midiToView.Add(39, note_10);
                midiToView.Add(49, note_11);
                midiToView.Add(51, note_12);
            }
            else
            {
                midiToView.Clear();
                midiToView.Add(-1, back);
                midiToView.Add(60, note_5);
                midiToView.Add(62, note_6);
                midiToView.Add(64, note_7);
                midiToView.Add(65, note_8);
                midiToView.Add(67, note_9);
                midiToView.Add(69, note_10);
                midiToView.Add(71, note_11);
                midiToView.Add(72, note_12);
            }

            //Turn all notes Off.
            foreach (int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }
        }
    }
}