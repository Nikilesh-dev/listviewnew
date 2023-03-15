using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Listview.Create_class;

namespace Listview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> employees;
        public MainWindow()
        {
            InitializeComponent();
            
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int name = 0;
            int age = 0;
            int ID = 0;
            int mail = 0;
            int phone = 0;

            String regexname = "^[A-Za-z][A-Za-z0-9_]{7,29}$";
            String regexmail = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
            String regexage = "/\r\n^(1[89]|[2-9]\\d)$\r\n/\r\ngm";
            String regexphone = "^[6-9]\\d{9}$";

            foreach (Match item in Regex.Matches(txtname.Text, regexname))
            {
                name++;
            }
            foreach (Match item in Regex.Matches(txtmail.Text, regexmail))
            {
                mail++;
            }
            foreach (Match item in Regex.Matches(txtAge.Text, regexage))
            {
                age++;
            }
            foreach (Match item in Regex.Matches(txtphone.Text, regexphone))
            {
                phone++;
            }

            if (txtid.Text.Length >= 4 && txtid.Text != "")
            {
                ID++;
            }


           

            if ((age == 0 && txtAge.Text == "") && (mail == 0 && txtmail.Text == "") && (phone == 0 && txtphone.Text == "") && (name == 0 && txtname.Text == "") && (txtQua.Text == "") && (ID == 0))
            {
                if (age == 0 && txtAge.Text == "")
                {
                    fage.Visibility = Visibility.Visible;
                }
                if (mail == 0 && txtmail.Text == "")
                {
                    fmail.Visibility = Visibility.Visible;
                }
                if (phone == 0 && txtphone.Text == "")
                {
                    fphone.Visibility = Visibility.Visible;
                }
                if (name == 0 && txtname.Text == "")
                {
                    fname.Visibility = Visibility.Visible;
                }
                if (txtQua.Text == "")
                {
                    fqua.Visibility = Visibility.Visible;
                }
                if (ID == 0)
                {
                    fqua.Visibility = Visibility.Visible;
                }
            }
            else
            {


                if (employees == null)
                {
                    employees = new List<Employee>();
                }
                

              Employee employee1 = new Employee();
                employee1.Ename = txtname.Text;
                employee1.ID = txtid.Text;
                employee1.EAge = txtAge.Text;
                employee1.Eemail = txtmail.Text;
                employee1.Ephone = txtphone.Text;
                employee1.EQualification = txtQua.Text;
                       
                employees.Add(employee1);

               

                listview.ItemsSource = employees;
                listview.Items.Refresh();
                  

          MessageBoxResult result =     MessageBox.Show("Sucessfully Saved","SAVED",MessageBoxButton.OK,MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    txtname.Text = null; txtid.Text = null;
                    txtAge.Text = null; txtmail.Text = null;
                    txtphone.Text = null; txtQua.Text = null;
                }


            }
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnsave.Visibility = Visibility.Hidden;
            btnupdate.Visibility = Visibility.Visible;
           Employee value = (Employee) listview.SelectedItem;
            if (value != null)
            {
                txtAge.Text = value.EAge.ToString();
                txtname.Text = value.Ename.ToString();
                txtphone.Text = value.Ephone.ToString();
                txtid.Text = value.ID.ToString();
                txtmail.Text = value.Eemail.ToString();
                txtQua.Text = value.EQualification.ToString();

                txtid.IsReadOnly = true;
            }
            

            

        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if (employees == null)
            {
                employees = new List<Employee>();
            }

           
            Employee employee1 = new Employee();
            employee1.Ename = txtname.Text;
            employee1.ID = txtid.Text;
            employee1.EAge = txtAge.Text;
            employee1.Eemail = txtmail.Text;
            employee1.Ephone = txtphone.Text;
            employee1.EQualification = txtQua.Text;

            //int position = 0;

            //   for(int i = 0;i<employees.Count;i++)
            //{
            //    if (employees[i].ID == txtid.Text)
            //    {
            //        position = i;
            //    }
            //}         
               employees.RemoveAt(listview.SelectedIndex);
             employees.Add(employee1);
            
            


            listview.ItemsSource = employees;
            listview.Items.Refresh();

         MessageBoxResult result =  MessageBox.Show("Sucessfully Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                txtname.Text = null; txtid.Text = null;
                txtAge.Text = null; txtmail.Text = null;
                txtphone.Text = null; txtQua.Text = null;
            }

        }
    }
    }

