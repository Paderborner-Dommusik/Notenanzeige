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

        private void simple_standard_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            activeInstance = null;
            activeInstance = new simple_mainview();
            activeInstance.ShowDialog();
            this.Show();
        }

        private void simple_halftone_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            activeInstance = null;
            activeInstance = new simple_halbtonView();
            activeInstance.ShowDialog();
            this.Show();
        }

        //3b, Es-Dur / C-Moll
        private void normal_m3_Click(object sender, RoutedEventArgs e)
        {

        }

        //2b, B-Dur / G-Moll
        private void normal_m2_Click(object sender, RoutedEventArgs e)
        {

        }

        //1b, F-Dur / D-Moll
        private void normal_m1_Click(object sender, RoutedEventArgs e)
        {

        }

        //0, C-Dur / A-Moll
        private void normal_n_Click(object sender, RoutedEventArgs e)
        {

        }

        //1#, G-Dur / E-Moll
        private void normal_p1_Click(object sender, RoutedEventArgs e)
        {

        }

        //2#, D-Dur / H-Moll
        private void normal_p2_Click(object sender, RoutedEventArgs e)
        {

        }

        //3#, A-Dur / Fis-Moll
        private void normal_p3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
