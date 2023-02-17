namespace Api.Mvc.Model
{
    internal class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
         public string Password { get; set; }
    }
}
