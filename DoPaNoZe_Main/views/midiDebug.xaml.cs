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
    /// Interaktionslogik für midiDebug.xaml
    /// </summary>
    /// 

       
    public partial class midiDebug : Viewbase
    {
        private bool advancedMode;
        public midiDebug(bool advancedMode)
        {
            this.advancedMode = advancedMode;
            InitializeComponent();
        }


    }
}
