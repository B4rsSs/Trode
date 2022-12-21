using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trode.Pages;

namespace Trode
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinWidth = 1300;
            MinHeight = 740;

            MainFrame.Navigate(new Auth());
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Auth());
        }
    }
}
