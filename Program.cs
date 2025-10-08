using System.Runtime.InteropServices;
using App;

List<Account> users = new List<Account>();
users.Add(new Account("Max", "madmax", "pass", AccountStatus.SuperAdmin));
users.Add(new Account("Hasse", "hasse1337", "pass", AccountStatus.Patient));
users.Add(new Account("Zselyke", "zse", "pass", AccountStatus.Doctor));
users.Add(new Account("Hugo", "guggan", "pass", AccountStatus.Patient));
users.Add(new Account("Mikeal", "micke", "pass", AccountStatus.Patient));
users.Add(new Account("Hassan", "hassan", "pass", AccountStatus.Patient));
users.Add(new Account("Zigge", "zigge", "pass", AccountStatus.Doctor));
users.Add(new Account("Abbe", "abbe", "pass", AccountStatus.Patient));
users.Add(new Account("Ollan", "ollan", "pass", AccountStatus.Patient));

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
            if (((Account)active_user).Status == AccountStatus.Doctor)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse\n[6]Logout");
                  }
                  else if (((Account)active_user).Status == AccountStatus.Patient)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse\n[3]Logout");
                  }
                  else if (((Account)active_user).Status == AccountStatus.SuperAdmin)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse\n[3]Logout");
                        }
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
                              Console.WriteLine($"===== Browse Patient =====");
                              int index = 1;
                              foreach (var acc in users)
                              {
                                    if (acc.Status == AccountStatus.Patient)
                                    {
                                          Console.WriteLine($"[{index}] - {acc.Name} is Patient");
                                          index++;
                                    }
                              }
                              var keyInfo = Console.ReadKey(intercept: true);
                              string input = keyInfo.KeyChar.ToString();
                              if (!int.TryParse(input, out int choice))
                              {
                                    Console.WriteLine("Invalid input...");
                                    Console.ReadLine();
                              }
                              else
                              {

                              }
                              int currentIndex = 1;
                              Account selectedPatient = null;
                              foreach (var acc in users)
                              {
                                    if (acc.Status == AccountStatus.Patient)
                                    {
                                          if (currentIndex == choice)
                                          {
                                                selectedPatient = acc;
                                                break;
                                          }
                                          currentIndex++;
                                    }
                              }
                              if (selectedPatient != null)
                              {
                                    
                                    Console.Clear();
                                    Console.WriteLine($"===== Patient {selectedPatient.Name} =====");
                                    Console.WriteLine("[1]Journal\n[2]Add prescriptions\n[3]back");
                                    var ReadPatient = Console.ReadKey(intercept: true);
                                    string ChoosenPatient = ReadPatient.KeyChar.ToString();
                                    Console.Clear();
                                    if (ChoosenPatient == "1")
                                    {
                                          Console.WriteLine($"===== {selectedPatient.Name} Journals =====");
                                          Console.ReadLine();
                                    }
                                    if (ChoosenPatient == "2")
                                    {
                                          Console.WriteLine($"===== Add {selectedPatient.Name} Medication =====");
                                          Console.ReadLine();
                                    }
                                    if (ChoosenPatient == "3")
                                    {
                                          Console.WriteLine($"backing...");
                                          Console.ReadLine();
                                          break;
                                    }
                                    Console.ReadLine();
                              }
                              else
                              {
                                    Console.WriteLine("Invalid index of patient....");
                                    Console.ReadLine();
                              }
                        }
                        else if (((Account)active_user).Status == AccountStatus.Patient)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Browse On Going Cases");
                              Console.ReadLine();
                        }
                        else if (((Account)active_user).Status == AccountStatus.SuperAdmin)
                        {
                              Console.WriteLine($"===== {((Account)active_user).Name} =====");
                              Console.WriteLine($"Browse EVERYTHING");
                              Console.ReadLine();
                        }
                              break;
                  case ConsoleKey.D6:
                              Console.WriteLine($"Logging out...");
                              active_user = null;
                              Console.ReadLine();
                              break;
                        
            }
      }
      
}


                        // case ConsoleKey.D4:
                        // if (((Account)active_user).Status == AccountStatus.Doctor)
                        // {
                        //       Console.WriteLine($"===== {((Account)active_user).Name} =====");
                        //       Console.WriteLine($"Profile");
                        //       Console.ReadLine();
                        // }
                        // else if (((Account)active_user).Status == AccountStatus.Patient)
                        // {
                        //       Console.WriteLine($"===== {((Account)active_user).Name} =====");
                        //       Console.WriteLine($"Profile");
                        //       Console.ReadLine();
                        // }
                        // else if (((Account)active_user).Status == AccountStatus.SuperAdmin)
                        // {
                        //       Console.WriteLine($"===== {((Account)active_user).Name} =====");
                        //       Console.WriteLine($"Profile");
                        //       Console.ReadLine();
                        // }
                        //       break;      