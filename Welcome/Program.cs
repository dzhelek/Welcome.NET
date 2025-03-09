using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome;

class Program {
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var user = new User();
        user.Names = "Yoan Dzhelekarski";
        user.Password = "password";
        user.Role = UserRolesEnum.ADMIN;

        var model = new UserViewModel(user);
        var view = new UserView(model);

        view.Display();
    }
}
