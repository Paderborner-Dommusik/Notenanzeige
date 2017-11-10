using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoPaNoZe_Main
{
    class MIDIInterpreter
    {
        private static MIDIInterpreter MIDIInterpreterInstance;
        public static MIDIInterpreter GetMIDIInterpreter()
        {
            
            if(MIDIInterpreterInstance == null)
            {
                MIDIInterpreterInstance = new MIDIInterpreter();
            }

            return MIDIInterpreterInstance;
        }


        private MIDIInterpreter()
        {

        }
    }
}
