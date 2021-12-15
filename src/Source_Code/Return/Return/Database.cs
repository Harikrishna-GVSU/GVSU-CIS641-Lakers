using Return;
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
        public static Customer GetCustomerDetails(string customerID)
        {
            Customer customer = null;
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

                            customer = new Customer(customer_ID, customer_Name, customer_Email);
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
        public static ObservableCollection<BorrowDetails> GetBorrowDetails(int customerID)
        {
            ObservableCollection<BorrowDetails> borrowDetails = new ObservableCollection<BorrowDetails>();
            try
            {
                int book_ID;
                int issue_ID;
                string book_Name;
                DateTime issue_Date;
                DateTime due_Date;
                DataTable dataTable = new DataTable();
                String queryString = @"Select i.Issue_ID,b.Book_ID,Title,Issue_Date, Due_Date from Books b, Issued_Books i";
                queryString = queryString + " where i.Book_ID = b.Book_ID and i.Customer_ID = " + customerID;
                queryString = queryString + @" and i.Issue_ID not in (select Issue_ID from Returned_Books)";
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(queryString, conn))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        conn.Open();
                        sqlDataAdapter.Fill(dataTable);
                        conn.Close();
                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                issue_ID = Int32.Parse(row["Issue_ID"].ToString());
                                book_ID = Int32.Parse(row["Book_ID"].ToString());
                                book_Name = row["Title"].ToString();
                                issue_Date = DateTime.Parse(row["Issue_Date"].ToString());
                                due_Date = DateTime.Parse(row["Due_Date"].ToString());
                                borrowDetails.Add(new BorrowDetails(issue_ID,book_ID, book_Name, issue_Date, due_Date));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return borrowDetails;
            }
            return borrowDetails;
        }
        public static bool ReturnBooks(ObservableCollection<BorrowDetails> borrowDetails, Customer customer)
        {
            try
            {
                UpdateBooksTable(borrowDetails, customer);
                UpdateIssuedBooksTable(borrowDetails, customer);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static void UpdateBooksTable(ObservableCollection<BorrowDetails> borrowDetails, Customer customer)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (BorrowDetails bookDetail in borrowDetails)
                    {
                        String queryString = @"UPDATE books SET Copies_Available = Copies_Available+1 WHERE BOOK_ID = '" + bookDetail.Book_ID + "' ";
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

        private static void UpdateIssuedBooksTable(ObservableCollection<BorrowDetails> borrowDetails, Customer customer)
        {
            DateTime returnDate = DateTime.Now;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (BorrowDetails bookDetail in borrowDetails)
                    {
                        String queryString = @"INSERT INTO Returned_Books(Issue_ID,Return_Date) ";
                        queryString = queryString + "Values(@Issue_ID, @Return_Date)";
                        using (var cmd = new SqlCommand(queryString, conn))
                        {
                            cmd.Parameters.AddWithValue("@Issue_ID", bookDetail.Issue_ID);
                            cmd.Parameters.AddWithValue("@Return_Date", returnDate);
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
