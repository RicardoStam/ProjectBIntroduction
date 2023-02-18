using AutoMapper;
using ProjectBIntroduction.Server.Controller;
using ProjectBIntroduction.Server.Model;
using ProjectBIntroduction.Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBIntroduction.Server
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
