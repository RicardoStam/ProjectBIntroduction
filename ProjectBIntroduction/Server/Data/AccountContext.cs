using ProjectBIntroduction.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBIntroduction.Server.Data
{
    public class AccountContext : AbsDataContext<Account>
    {
        public AccountContext() : base("Account") 
        {
        }

        public bool UsernameExists(string username)
        {
            return Data.Where(x => x.Username == username).FirstOrDefault() != null;
        }

        public void Create(string username, string password)
        {

            Account newAccount = new() {
                Username = username,
                Password = password
            };

            Data.Add(newAccount);
            SaveChanges();
        }

        public bool Login(string username, string password)
        {
            Account account = Data.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            return account != null;
        }

        public Account GetByName(string username)
        {
            return Data.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}
