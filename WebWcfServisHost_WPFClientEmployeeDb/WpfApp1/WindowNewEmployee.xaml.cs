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
using WpfApp1.EmployeeServiceReference;

namespace WpfApp1
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
        public EmployeeCon EmployeeCon
        {
            get
            {
                return new EmployeeCon
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

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
