namespace App;
public interface IUser
{
      string Name { get; set; }
      string Username { get; set; }
      string _password { get; set; }
      AccountStatus Status { get; set; }
      public bool TryLogin(string username, string password);
}