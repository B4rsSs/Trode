using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System;
using Trode.Database;
using Trode.Pages;

namespace Trode.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {       
        public Auth()
        {
            InitializeComponent();            
        }       

        private void SignInGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductView(0));
            ((MainWindow)Window.GetWindow(this)).UserInfo.Text = $"Вы вошли как гость";
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUsers = TrodeEntities.GetContext().User.ToList();

            var auth = currentUsers.Where(p => p.UserLogin == InputLogin.Text && p.UserPassword == InputPassword.Text).FirstOrDefault();
            
            if (auth != null)
            {
                ((MainWindow)Window.GetWindow(this)).UserInfo.Text = $"Вы вошли как: {auth.UserName} {auth.UserSurname} {auth.UserPatronymic}";
                NavigationService.Navigate(new Capcha(auth.UserRole));
            }   
            else
                MessageBox.Show("Вы ввели некорректные данные.", "Упс...");


        }
    }
}
