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
    /// Логика взаимодействия для MastersWindow.xaml
    /// </summary>
    public partial class MastersWindow : Page
    {
        public MastersWindow()
        {
            InitializeComponent();
            LoadMasters();
        }

        private void LoadMasters()
        {
            // Загружаем список мастеров из базы данных через ваш общий контекст Core
            if (Core.context != null && Core.context.Masters != null)
            {
                MastersListBox.ItemsSource = Core.context.Masters.ToList();
            }
        }

        private void SelectMaster_Click(object sender, RoutedEventArgs e)
        {
            // 1. Получаем кнопку, на которую нажал пользователь
            var button = sender as Button;
            if (button == null) return;

            // 2. Из контекста кнопки достаем объект выбранного мастера
            var selectedMaster = button.DataContext as Masters;

            if (selectedMaster != null)
            {
                // Сохраняем мастера в глобальный класс (убедитесь, что свойство masters добавлено в Core.cs)
                Core.masters = selectedMaster;

                // 3. Выполняем переход на финальную страницу с календарем
                if (NavigationService != null)
                {
                    NavigationService.Navigate(new Endpage());
                }
            }
        }
    }
}
