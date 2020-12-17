using BL.Interfaces;
using BL.Models;
using BL.Services;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Expenditures.App_Start
{
    public static class LightInjectConfig
    {
        public static void Congigurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            //var config = new MapperConfiguration(cfg => cfg.AddProfiles(
            //      new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            //container.Register(c => config.CreateMapper());

            //container = BLLightInjectCongiguration.Congiguration(container);

            container.Register<IService<TransactionModel>, TransactionService>();
            container.Register<IService<CategoryModel>, CategoryService>();
            //container.Register<IEmailService, EmailService>();
            //container.Register<IArticleApiService, ArticleApiService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();
        }
    }
}