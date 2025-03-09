using DataLayer.Database;
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
                /*
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                */


                while (true)
                {
                    Console.WriteLine("Menu:\n0. exit\n1. login\n2. list users\n3. add user\n4. delete user");
                    var key = Console.ReadKey();
                    var users = context.Users.ToList();
                    switch (key.KeyChar)
                    {
                        case '0':
                            return;
                        case '1':
                            Login(users);
                            break;
                        case '2':
                            ListUsers(users);
                            break;
                        case '3':
                            AddUser(context);
                            break;
                        case '4':
                            DeleteUser(context);
                            break;
                    }
                }

            }
        }

        private static void DeleteUser(DatabaseContext context)
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            var user = context.Users.Where(u => u.Names == username).FirstOrDefault();
            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        private static void AddUser(DatabaseContext context)
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            context.Add<DatabaseUser>(new DatabaseUser()
            {
                Names = username,
                Password = password,
                Expires = DateTime.Now,
                Role = Welcome.Others.UserRolesEnum.STUDENT
            });
        }

        private static void ListUsers(List<DatabaseUser> users)
        {
            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} {user.Names} {user.Role}");
            }
        }

        private static void Login(List<DatabaseUser> users)
        {
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
