using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string password;
        public string Names { get; set; }
        public string Password {
            get
            {
                char[] charArray = password.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            set
            {
                char[] charArray = value.ToCharArray();
                Array.Reverse(charArray);
                password = new string(charArray);
            }
        }
        public UserRolesEnum Role {  get; set; }
        public string? FacNum { get; set; }
        public string? Email { get; set; }

        virtual public int Id { get; set; }
        public DateTime Expires {  get; set; }
    }
}
