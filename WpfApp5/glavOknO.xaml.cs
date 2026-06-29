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
using static WpfApp5.Core;


namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для glavOknO.xaml
    /// </summary>
    public partial class glavOknO : Page
    {
        public glavOknO()
        {
            InitializeComponent();
            loaddate();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Hairsss.SelectedItem != null)
            {
                haircuts = Hairsss.SelectedItem as Haircuts;
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SortComboBox.SelectedIndex)
            {
                case 0:break
            }
        }
        void loaddate()
        {
            List <Haircuts> h = context.Haircuts.ToList();
            Hairsss.ItemsSource = h;
        }
    }
}
