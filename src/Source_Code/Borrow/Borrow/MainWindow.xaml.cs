using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

namespace Borrow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Book : INotifyPropertyChanged
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
            private string author_Names;
            public string Author_Names
            {
                get { return author_Names; }
                set { author_Names = value; }
            }
            private int copies_Available;
            public int Copies_Available
            {
                get { return copies_Available; }
                set { copies_Available = value; }
            }

            public Book(int book_ID, string book_Name, string author_Names, int copies_Available)
            {
                Book_ID = book_ID;
                Book_Name = book_Name;
                Author_Names = author_Names;
                Copies_Available = copies_Available;
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

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

        public ObservableCollection<Book> booksCollection = new ObservableCollection<Book>();
        List<int> selectedBookIDs;
        Book currentBook;
        Customer customer;
        public int BookID;
        public string BookName;
        public string AuthorNames;
        public MainWindow()
        {
            InitializeComponent();
            MakeFieldsInvisible();
            this.DataContext = booksCollection;
            dgBookCollection.ItemsSource = booksCollection;
            selectedBookIDs = new List<int>();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (bookIDTextBox.Text != "")
            {
                currentBook = Database.GetBookDetails(bookIDTextBox.Text);
                if (currentBook != null)
                {
                    bookNameTextBox.Text = currentBook.Book_Name;
                    authorNamesTextBox.Text = currentBook.Author_Names;
                    copiesAvailableTextBox.Text = currentBook.Copies_Available.ToString();
                    MakeFieldsVisible();
                    if (currentBook.Copies_Available == 0)
                    {
                        addBookButton.IsEnabled = false;
                    }
                    else
                    {
                        addBookButton.IsEnabled = true;
                    }
                }
                else
                {
                    addBookButton.IsEnabled = false;
                    ClearContentOfFields();
                    infoMessageBarLabel.Content = "";
                    errorMessageBarLabel.Content = "Please enter a valid Book ID";
                }
            }
            else
            {
                ClearContentOfFields();
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "Please enter a Book ID to Search";
            }
        }

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            foreach (Book book in booksCollection)
            {
                if (book.Book_ID == currentBook.Book_ID)
                {
                    infoMessageBarLabel.Content = "";
                    errorMessageBarLabel.Content = "Book already added to cart";
                    return;
                }
            }

            booksCollection.Add(currentBook);
            errorMessageBarLabel.Content = "";
            infoMessageBarLabel.Content = "Book added to cart successfully";
            checkoutButton.IsEnabled = true;
            dgBookCollection.Visibility = Visibility.Visible;
            deleteBooksButton.Visibility = Visibility.Visible;
            customerIDLabel.Visibility = Visibility.Visible;
            customerIDTextBok.Visibility = Visibility.Visible;
            customerSearchButton.Visibility = Visibility.Visible;
        }

        private void BtnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (Database.IssueBooks(booksCollection, customer))
            {
                errorMessageBarLabel.Content = "";
                infoMessageBarLabel.Content = "Succesfully issued books to "+customer.Customer_Name;

                //SendEmailToCustomer();
            }
            else
            {
                infoMessageBarLabel.Content = "";
                errorMessageBarLabel.Content = "Failed to issue books to "+customer.Customer_Name;
            }
        }

        private void BtnCustomerSearch_Click(object sender, RoutedEventArgs e)
        {
            if (customerIDTextBok.Text != "")
            {
                customer = Database.GetCustomerDetails(customerIDTextBok.Text);
                if(customer!=null)
                {
                    errorMessageBarLabel.Content = "";
                    customerNameTextBox.Text = customer.Customer_Name;
                    customerNameLabel.Visibility = Visibility.Visible;
                    customerNameTextBox.Visibility = Visibility.Visible;
                    checkoutButton.Visibility = Visibility.Visible;
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
                errorMessageBarLabel.Content = "Please enter a Customer ID";
            }
        }

        private void MakeFieldsVisible()
        {
            bookNameLabel.Visibility = Visibility.Visible;
            authorNameLabel.Visibility = Visibility.Visible;
            copiesAvailablLabel.Visibility = Visibility.Visible;
            bookNameTextBox.Visibility = Visibility.Visible;
            authorNamesTextBox.Visibility = Visibility.Visible;
            copiesAvailableTextBox.Visibility = Visibility.Visible;
            addBookButton.Visibility = Visibility.Visible;
        }

        private void MakeFieldsInvisible()
        {
            bookNameLabel.Visibility = Visibility.Hidden;
            authorNameLabel.Visibility = Visibility.Hidden;
            copiesAvailablLabel.Visibility = Visibility.Hidden;
            bookNameTextBox.Visibility = Visibility.Hidden;
            authorNamesTextBox.Visibility = Visibility.Hidden;
            copiesAvailableTextBox.Visibility = Visibility.Hidden;
            addBookButton.Visibility = Visibility.Hidden;
            checkoutButton.Visibility = Visibility.Hidden;
            dgBookCollection.Visibility = Visibility.Hidden;
            deleteBooksButton.Visibility = Visibility.Hidden;
            customerIDLabel.Visibility = Visibility.Hidden;
            customerIDTextBok.Visibility = Visibility.Hidden;
            customerSearchButton.Visibility = Visibility.Hidden;
            customerNameLabel.Visibility = Visibility.Hidden;
            customerNameTextBox.Visibility = Visibility.Hidden;
        }

        private void ClearContentOfFields()
        {
            bookNameTextBox.Text = "";
            authorNamesTextBox.Text = "";
            copiesAvailableTextBox.Text = "";
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
                if (selectedBookIDs.Count > 0)
                {
                    int count = 0;
                    foreach (int bookID in selectedBookIDs)
                    {
                        Book emp = (from ep in booksCollection
                                    where ep.Book_ID == bookID
                                    select ep).First();
                        booksCollection.Remove(emp);
                        count++;
                    }
                    MessageBox.Show(count + "Book's Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                message.Subject = "Information of books borrowed by "+customer.Customer_Name;
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
                MessageBox.Show("Sending email failed \n"+"Exception "+ex.Message);
            }
        }

        private string GetHTMLMailString()
        {
            try
            {
                string messageBody = "<font>Hello "+customer.Customer_Name+",</font><br/><br/>";
                messageBody = messageBody + "Following are the books borrowed by you at Grand Rapids Library.<br/><br/>";
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
                messageBody += htmlTdStart + "Author(s) " + htmlTdEnd;
                messageBody += htmlTdStart + "Issue Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Due Date" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd; 
                foreach(Book book in booksCollection)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + book.Book_Name + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + book.Author_Names + htmlTdEnd; 
                    messageBody = messageBody + htmlTdStart + DateTime.Now + htmlTdEnd; 
                    messageBody = messageBody + htmlTdStart + DateTime.Now.AddDays(15) + htmlTdEnd; 
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
    }
}
