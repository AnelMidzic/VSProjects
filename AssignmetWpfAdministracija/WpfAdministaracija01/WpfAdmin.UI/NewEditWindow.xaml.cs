using Admin.ViewModel;
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

namespace WpfAdmin.UI
{
    /// <summary>
    /// Interaction logic for NewEditWindow.xaml
    /// </summary>
    public partial class NewEditWindow : Window
    {
        public NewEditWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NewEditWindowViewModel viewModel = (NewEditWindowViewModel)DataContext;
            viewModel.Done += ViewModel_Done;            
        }

        private void ViewModel_Done(object sender, NewEditWindowViewModel.DoneEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked==true)
            {
                TextBoxAdmin.Focus();
                TextBoxAdmin.Text = "True";
            }            
            
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked == false)
            {
                TextBoxAdmin.Focus();
                TextBoxAdmin.Text = "False";
            }
        }
    }
}
