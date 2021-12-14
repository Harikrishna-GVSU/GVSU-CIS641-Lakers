using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Helpers
{
    public class DatabaseHelpers
    {
        public static string connectionString = @"Server=DESKTOP-9B0EB6M\SQLEXPRESS; Database=LMS_DB; Integrated Security=true";
        public static bool validateLibrarianLogin(String uname, String pwd)
        {
            try
            {
                String queryString = @"Select * from Admin_Logins where username = '" + uname + "' AND password = '" + pwd + "'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        return true;
                    }
                    reader.Close();
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
