using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mainframe.NavigationService.CanGoBack)
            {
                mainframe.NavigationService.GoBack();
            }
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(new glavOknO());
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            mainframe.NavigationService.Navigate(new MastersWindow());
        }
    }
}
