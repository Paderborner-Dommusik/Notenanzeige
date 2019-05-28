using Microsoft.Win32;
using NoZe_Main.views;
using System;
using System.Windows;


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

        private string getRegVal(string key)
        {
            try
            {
                RegistryKey SoftwareKey = Registry.LocalMachine.OpenSubKey("Software", true);

                RegistryKey AppNameKey = SoftwareKey.CreateSubKey("de.r3ne.projects.noze");
                return Convert.ToString(AppNameKey.GetValue(key, ""));
            }
            catch
            {
                MessageBox.Show("Programm muss zur Lizensierung als Administrator gestartet sein", "Fehler beim Lizensieren", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }


        }

        /// <summary>
        /// Sets a value in preset registry spot
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private bool setRegVal(string key, string value)
        {
            try
            {
                RegistryKey SoftwareKey = Registry.LocalMachine.OpenSubKey("Software", true);
                RegistryKey AppNameKey = SoftwareKey.CreateSubKey("de.r3ne.projects.noze");

                AppNameKey.SetValue(key, value);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// tbi
        /// </summary>
        private void checkLicense()
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

        //0, C-Dur / A-Moll in Variante mit b und mit #
        private void normal_b_Click(object sender, RoutedEventArgs e)
        {
            InitInstance(new normal_cab());
        }

        private void normal_sharp_Click(object sender, RoutedEventArgs e)
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
            if (getRegVal("licensekey") == null)
            {
                if (setRegVal("licensekey", "DOM-000TEST"))
                {
                    MessageBox.Show("Die Lizenz -DOM-000TEST- wurde aktiviert", "Lizenz aktiviert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                { MessageBox.Show("Lizenz konnte nicht aktiviert werden.", "Lizenzfehler", MessageBoxButton.OK, MessageBoxImage.Information); }
            }

        }

        private void MidiDebug_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = System.Windows.MessageBox.Show("Achtung! Hierdurch wird eine Diagnose Sitzung gestartet, fortfahren?", "Diagnosesitzung", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (mbr == MessageBoxResult.Yes)
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

        private void Label_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            

        }

        private void midiLaunchpad_Click(object sender, RoutedEventArgs e)
        {
            Viewbase.launchpad_mode = !Viewbase.launchpad_mode;
            MessageBox.Show("Launchpad Mode: " + Viewbase.launchpad_mode.ToString(), "Launchpad Modus", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
