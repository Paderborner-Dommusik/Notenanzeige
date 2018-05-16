using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoZe_Main.views
{
    /// <summary>
    /// Interaktionslogik für normal_ca.xaml
    /// </summary>
    public partial class normal_ca : Viewbase
    {
        public normal_ca()
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
            //Simple half tone view
            midiToView.Add(-1, back);
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


            //Turn all notes Off.
            foreach (int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }
        }
        }
}
