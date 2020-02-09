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
using AssignmentEF03.Models;

namespace AssignmentEF03.Views
{
    /// <summary>
    /// Interaction logic for WindowNewEmployee.xaml
    /// </summary>
    public partial class WindowNewEmployee : Window
    {
        public WindowNewEmployee()
        {
            InitializeComponent();
        }

        public Employee Employee
        {
            get {
                return new Employee
                {
                    FirstName = TextBoxFirstName.Text,
                    LastName = TextBoxLastName.Text,
                    BirthDate = Convert.ToDateTime(DataPicker1.Text)
                };
            }
            set
            {     
                TextBoxFirstName.Text = value.FirstName;
                TextBoxLastName.Text = value.LastName;
                DataPicker1.Text = value.BirthDate.ToString();
            }
        }

        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(TextBoxFirstName.Text))
            {
                MessageBox.Show("Enter first name");
                TextBoxFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxLastName.Text))
            {
                MessageBox.Show("Enter last name");
                TextBoxLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(DataPicker1.Text))
            {
                MessageBox.Show("Enter date");
                DataPicker1.Focus();
                return false;
            }

            return true;
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                DialogResult = true;
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
