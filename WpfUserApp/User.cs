namespace WpfUserApp
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
