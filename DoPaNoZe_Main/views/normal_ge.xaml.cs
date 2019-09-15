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

namespace Notenleuchte_Main.views
{
    /// <summary>
    /// Interaktionslogik für normal_ge.xaml
    /// </summary>
    public partial class normal_ge : Viewbase
    {
        public normal_ge()
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
                midiToView.Add(16, note_1);
                midiToView.Add(17, hnote_1);
                midiToView.Add(18, note_2);
                midiToView.Add(19, note_3);
                midiToView.Add(20, hnote_2);
                midiToView.Add(21, note_4);
                midiToView.Add(22, hnote_3);
                midiToView.Add(23, note_5);
                midiToView.Add(32, note_6);
                midiToView.Add(33, hnote_4);
                midiToView.Add(34, note_7);
                midiToView.Add(35, hnote_5);
                midiToView.Add(36, note_8);
                midiToView.Add(37, hnote_6);
                midiToView.Add(38, note_9);
                midiToView.Add(39, note_10);
                midiToView.Add(48, hnote_7);
                midiToView.Add(49, note_11);
                midiToView.Add(50, hnote_8);
                midiToView.Add(51, note_12);
                midiToView.Add(52, note_13);
                midiToView.Add(53, hnote_9);
                midiToView.Add(54, note_14);
                midiToView.Add(55, hnote_10);
                midiToView.Add(64, note_15);
                midiToView.Add(65, hnote_11);
                midiToView.Add(66, note_16);
                midiToView.Add(67, note_17);
                midiToView.Add(68, hnote_12);
            }
            else
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
            }

            //Turn all notes Off.
            foreach (int a in midiToView.Keys)
            {
                SetNoteOff(a);
            }
        }
    }
}