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
using Trode.Database;

namespace Trode.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        public AddUsers()
        {
            InitializeComponent();
            CompoRole.ItemsSource = TrodeEntities.GetContext().Role.ToList();
            CompoRole.SelectedIndex = 2;
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.UserLogin = UserLogin.Text;
            user.UserPassword = UserPasswoed.Text;
            user.UserName = UserName.Text;
            user.UserSurname = UserSurname.Text;
            user.UserPatronymic = UserMiddleName.Text;

            user.Role = CompoRole.SelectedItem as Role;

            TrodeEntities.GetContext().User.Add(user);

            try
            {
                TrodeEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("Пользователь добавлен !", "Успех");

            Close();
        }
    }
}
