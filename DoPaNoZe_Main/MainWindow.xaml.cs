using NoZe_Main.views;
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

        private static Viewbase activeInstance;

        public static Viewbase ActiveInstance { get => activeInstance; set => activeInstance = value; }
        
        /// <summary>
        /// Loads MainWindow, saves Instance to static mainWindowInstance
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Called on finished load. Couldnt do this in Window loaded because otherwise the notes wouldnt be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Simple_standard_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new simple_mainview());
        }

        private void Simple_halftone_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new simple_halbtonView());
        }

        //3b, Es-Dur / C-Moll
        private void Normal_m3_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_esc());
        }

        //2b, B-Dur / G-Moll
        private void Normal_m2_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_bg());
        }

        //1b, F-Dur / D-Moll
        private void Normal_m1_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_fd());
        }

        //0, C-Dur / A-Moll
        private void Normal_n_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_ca());
        }

        //1#, G-Dur / E-Moll
        private void Normal_p1_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_ge());
        }

        //2#, D-Dur / H-Moll
        private void Normal_p2_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_dh());
        }

        //3#, A-Dur / Fis-Moll
        private void Normal_p3_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_afis());
        }

        private void Lizensierung_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Programm lizensiert für \n\nPaderborner Dommusik \n dommusik@r3ne.de \n 180101validfor200101 \n verifyid004", "Gültige Lizenz gefunden", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MidiDebug_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = System.Windows.MessageBox.Show("Achtung! Hierdurch wird eine Diagnose Sitzung gestartet, fortfahren?", "Diagnosesitzung", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if(mbr == MessageBoxResult.Yes)
            {
                views.midiDebug.isActive = true;
                InitInstance(views.midiDebug.activeInstance = new midiDebug(false));
            }
            
            
        }

        private void MidiDebug_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            MessageBoxResult mbr = System.Windows.MessageBox.Show("Achtung! Hierdurch wird eine Diagnose Sitzung gestartet, fortfahren?", "Diagnosesitzung", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (mbr == MessageBoxResult.Yes)
            {
                views.midiDebug.isActive = true;
                InitInstance(views.midiDebug.activeInstance = new midiDebug(true));
            }


        }

        private void InitInstance(Viewbase type)
        {
            this.Hide();
            activeInstance = null;
            activeInstance = type;
            activeInstance.ShowDialog();

            //disable debug session
            if (views.midiDebug.isActive == true)
            {
                MessageBox.Show("Diagnose Sitzung wird beendet.", "Diagnosesitzung", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
            else
            {
                this.Show();
            }
                        
        }

        
    }
}
