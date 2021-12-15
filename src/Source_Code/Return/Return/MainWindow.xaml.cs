using Borrow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public event PropertyChangedEventHandler PropertyChanged;

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
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            MakeFieldsInvisible();
            BorrowDetails = new ObservableCollection<BorrowDetails>();
            this.DataContext = this;
            dgBookCollection.ItemsSource = BorrowDetails;
        }
        Customer customer;
        private ObservableCollection<BorrowDetails> borrowDetails;
        public ObservableCollection<BorrowDetails> BorrowDetails
        {
            set 
            { 
                borrowDetails = value;
                RaisePropertyChanged("BorrowDetails");
            }

            get
            {
                return borrowDetails;
            }
        }
        public List<int> selectedBookIDs = new List<int>();
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
            BorrowDetails = Database.GetBorrowDetails(customer.Customer_ID);
            if (BorrowDetails?.Count > 0)
            {
                processReturn.IsEnabled = true;
                dgBookCollection.ItemsSource = BorrowDetails;
                dgBookCollection.Visibility = Visibility.Visible;
                processReturn.Visibility = Visibility.Visible;
            }
            else
            {
                DeleteBooks();
                processReturn.IsEnabled = false;
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "No Books due for "+customer.Customer_Name;
            }
        }

        private void DeleteBooks()
        {
            try
            {
                foreach (BorrowDetails book in BorrowDetails)
                    selectedBookIDs.Add(book.Book_ID);

                if (selectedBookIDs?.Count > 0)
                {
                    int count = 0;
                    foreach (int bookID in selectedBookIDs)
                    {
                        BorrowDetails emp = (from ep in BorrowDetails
                                             where ep.Book_ID == bookID
                                             select ep).First();
                        BorrowDetails.Remove(emp);
                        count++;
                    }
                }
                selectedBookIDs = new List<int>();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void BtnAcceptReturn_Click(object sender, RoutedEventArgs e)
        {
            if (Database.ReturnBooks(BorrowDetails, customer))
            {
                errorMessageBarLabel.Content = "";
                infoMessageBarLabel.Content = "Succesfully returned books borrowed by "+customer.Customer_Name;

                //SendEmailToCustomer();
                DeleteBooks();
            }
            else
            {
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "Failed to return books borrowed by "+customer.Customer_Name;
            }
        }

        private void SendEmailToCustomer()
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("library.grandrapids@gmail.com");
                message.To.Add(new MailAddress(customer.Customer_Email));
                message.Subject = "Information of books returned by " + customer.Customer_Name;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = GetHTMLMailString();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("library.grandrapids@gmail.com", "Kittu@190797");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending email failed \n" + "Exception " + ex.Message);
            }
        }

        private string GetHTMLMailString()
        {
            try
            {
                string messageBody = "<font>Hello " + customer.Customer_Name + ",</font><br/><br/>";
                messageBody = messageBody + "Following are the books returned by you to Grand Rapids Library.<br/><br/>";
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "Book Name" + htmlTdEnd;
                messageBody += htmlTdStart + "Issue Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Due Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Return Date" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;
                foreach (BorrowDetails book in BorrowDetails)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + book.Book_Name + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + book.Issue_Date + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + book.Due_Date + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + DateTime.Now + htmlTdEnd;
                    messageBody = messageBody + htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;
                messageBody = messageBody + "<br/><br/>Best Regards,<br/>Admin,<br/>Grand Rapids Library.";
                return messageBody;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
