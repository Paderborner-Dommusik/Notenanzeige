using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NoZe_Main.views
{
    public class Viewbase : Window
    {
        public Dictionary<int, Image> midiToView = new Dictionary<int, Image>();
        
        //Instance of the system Controller
        private Controller systemController;

        public void LoadedView()
        {
            //Init midiToView
            systemController = new Controller();
            systemController.Run();
        }

        public void RefreshView()
        {
            foreach (int b in midiToView.Keys)
                SetNoteOff(b);

            //Show note Grid for selected Mode
            SetNoteOn(-1);
        }



        public void SetNoteOn(int midiID)
        {
            midiToView.TryGetValue(midiID, out Image glowElement);
            if (glowElement != null)
            {
                glowElement.Opacity = 1.0;
            }
        }

        public void SetNoteOff(int midiID)
        {
            midiToView.TryGetValue(midiID, out Image glowElement);
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
        public bool IsNoteOn(int midiID)
        {
            midiToView.TryGetValue(midiID, out Image glowElement);
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
        public void SwitchNote(int midiID)
        {

            if (IsNoteOn(midiID))
                SetNoteOff(midiID);
            else
                SetNoteOn(midiID);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            systemController.Stop();
        }
    }
}
