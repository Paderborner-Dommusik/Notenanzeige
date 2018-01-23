using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoZe_Main
{
    /// <summary>
    /// Device Connection Controller for easy Window Access
    /// </summary>
    class Controller
    {
        private MIDIInterpreter midiinterpreterobj;

        public Controller()
        {
            
        }

        /// <summary>
        /// Get Midi Interpreter 
        /// </summary>
        public void Run()
        {
            midiinterpreterobj = MIDIInterpreter.GetInstance();
        }

        /// <summary>
        /// Call Destroy on Midi Interpreter
        /// </summary>
        public void Stop()
        {
            midiinterpreterobj.Destroy();
            midiinterpreterobj = null;
        }
    }
}
