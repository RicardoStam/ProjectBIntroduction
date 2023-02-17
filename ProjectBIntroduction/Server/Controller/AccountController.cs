using AutoMapper;
using ProjectBIntroduction.Server.Data;
using ProjectBIntroduction.Server.Model;
using ProjectBIntroduction.Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBIntroduction.Server.Controller
{
    internal class AccountController
    {
        private readonly AccountContext context;
        private readonly IMapper mapper;
        public AccountController(IMapper _mapper)
        {
            context = new AccountContext();
            mapper = _mapper;
        }

        internal bool Create(string username, string password)
        {
            if (context.UsernameExists(username)) return false;
            context.Create(username, password);
            return true;
        }

        internal bool Login(string username, string password)
        {
            return context.Login(username, password);
        }

        internal AccountView Get(string username) 
        {
            return mapper.Map<AccountView>(context.GetByName(username));
        }
    }
}
