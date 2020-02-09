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
using WpfApp1.EmployeeServiceReference;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<EmployeeCon> employeeList = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowEmployees()
        {
            EmployeeServiceClient klijent = new EmployeeServiceClient();
            IEnumerable<EmployeeCon> employeeList = klijent.ReturnEmployees();
            klijent.Close();
            ListBox1.DisplayMemberPath = "LastName";
            ListBox1.ItemsSource = null;
            ListBox1.ItemsSource = employeeList;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowEmployees();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (ListBox1.SelectedIndex > -1)
            {
                EmployeeCon e1 = ListBox1.SelectedItem as EmployeeCon;

                TextBoxFirstName.Text = e1.FirstName;
                TextBoxLastName.Text = e1.LastName;
                TextBoxDateOfBirth.Text = e1.BirthDate.ToString();
            }
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            EmployeeServiceClient klijent = new EmployeeServiceClient();
            WindowNewEmployee w1 = new WindowNewEmployee();
            w1.Title = "Enter employee information";
            w1.Owner = this;

            if (w1.ShowDialog() == true)
            {
                EmployeeCon e1 = w1.EmployeeCon;

                int id = klijent.InsertEmployees(e1);

                if (id != -1)
                {
                    ShowEmployees();
                    //ListBox1.SelectedIndex = employeeList
                     //   .Where(a => a.EmployeeID == id);
                    MessageBox.Show("New employee added");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            EmployeeServiceClient klijent = new EmployeeServiceClient();

            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select employee");
                return;
            }

            EmployeeCon e2 = ListBox1.SelectedItem as EmployeeCon;

            MessageBoxResult mbr = MessageBox.Show("Delete employee: " + e2.ToString(), "Delete", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            

            int result = klijent.DeleteEmployee(e2);
            klijent.Close();

            if (result == 0)
            {
                ShowEmployees();
                TextBoxFirstName.Clear();
                TextBoxLastName.Clear();
                TextBoxDateOfBirth.Clear();
                MessageBox.Show("Employee deleted");
            }

            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

/*private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MagacinServiceClient klijent = new MagacinServiceClient();
            Kategorija[] listaKategorija = klijent.VratiKategorije();
            klijent.Close();
            ListBox1.DisplayMemberPath = "NazivKategorije";

            foreach (Kategorija k in listaKategorija)
            {
                ListBox1.Items.Add(k);
            }
            klijent.Close();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kategorija k = ListBox1.SelectedItem as Kategorija;
            MagacinServiceClient klijent = new MagacinServiceClient();
            Proizvod[] listaProizvoda = klijent.VratiProizvode(k.KategorijaId);
            StringBuilder sb = new StringBuilder();
            foreach (Proizvod p in listaProizvoda)
            {
                sb.AppendLine(p.NazivProizvoda + p.Cijena);                
            }
            TextBlock1.Text = sb.ToString();
        }
        */