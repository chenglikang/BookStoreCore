using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class UserData
    {
        string _connString = "Data Source=.;Initial Catalog=BookStore;Integrated Security=True;";

        public User SelectUser(string name,string password)
        {
            string sql = "select UserId,UserName,Avatar,Email,PhoneNumber from Users where Email = @UserName and Password = @Pass";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserName", name));
                    cmd.Parameters.Add(new SqlParameter("@Pass", password));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var user = new User();
                            user.UserId = reader.GetString(0);
                            user.UserName = reader.GetString(1);
                            user.Avatar = reader.GetString(2);
                            user.Email = reader.GetString(3);
                            user.PhoneNumber = reader.GetString(4);
                            return user;
                        }
                    }
                }
            }
            return null;
        }


        public bool AddUser(User user)
        {
            string sql = "insert into Users(UserName,Password,Email,PhoneNumber) Values(@UserName,@Password,@Email,@PhoneNumber)";
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;
                }
            }
        }
    }
}
