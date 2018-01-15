using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoZe_Main
{
    class Controller
    {
        private MIDIInterpreter midiinterpreterobj;

        public Controller()
        {
            
        }

        public void Run()
        {
            midiinterpreterobj = MIDIInterpreter.GetInstance();
        }

        public void Stop()
        {
            midiinterpreterobj.Destroy();
        }
    }
}
