using System.Runtime.InteropServices;
using App;

List<Account> users = new List<Account>();
users.Add(new Account("Max", "madmax", "pass", AccountStatus.SuperAdmin));
users.Add(new Account("Hasse", "hasse1337", "pass", AccountStatus.Patient));

IUser active_user = null;
bool running = true;
bool found = false;

while (running)
{
      Console.Clear();
      if (active_user == null)
      {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("[1] Login \n[2] Quit");
            var Read = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (Read.Key)
            {
                  case ConsoleKey.D1:
                        Console.WriteLine("===== LOGIN =====");
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        foreach (var u in users)
                        {
                              if (u.Username == username && u._password == password)
                              {
                                    active_user = u;
                                    Console.Clear();
                                    Console.WriteLine("Logging in...");
                                    found = true;
                              }
                        }
                        if(active_user == null)
                              {
                                    Console.WriteLine("Non existing user...");
                              }
                        break;
                  case ConsoleKey.D2:
                        Console.WriteLine("Quiting...");
                        running = false;
                        break;
                  default:
                        Console.WriteLine("Invalid choice...");
                        break;
            }
            Console.ReadLine();
      }
      else
      {
            Console.WriteLine($"===== {((Account)active_user).Status} =====");
            Console.WriteLine("[1]Profile\n[2]Browse\n[3]Logout");
            var Read = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (Read.Key)
            {
                  case ConsoleKey.D1:
                        if (((Account)active_user).Status == AccountStatus.Doctor)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                        else if (((Account)active_user).Status == AccountStatus.Patient)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                        else if (((Account)active_user).Status == AccountStatus.SuperAdmin)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                              break;
                  case ConsoleKey.D2:
                        if (((Account)active_user).Status == AccountStatus.Doctor)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Browse");
                              Console.ReadLine();
                        }
                        else if (((Account)active_user).Status == AccountStatus.Patient)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Browse");
                              Console.ReadLine();
                        }
                        else if (((Account)active_user).Status == AccountStatus.SuperAdmin)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Browse");
                              Console.ReadLine();
                        }
                              break;
                        case ConsoleKey.D3:
                              Console.WriteLine($"Logging out...");
                              active_user = null;
                              Console.ReadLine();
                              break;
                        
            }
      }
      
}
