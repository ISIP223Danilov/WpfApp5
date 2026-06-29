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
            // 1. Получаем кнопку, на которую нажали
            var button = sender as Button;
            if (button == null) return;

            // 2. Достаем объект прически из DataContext этой конкретной кнопки
            var selectedHaircut = button.DataContext as Haircuts;

            if (selectedHaircut != null)
            {
                // Сохраняем выбранную прическу в глобальный класс Core
                Core.haircuts = selectedHaircut;

                // 3. Выполняем переход на страницу мастеров
                if (NavigationService != null)
                {
                    NavigationService.Navigate(new MastersWindow());
                }
            }
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверка на null нужна, так как событие срабатывает один раз при инициализации до загрузки UI
            if (Hairsss == null) return;

            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    Hairsss.ItemsSource = Core.context.Haircuts.OrderByDescending(x => x.Price).ToList();
                    break;
                case 1:
                    Hairsss.ItemsSource = Core.context.Haircuts.OrderBy(x => x.Price).ToList();
                    break;
            }
        }

        void loaddate()
        {
            List<Haircuts> h = Core.context.Haircuts.ToList();
            Hairsss.ItemsSource = h;
        }
    }
}
