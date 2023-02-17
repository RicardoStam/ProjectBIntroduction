using AutoMapper;
using Api.Mvc.Controller;
using Api.Mvc.Model;
using Api.Mvc.View;

namespace Api
{
    public class Api
    {
        Mapper mapper;

        public Api()
        {
            // Register model conversions;
            // cfg.CreateMap<FROM, TO>(); 
            mapper = new Mapper(new MapperConfiguration(cfg => {
                    cfg.CreateMap<Account, AccountView>();
                }));
        }

        public AccountController AccountController() => new(mapper);
    }
}
