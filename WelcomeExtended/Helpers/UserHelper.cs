using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    internal static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"User: {user.Names}, Role: {user.Role}, Expires: {user.Expires}";
        }

        public static void ValidateCredentials(this UserData userData, string name, string password)
        {
            if (name == null || password == null)
            {
                throw new ArgumentNullException("Name or password is null");
            }
            if (userData.ValidateUser(name, password))
            {
                Console.WriteLine("User is valid");
            }
            else
            {
                Console.WriteLine("User is not valid");
            }
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
