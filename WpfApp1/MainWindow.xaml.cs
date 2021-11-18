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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        
        
        private void btnExplore_Click(object sender, RoutedEventArgs e)
        {
            genrePanel.Visibility = Visibility.Visible;
            btnExplore.Visibility = Visibility.Collapsed;

        }

        private void btnRock_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCountry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRnB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEDM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnJazz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBlues_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
