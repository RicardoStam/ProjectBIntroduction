namespace Api.Mvc.Model
{
    internal class Account
    {
        internal Guid Id { get; set; } = Guid.NewGuid();
        internal string Username { get; set; }
        internal string Password { get; set; }
    }
}
