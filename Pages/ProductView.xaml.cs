using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Trode.Database;
using Trode.Pages;

namespace Trode.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        private int _UserRoleId { get; set; }
        public ProductView(int UserRole)
        {
            InitializeComponent();

            this._UserRoleId = UserRole;

            if (_UserRoleId == 1)
                AdminPanel.Visibility = Visibility.Visible;

            lVProduct.ItemsSource = TrodeEntities.GetContext().Product.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentProduct = TrodeEntities.GetContext().Product.ToList();

            lVProduct.ItemsSource = currentProduct.Where(p => p.ProductCategory.ToLower().Contains(SortTxt.Text.ToLower())).ToList();
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPanel());
        }
    }
}
