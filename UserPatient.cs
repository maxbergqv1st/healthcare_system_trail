namespace App;

public class JournalList
{
      public string Description { get; set; }
      public List<string> Meds { get; set; } = new List<string>();
}
class Patient : IUser
{
      public string Name { get; set; }
      public string Username { get; set; }
      public string _password { get; set; }
      public List<JournalList> Journals { get; set; } = new List<JournalList>();
      
      public AccountStatus Status { get; set; }
      public Patient(string name, string username, string password , AccountStatus status)
      {
            Name = name;
            Username = username;
            _password = password;
            Status = status;
      }
      public bool TryLogin(string username, string password)
      {
            return Username == username && _password == password;
      }
}