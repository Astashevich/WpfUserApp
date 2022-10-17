namespace WpfUserApp
{
    public class User
    {
        private int id { get; set; }
        private string login { get; set; }
        private string password { get; set; }
        private string email { get; set; }

        public User() { }

        public User(string login, string email, string password)
        {
            this.login = login;
            this.email = email;
            this.password = password;
        }
    }
}
