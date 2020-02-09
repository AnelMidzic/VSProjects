using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModel
{
    public class UserCollection : ObservableCollection<User>
    {
        public static UserCollection GetUsers()
        {
            UserCollection users = new UserCollection();
            User user = null;

            using (SqlConnection konekcija = new SqlConnection())
            {
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                konekcija.Open();

                SqlCommand komanda = new SqlCommand("SELECT Id, UserName, UserPass, IsAdmin FROM Users", konekcija);

                using (SqlDataReader reader = komanda.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = User.GetUserFromResultSet(reader);
                                                
                        users.Add(user);
                    }

                }
            }
            return users;
        }
    }
}
