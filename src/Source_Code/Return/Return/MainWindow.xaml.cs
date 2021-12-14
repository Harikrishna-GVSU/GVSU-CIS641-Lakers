using Borrow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Return
{
    public class Customer
    {
        public int Customer_ID;
        public string Customer_Name;
        public string Customer_Email;

        public Customer(int cust_ID, string cust_name, string cust_email)
        {
            Customer_ID = cust_ID;
            Customer_Name = cust_name;
            Customer_Email = cust_email;
        }
    }

    public class BorrowDetails : INotifyPropertyChanged
    {
        private int book_ID;
        public int Book_ID
        {
            get { return book_ID; }
            set { book_ID = value; }
        }
        private string book_Name;
        public string Book_Name
        {
            get { return book_Name; }
            set { book_Name = value; }
        }
        private DateTime issue_Date;
        public DateTime Issue_Date
        {
            get { return issue_Date; }
            set { issue_Date = value; }
        }
        private DateTime due_Date;
        public DateTime Due_Date
        {
            get { return due_Date; }
            set { due_Date = value; }
        }
        private int issue_ID;
        public int Issue_ID
        {
            get { return issue_ID; }
            set { issue_ID = value; }
        }
        public BorrowDetails(int issue_ID,int bookID, string bookName, DateTime issueDate, DateTime dueDate)
        {
            Issue_ID = issue_ID;
            Book_ID = bookID;
            Book_Name = bookName;
            Issue_Date = issueDate;
            Due_Date = dueDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeFieldsInvisible();
        }
        Customer customer;
        public ObservableCollection<BorrowDetails> borrowDetails = new ObservableCollection<BorrowDetails>();
        List<int> selectedBookIDs;
        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (customerIDTextBox.Text != "")
            {
                customer = Database.GetCustomerDetails(customerIDTextBox.Text);
                if (customer != null)
                {
                    customerNameTextBox.Text = customer.Customer_Name;
                    customerNameLabel.Visibility = Visibility.Visible;
                    customerNameTextBox.Visibility = Visibility.Visible;
                    getBorrowDetailsButton.Visibility = Visibility.Visible;
                }
                else
                {
                    infoMessageBarLabel.Content = "";
                    errorMessageBarLabel.Content = "Please enter a valid Customer ID";
                }
            }
            else
            {
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "Please enter a Book ID to Search";
            }
        }
        private void MakeFieldsInvisible()
        {
            customerNameLabel.Visibility = Visibility.Hidden;
            customerNameTextBox.Visibility = Visibility.Hidden;
            getBorrowDetailsButton.Visibility = Visibility.Hidden;
            dgBookCollection.Visibility = Visibility.Hidden;
            processReturn.Visibility = Visibility.Hidden;
        }
        private void BtnGetBorrowDetails_Click(object sender, RoutedEventArgs e)
        {
            borrowDetails = Database.GetBorrowDetails(customer.Customer_ID);
            if (borrowDetails?.Count > 0)
            {
                dgBookCollection.ItemsSource = borrowDetails;
                dgBookCollection.Visibility = Visibility.Visible;
                processReturn.Visibility = Visibility.Visible;
            }
            else
            {
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "No Books due for "+customer.Customer_Name;
            }
        }
        private void dgBook_RowBookEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            FrameworkElement element = dgBookCollection.Columns[3].GetCellContent(e.Row);
            if (element.GetType() == typeof(CheckBox))
            {
                if (((CheckBox)element).IsChecked == true)
                {
                    FrameworkElement cellEmpNo = dgBookCollection.Columns[0].GetCellContent(e.Row);
                    int bookID = Convert.ToInt32(((TextBlock)cellEmpNo).Text);
                    selectedBookIDs.Add(bookID);
                }
            }
        }

        private void BtnDeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedBookIDs?.Count > 0)
                {
                    int count = 0;
                    foreach (int bookID in selectedBookIDs)
                    {
                        BorrowDetails emp = (from ep in borrowDetails
                                             where ep.Book_ID == bookID
                                             select ep).First();
                        borrowDetails.Remove(emp);
                        count++;
                    }
                    MessageBox.Show(count + "Row's Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAcceptReturn_Click(object sender, RoutedEventArgs e)
        {
            if (Database.ReturnBooks(borrowDetails, customer))
            {
                errorMessageBarLabel.Content = "";
                infoMessageBarLabel.Content = "Succesfully returned books borrowed by "+customer.Customer_Name;

                //SendEmailToCustomer();
            }
            else
            {
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "Failed to return books borrowed by "+customer.Customer_Name;
            }
        }
    }
}
