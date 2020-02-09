using Admin.ViewModel;
using AdminModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfAdmin.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginWindowViewModel loginViewModel = new LoginWindowViewModel();

            this.DataContext = loginViewModel;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel viewModel = (LoginWindowViewModel)DataContext;
            viewModel.UserName = TextBoxUser.Text;
            viewModel.Password = TextBoxPass.Text;

            if (viewModel.IsUserAdmin)
            {
                MainWindow mainWindow = new MainWindow(this);
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("User is not an admin!");
            }
        }
    }
}
