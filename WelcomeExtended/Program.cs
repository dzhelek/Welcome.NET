using Welcome.Model;
using Welcome.Others;
using Welcome.ViewModel;
using Welcome.View;

using WelcomeExtended.Others;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                /*
                var user = new User
                {
                    Names = "Yoan Dzhelekarski",
                    Password = "123456",
                    Role = UserRolesEnum.STUDENT,
                };

                var viewModel = new UserViewModel(user);

                var view = new UserView(viewModel);

                view.Display();

                view.DisplayError();
                */
                UserData userData = new UserData();

                User studentUser = new User
                {
                    Names = "Yoan Dzhelekarski",
                    Password = "123456",
                    Role = UserRolesEnum.STUDENT,
                };
                User studentUser2 = new User()
                {
                    Names = "Miro Minkov",
                    Password = "654321",
                    Role = UserRolesEnum.STUDENT,
                };
                User teacher = new User()
                {
                    Names = "Ivan Ivanov",
                    Password = "1234",
                    Role = UserRolesEnum.PROFESSOR,
                };
                User admin = new User()
                {
                    Names = "Admin Adminov",
                    Password = "12345",
                    Role = UserRolesEnum.ADMIN,
                };

                userData.AddUser(studentUser);
                userData.AddUser(studentUser2);
                userData.AddUser(teacher);
                userData.AddUser(admin);

                Console.WriteLine("Enter username: ");
                var user = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                var pass = Console.ReadLine();

                UserHelper.ValidateCredentials(userData, user, pass);
                var data = UserHelper.GetUser(userData, user, pass);
                if (data == null)
                {
                    Console.WriteLine("User not found");
                }
                else
                {
                    Console.WriteLine(UserHelper.ToString(data));
                }

            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
