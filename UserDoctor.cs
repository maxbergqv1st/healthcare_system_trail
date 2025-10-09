namespace App;

class Doctor : IUser
{
      public string Name { get; set; }
      public string Username { get; set; }
      public string _password { get; set; }
      public AccountStatus Status { get; set; }
      public Doctor(string name, string username, string password , AccountStatus status)
      {
            Name = name;
            Username = username;
            _password = password;
            Status = status;
      }
      public bool TryLogin(string username, string password)
      {
            return Username == Username && password == _password;
      }
}