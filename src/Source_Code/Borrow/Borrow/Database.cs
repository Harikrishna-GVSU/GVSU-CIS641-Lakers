using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Borrow
{
    class Database
    {
        public static string connectionString = @"Server=DESKTOP-9B0EB6M\SQLEXPRESS; Database=LMS_DB; Integrated Security=true";
        public static MainWindow.Book GetBookDetails(string bookID)
        {
            MainWindow.Book book = null;
            try
            {
                int book_ID;
                string book_Name;
                string author_Names;
                int copiesAvailable;
                DataTable dataTable = new DataTable();
                String queryString = @"SELECT * FROM Books WHERE Book_ID = '" + bookID + "' ";
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(queryString, conn))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        conn.Open();
                        sqlDataAdapter.Fill(dataTable);
                        conn.Close();
                        if (dataTable.Rows.Count == 1)
                        {
                            book_ID = Int32.Parse(dataTable.Rows[0]["Book_ID"].ToString());
                            book_Name = dataTable.Rows[0]["Title"].ToString();
                            author_Names = dataTable.Rows[0]["Author_Names"].ToString();
                            copiesAvailable = Int32.Parse(dataTable.Rows[0]["Copies_Available"].ToString());

                            book = new MainWindow.Book(book_ID, book_Name, author_Names, copiesAvailable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return book;
            }
            return book;
        }
        public static MainWindow.Customer GetCustomerDetails(string customerID)
        {
            MainWindow.Customer customer = null;
            try
            {
                int customer_ID;
                string customer_Name;
                string customer_Email;
                DataTable dataTable = new DataTable();
                String queryString = @"SELECT * FROM Customer WHERE Customer_ID = '" + customerID + "' ";
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(queryString, conn))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        conn.Open();
                        sqlDataAdapter.Fill(dataTable);
                        conn.Close();
                        if (dataTable.Rows.Count == 1)
                        {
                            customer_ID = Int32.Parse(dataTable.Rows[0]["Customer_ID"].ToString());
                            customer_Name = dataTable.Rows[0]["First_Name"].ToString() + " " + dataTable.Rows[0]["Last_Name"].ToString();
                            customer_Email = dataTable.Rows[0]["Email"].ToString();

                            customer = new MainWindow.Customer(customer_ID, customer_Name, customer_Email);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return customer;
            }
            return customer;
        }

        public static bool IssueBooks(ObservableCollection<MainWindow.Book> books, MainWindow.Customer customer)
        {
            try
            {
                UpdateBooksTable(books, customer);
                UpdateIssuedBooksTable(books, customer);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        private static void UpdateBooksTable(ObservableCollection<MainWindow.Book> books, MainWindow.Customer customer)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (MainWindow.Book book in books)
                    {
                        String queryString = @"UPDATE books SET Copies_Available = Copies_Available-1 WHERE BOOK_ID = '" + book.Book_ID + "' ";
                        using (var cmd = new SqlCommand(queryString, conn))
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void UpdateIssuedBooksTable(ObservableCollection<MainWindow.Book> books, MainWindow.Customer customer)
        {
            DateTime issuedDate = DateTime.Now;
            DateTime dueDate = issuedDate.AddDays(15);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (MainWindow.Book book in books)
                    {
                        String queryString = @"INSERT INTO Issued_Books(Customer_ID, Book_ID, Issue_Date, Due_Date) ";
                        queryString = queryString+"Values(@Customer_ID, @Book_ID, @Issue_Date, @Due_Date)";
                        using (var cmd = new SqlCommand(queryString, conn))
                        {
                            cmd.Parameters.AddWithValue("@Customer_ID", customer.Customer_ID);
                            cmd.Parameters.AddWithValue("@Book_ID", book.Book_ID);
                            cmd.Parameters.AddWithValue("@Issue_Date", issuedDate);
                            cmd.Parameters.AddWithValue("@Due_Date", dueDate);
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
