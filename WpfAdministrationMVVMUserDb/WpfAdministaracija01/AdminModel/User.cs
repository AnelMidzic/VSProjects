using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace AdminModel
{
    public class User : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        private int id;
        private string userName;
        private string userPass;
        private bool? isAdmin;
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public User(string username, string password)
        {
            this.UserName = username;
            this.UserPass = password;
        }

        public User(int Id, string UserName, string UserPass, bool IsAdmin)
        {
            this.UserName = UserName;
            this.UserPass = UserPass;
            this.IsAdmin = IsAdmin;
            this.Id = Id;
        }

        public User()
        {
            UserName = "";
            UserPass = "";
            IsAdmin = null;
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;

                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName == value)
                {
                    return;
                }
                userName = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Username can't be empty.");
                    SetErrors("UserName", errors);
                    valid = false;
                }
                          
                if (valid)
                {
                    ClearErrors("UserName");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }

        public string UserPass
        {
            get { return userPass; }
            set
            {
                if (userPass == value)
                {
                    return;
                }
                userPass = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null || value == "")
                {
                    errors.Add("Password can't be empty.");
                    SetErrors("UserPass", errors);
                    valid = false;
                }
                               
                if (valid)
                {
                    ClearErrors("UserPass");
                }
                
                OnPropertyChanged(new PropertyChangedEventArgs("UserPass"));
            }
        }


        public bool? IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;

                List<string> errors = new List<string>();
                bool valid = true;

                if (value == null)
                {
                    errors.Add("Input only True or False statements.");
                    SetErrors("IsAdmin", errors);
                    valid = false;
                }

                if (valid)
                {
                    ClearErrors("IsAdmin");
                }

                OnPropertyChanged(new PropertyChangedEventArgs("IsAdmin"));
            }

        }


        public static object ConfigurationMenager { get; private set; }
               


        

        public static User GetUserFromResultSet(SqlDataReader reader)
        {
            User user = new User((int)reader["Id"], (string)reader["UserName"], (string)reader["UserPass"], (bool)reader["IsAdmin"]);
            return user;
        }
               

        public void UpdateUser()
        {
            using (SqlConnection konekcija = new SqlConnection())
            {
                konekcija.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                konekcija.Open();

                SqlCommand command = new SqlCommand("UPDATE Users SET UserName=@UserName, UserPass=@UserPass, IsAdmin=@IsAdmin WHERE Id=@Id", konekcija);

                SqlParameter userNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                userNameParam.Value = this.UserName;

                SqlParameter passNameParam = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                passNameParam.Value = this.UserPass;

                SqlParameter isAdminParam = new SqlParameter("@IsAdmin", SqlDbType.Bit);
                isAdminParam.Value = this.IsAdmin;

                SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 11);
                myParam.Value = this.Id;

                command.Parameters.Add(userNameParam);
                command.Parameters.Add(passNameParam);
                command.Parameters.Add(isAdminParam);
                command.Parameters.Add(myParam);

                int rows = command.ExecuteNonQuery();

            }
        }

        public void Insert()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Users(UserName, UserPass, IsAdmin) VALUES(@UserName, @UserPass, @IsAdmin); SELECT IDENT_CURRENT('Users');", conn);

                SqlParameter userNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                userNameParam.Value = this.UserName;

                SqlParameter passNameParam = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                passNameParam.Value = this.UserPass;

                SqlParameter isAdminParam = new SqlParameter("@IsAdmin", SqlDbType.Bit);
                isAdminParam.Value = this.IsAdmin;

                command.Parameters.Add(userNameParam);
                command.Parameters.Add(passNameParam);
                command.Parameters.Add(isAdminParam);

                var id = command.ExecuteScalar();

                if (id != null)
                {
                    this.Id = Convert.ToInt32(id);
                }                                
            }
        }

        public void Save()
        {
            if (Id == 0)
            {
                Insert();
            }
            else
            {
                UpdateUser();
            }
        }

        public void DeleteUser()
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Users WHERE id=@Id", conn);

                SqlParameter myParam = new SqlParameter("@Id", SqlDbType.Int, 11);
                myParam.Value = this.Id;

                command.Parameters.Add(myParam);

                int rows = command.ExecuteNonQuery();

            }
        }

        public bool IsUserAdmin()
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnString"].ToString();
                conn.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserName=@UserName AND UserPass=@UserPass AND IsAdmin = 1", conn);

                SqlParameter userNameParam = new SqlParameter("@UserName", SqlDbType.NVarChar);
                userNameParam.Value = this.UserName;

                SqlParameter passNameParam = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                passNameParam.Value = this.UserPass;

                command.Parameters.Add(userNameParam);
                command.Parameters.Add(passNameParam);

                var user = command.ExecuteScalar();

                return user != null ? true : false;
            }
        }

        public bool HasErrors
        {
            get
            {
                return (errors.Count > 0);
            }
        }
                

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {            
            errors.Remove(propertyName);
           
            errors.Add(propertyName, propertyErrors);
            
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            
            errors.Remove(propertyName);
            
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
               
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                
                return (errors.Values);
            }
            else
            {
                
                if (errors.ContainsKey(propertyName))
                {
                    return (errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }

        public User Clone()
        {
            User clonedUser = new User();
            clonedUser.UserName = this.UserName;
            clonedUser.UserPass = this.UserPass;
            clonedUser.IsAdmin = this.IsAdmin;
            clonedUser.Id = this.Id;

            return clonedUser;
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User objUser = (User)obj;

            if (objUser.Id == this.Id) return true;

            return false;
        }

        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }       
        
    }
}