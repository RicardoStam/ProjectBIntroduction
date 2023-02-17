using AutoMapper;
using Api.Mvc.Data;
using Api.Mvc.View;
using System.Text.Json;

namespace Api.Mvc.Controller
{
    public class AccountController
    {
        private readonly AccountContext context;
        private readonly IMapper mapper;

        public AccountController(IMapper _mapper)
        {
            context = new AccountContext();
            mapper = _mapper;
        }

        public bool Create(string username, string password)
        {
            if (context.UsernameExists(username)) return false;
            context.Create(username, password);
            return true;
        }

        public bool Login(string username, string password)
        {
            return context.Login(username, password);
        }

        public string Get(string username) 
        {
            AccountView view = mapper.Map<AccountView>(context.GetByName(username));

            return JsonSerializer.Serialize(view);
        }
    }
}
