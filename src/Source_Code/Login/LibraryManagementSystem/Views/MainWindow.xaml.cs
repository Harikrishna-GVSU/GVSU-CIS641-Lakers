using System;
using System.Windows;
using System.Data.SqlClient;
using LibraryManagementSystem.Helpers;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((tbLibrarianUsername.Text != string.Empty || pbLibrarianPassword.Password != string.Empty) || (tbLibrarianUsername.Text != string.Empty && pbLibrarianPassword.Password != string.Empty))
            {
                try
                {
                    if(DatabaseHelpers.validateLibrarianLogin(tbLibrarianUsername.Text, pbLibrarianPassword.Password))
                    {
                        failedLogin.Visibility = Visibility.Hidden;
                        successfulLogin.Content = "Login Successful";
                        successfulLogin.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        successfulLogin.Visibility = Visibility.Hidden;
                        failedLogin.Content = "Invalid Credentials";
                        failedLogin.Visibility = Visibility.Visible;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Occured - "+ex.Message);
                }
            }
            else
            {
                failedLogin.Content = "Username/Password cannot be empty";
                failedLogin.Visibility = Visibility.Visible;
            }
        }
    }
}
