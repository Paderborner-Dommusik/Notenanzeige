using System;
using System.Collections.Generic;
using System.Text;

namespace r3ne.Collections.Generic
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
