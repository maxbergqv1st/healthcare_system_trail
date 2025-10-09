using System.Runtime.InteropServices;
using App;

List<SuperAdmin> users_admin = new List<SuperAdmin>();
users_admin.Add(new SuperAdmin("Max", "madmax", "pass", AccountStatus.SuperAdmin));

List<Doctor> users_doctor = new List<Doctor>();
users_doctor.Add(new Doctor("Zselyke", "zse", "pass", AccountStatus.Doctor));
users_doctor.Add(new Doctor("Zigge", "zigge", "pass", AccountStatus.Doctor));

List<Patient> users_patient = new List<Patient>();
users_patient.Add(new Patient("Hasse", "hasse1337", "pass",AccountStatus.Patient));
users_patient.Add(new Patient("Hugo", "guggan", "pass", AccountStatus.Patient));
users_patient.Add(new Patient("Mikeal", "micke", "pass", AccountStatus.Patient));
users_patient.Add(new Patient("Hassan", "hassan", "pass", AccountStatus.Patient));
users_patient.Add(new Patient("Abbe", "abbe", "pass", AccountStatus.Patient));
users_patient.Add(new Patient("Ollan", "ollan", "pass", AccountStatus.Patient));

List<IUser> users = new List<IUser>();
users.AddRange(users_admin);
users.AddRange(users_doctor);
users.AddRange(users_patient);

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
            Console.WriteLine($"===== {((IUser)active_user).Status} =====");
            if (((IUser)active_user).Status == AccountStatus.Doctor)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse Patients\n[6]Logout");
                  }
                  else if (((IUser)active_user).Status == AccountStatus.Patient)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse\n[6]Logout");
                  }
                  else if (((IUser)active_user).Status == AccountStatus.SuperAdmin)
                  {
                        Console.WriteLine("[1]Profile\n[2]Browse\n[6]Logout");
                        }
            var Read = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (Read.Key)
            {
                  case ConsoleKey.D1:
                        if (((IUser)active_user).Status == AccountStatus.Doctor)
                        {
                              Console.WriteLine($"===== {((IUser)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                        else if (((IUser)active_user).Status == AccountStatus.Patient)
                        {
                              Console.WriteLine($"===== {((IUser)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                        else if (((IUser)active_user).Status == AccountStatus.SuperAdmin)
                        {
                              Console.WriteLine($"===== {((IUser)active_user).Name} =====");
                              Console.WriteLine($"Profile");
                              Console.ReadLine();
                        }
                              break;
                  case ConsoleKey.D2:
                        if (((IUser)active_user).Status == AccountStatus.Doctor)
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
                              int currentIndex = 1;
                              IUser selectedPatient = null;
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
                                    Console.WriteLine("[1]Case\n[2]Medicin\n[3]Journal\n[6]back");
                                    var ReadPatient = Console.ReadKey(intercept: true);
                                    string ChoosenIndex = ReadPatient.KeyChar.ToString();
                                    Console.Clear();
                                    if (ChoosenIndex == "1")
                                    {
                                          if (selectedPatient is Patient ChoosenPatient)
                                          {
                                                Console.WriteLine($"===== {ChoosenPatient.Name} Case =====");
                                                
                                                Console.Write("Description: ");
                                                string jour_input = Console.ReadLine();

                                                Console.Write("\nMedicin: ");
                                                string meds_input = Console.ReadLine();
                                                
                                                JournalList newJournal = new JournalList
                                                {
                                                      Description = jour_input,
                                                      Meds = new List<string> { meds_input }
                                                };
                                                ChoosenPatient.Journals.Add(newJournal);
                                                break;
                                          }
                                    }
                                    if (ChoosenIndex == "2")
                                    {
                                          if (selectedPatient is Patient ChoosenPatient)
                                          {
                                                Console.WriteLine($"===== {ChoosenPatient.Name} Medication =====");
                                                if (ChoosenPatient.Journals.Count == 0)
                                                {
                                                      Console.WriteLine("No Journals Yet.");
                                                }
                                                
                                                Console.ReadLine();
                                                break;
                                          }
                                    }
                                    if (ChoosenIndex == "3")
                                    {
                                          if (selectedPatient is Patient ChoosenPatient)
                                          {
                                                Console.WriteLine($"===== {selectedPatient.Name} Journals =====");
                                                
                                                if (ChoosenPatient.Journals.Count == 0)
                                                {
                                                      Console.WriteLine("No Journals Yet.");
                                                }
                                                else
                                                {
                                                      int journalIndex = 1;
                                                      foreach (var journal in ChoosenPatient.Journals)
                                                      {
                                                            Console.WriteLine($" [{journalIndex}] - {journal.Description}");
                                                            if (journal.Meds.Count > 0)
                                                            {
                                                                  Console.WriteLine("Medications:");
                                                                  foreach (var med in journal.Meds)
                                                                  {
                                                                        Console.WriteLine($" - {med}");
                                                                  }
                                                            }
                                                      }
                                                }
                                                Console.ReadLine();
                                                break;
                                          }
                                    }
                                    if (ChoosenIndex == "6")
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
                        else if (((IUser)active_user).Status == AccountStatus.Patient)
                        {
                              Console.WriteLine($"===== {((IUser)active_user).Name} =====");
                              Console.WriteLine($"Browse On Going Cases");
                              Console.ReadLine();
                        }
                        else if (((IUser)active_user).Status == AccountStatus.SuperAdmin)
                        {
                              Console.WriteLine($"===== {((IUser)active_user).Name} =====");
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

// As a user, I need to be able to log in.

// As a user, I need to be able to log out.

// As a user, I need to be able to request registration as a patient.

// As an admin with sufficient permissions, I need to be able to give admins the permission to handle the permission system, in fine granularity.

// As an admin with sufficient permissions, I need to be able to assign admins to certain regions.

// As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations.

// As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations.

// As an admin with sufficient permissions, I need to be able to give admins the permission to add locations.

// As an admin with sufficient permissions, I need to be able to give admins the permission to create accounts for personnel.

// As an admin with sufficient permissions, I need to be able to give admins the permission to view a list of who has permission to what.

// As an admin with sufficient permissions, I need to be able to add locations.

// As an admin with sufficient permissions, I need to be able to accept user registration as patients.

// As an admin with sufficient permissions, I need to be able to deny user registration as patients.

// As an admin with sufficient permissions, I need to be able to create accounts for personnel.

// As an admin with sufficient permissions, I need to be able to view a list of who has permission to what.

// As personnel with sufficient permissions, I need to be able to view a patients journal entries.

// As personnel with sufficient permissions, I need to be able to mark journal entries with different levels of read permissions.

// As personnel with sufficient permissions, I need to be able to register appointments.

// As personnel with sufficient permissions, I need to be able to modify appointments.

// As personnel with sufficient permissions, I need to be able to approve appointment requests.

// As personnel with sufficient permissions, I need to be able to view the schedule of a location.

// As a patient, I need to be able to view my own journal.

// As a patient, I need to be able to request an appointment.

// As a logged in user, I need to be able to view my schedule.