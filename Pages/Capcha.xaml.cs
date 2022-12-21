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
using Trode.Pages;

namespace Trode.Pages
{
    /// <summary>
    /// Логика взаимодействия для Capcha.xaml
    /// </summary>
    public partial class Capcha : Page
    {
        private int _RoleId { get; set; }
        public Capcha(int UserRole)
        {
            InitializeComponent();
            this._RoleId = UserRole;
            RandCapcha();
        }

        /// <summary>
        /// Генерация капчи
        /// </summary>
        private void RandCapcha()
        {
            Random rand = new Random();

            CapchaTxt.Text = "";

            for (int i = 0; i < 2; i++)
            {
                CapchaTxt.Text += (char)('a' + rand.Next(0, 26));
                CapchaTxt.Text += (char)('A' + rand.Next(0, 26));
                CapchaTxt.Text += rand.Next(0, 10);
            }
        }

        private void updateCapcha_Click(object sender, RoutedEventArgs e)
        {
            RandCapcha();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (inputCapcha.Text == CapchaTxt.Text)
                NavigationService.Navigate(new ProductView(_RoleId));
            else
                RandCapcha();
        }
    }
}
