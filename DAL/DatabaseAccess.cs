using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAL
{   public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {

            string conn = File.ReadAllText("connection.txt");
            return new SqlConnection(conn);
        }
    }
    public class DatabaseAccess
    {
        public static string CheckLoginDTO(TaiKhoan taikhoan)
        {
            string role = null;
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("proc_login", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Phải đúng tên tham số như trong stored procedure
                cmd.Parameters.AddWithValue("@Username", taikhoan.Username);
                cmd.Parameters.AddWithValue("@Password", taikhoan.Password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role = reader.GetString(0);
                    }
                }
                else
                {
                    role = "Sai";
                }

                reader.Close();
                conn.Close();
            }
            return role;
        }
        public static bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("proc_change_password", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@OldPassword", oldPassword);
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                    SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    int result = (int)cmd.Parameters["@Result"].Value;
                    return result == 1;
                }
            }
        }

        

    }
}
