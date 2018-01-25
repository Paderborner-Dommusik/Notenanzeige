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
        
        //Instance of the system Controller
        private Controller systemController;

        //Holds all needed Midi Ids and the corresponding Image. To be changed in final version.
        public static Dictionary<int, Image>[] midiToView = new Dictionary<int, Image>[2];

        public static int selectedViewMode = 0;
        
        /// <summary>
        /// Loads MainWindow, saves Instance to static mainWindowInstance
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            mainwindowInstance = this;

        }

        /// <summary>
        /// Init new Controller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Init midiToView
            systemController = new Controller();
            systemController.Run();
        }


        /// <summary>
        /// Sets Note on
        /// </summary>
        /// <param name="midiID">The ID of the Midi Event</param>
        public void SetNoteOn(int midiID, int selectedMode)
        {
            if (selectedMode == -1)
                selectedMode = selectedViewMode;

            Image glowElement = null;
            midiToView[selectedMode].TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                glowElement.Opacity = 1.0;

            }
        }

        /// <summary>
        /// Sets Note off
        /// </summary>
        /// <param name="midiID">The ID of the Midi Event</param>
        public void SetNoteOff(int midiID, int selectedMode)
        {
            if (selectedMode == -1)
                selectedMode = selectedViewMode;

            Image glowElement = null;
            midiToView[selectedMode].TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                glowElement.Opacity = 0.0;

            }
        }


        /// <summary>
        /// Finds out if Note is on.
        /// </summary>
        /// <param name="midiID">The ID of the Midi Event</param>
        /// <returns>State of given Note</returns>
        public bool IsNoteOn(int midiID, int selectedMode)
        {
            if (selectedMode == -1)
                selectedMode = selectedViewMode;

            Image glowElement = null;
            midiToView[selectedMode].TryGetValue(midiID, out glowElement);
            if (glowElement != null)
            {
                return glowElement.Opacity == 0.0 ? false : true;
            }

            return false;
        }


        /// <summary>
        /// Toggles the State of a Note
        /// </summary>
        /// <param name="midiID">The ID of the Midi Event</param>
        public void SwitchNote(int midiID, int selectedMode)
        {
            if(selectedMode == -1)
                selectedMode = selectedViewMode;
            
            if (IsNoteOn(midiID, selectedMode))
                SetNoteOff(midiID, selectedMode);
            else
                SetNoteOn(midiID, selectedMode);
        }

        /// <summary>
        /// Sets User Output Label Text
        /// </summary>
        /// <param name="com">Text to print out</param>
        public void OutUser(string com)
        {
            //pew pew
        }

        

        /// <summary>
        /// Called on finished load. Couldnt do this in Window loaded because otherwise the notes wouldnt be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Loaded(object sender, RoutedEventArgs e)
        {
            midiToView[0] = new Dictionary<int, Image>();
            midiToView[0].Add(-1, back);
            midiToView[0].Add(57, note_1);
            midiToView[0].Add(58, hnote_1);
            midiToView[0].Add(59, note_2);
            midiToView[0].Add(60, note_3);
            midiToView[0].Add(61, hnote_2);
            midiToView[0].Add(62, note_4);
            midiToView[0].Add(63, hnote_3);
            midiToView[0].Add(64, note_5);
            midiToView[0].Add(65, note_6);
            midiToView[0].Add(66, hnote_4);
            midiToView[0].Add(67, note_7);
            midiToView[0].Add(68, hnote_5);
            midiToView[0].Add(69, note_8);
            midiToView[0].Add(70, hnote_6);
            midiToView[0].Add(71, note_9);
            midiToView[0].Add(72, note_10);
            midiToView[0].Add(73, hnote_7);
            midiToView[0].Add(74, note_11);
            midiToView[0].Add(75, hnote_8);
            midiToView[0].Add(76, note_12);
            midiToView[0].Add(77, note_13);
            midiToView[0].Add(78, hnote_9);
            midiToView[0].Add(79, note_14);
            midiToView[0].Add(80, hnote_10);
            midiToView[0].Add(81, note_15);
            midiToView[0].Add(82, hnote_11);
            midiToView[0].Add(83, note_16);
            midiToView[0].Add(84, note_17);
            midiToView[0].Add(85, hnote_12);


            //Turn all notes Off.
            foreach (int a in midiToView[0].Keys)
            {
                SetNoteOff(a, 0);
            }


            //half tone view
            midiToView[1] = new Dictionary<int, Image>();
            midiToView[1].Add(-1, hv_back);
            midiToView[1].Add(57, hv_note_1);
            midiToView[1].Add(58, hv_hnote_1);
            midiToView[1].Add(59, hv_note_2);
            midiToView[1].Add(60, hv_note_3);
            midiToView[1].Add(61, hv_hnote_2);
            midiToView[1].Add(62, hv_note_4);
            midiToView[1].Add(63, hv_hnote_3);
            midiToView[1].Add(64, hv_note_5);
            midiToView[1].Add(65, hv_note_6);
            midiToView[1].Add(66, hv_hnote_4);
            midiToView[1].Add(67, hv_note_7);
            midiToView[1].Add(68, hv_hnote_5);
            midiToView[1].Add(69, hv_note_8);
            midiToView[1].Add(70, hv_hnote_6);
            midiToView[1].Add(71, hv_note_9);
            midiToView[1].Add(72, hv_note_10);
            midiToView[1].Add(73, hv_hnote_7);
            midiToView[1].Add(74, hv_note_11);
            midiToView[1].Add(75, hv_hnote_8);
            midiToView[1].Add(76, hv_note_12);
            midiToView[1].Add(77, hv_note_13);
            midiToView[1].Add(78, hv_hnote_9);
            midiToView[1].Add(79, hv_note_14);
            midiToView[1].Add(80, hv_hnote_10);
            midiToView[1].Add(81, hv_note_15);
            midiToView[1].Add(82, hv_hnote_11);
            midiToView[1].Add(83, hv_note_16);
            midiToView[1].Add(84, hv_note_17);
            midiToView[1].Add(85, hv_hnote_12);


            //Turn all notes Off.
            foreach (int a in midiToView[1].Keys)
            {
                SetNoteOff(a, 1);
            }


            SetNoteOn(-1, selectedViewMode);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            systemController.Stop();
        }
    }
}
