using DataLayer.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Database.DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                });
                context.SaveChanges();

                var users = context.Users.ToList();
                Console.ReadKey();

                Console.WriteLine("Enter username:");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                var password = Console.ReadLine();
                var ret = from u in users
                          where u.Names == username && u.Password == password
                          select u;
                if (ret.Count() > 0)
                {
                    Console.WriteLine("Valid User!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password!");
                }
            }
        }
    }
}
