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
            this.Hide();
            activeInstance = new simple_halbtonView();
            activeInstance.ShowDialog();
            this.Show();
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


    }
}
