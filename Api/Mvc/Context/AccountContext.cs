using Api.Mvc.Model;

namespace Api.Mvc.Context
{
    internal class AccountContext : AbsDataContext<Account>
    {
        internal AccountContext() : base("Account") 
        {
        }

        internal bool UsernameExists(string username)
        {
            return Data.Where(x => x.Username == username).FirstOrDefault() != null;
        }

        internal void Create(string username, string password)
        {

            Account newAccount = new() {
                Id = Guid.NewGuid(),
                Username = username,
                Password = password
            };

            Data.Add(newAccount);
            SaveChanges();
        }

        internal bool Login(string username, string password)
        {
            Account account = Data.Where(x => x.Username == username && x.Password == password).First();
            return account != null;
        }

        internal Account GetByName(string username)
        {
            return Data.Where(x => x.Username == username).First();
        }
    }
}
