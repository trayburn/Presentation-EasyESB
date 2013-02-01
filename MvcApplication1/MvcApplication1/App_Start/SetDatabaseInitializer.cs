using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using MvcApplication1.Models;
using Highway.Data.EntityFramework.Contexts;
using System.Web.Mvc;

[assembly: WebActivator.PostApplicationStartMethod(typeof(MvcApplication1.App_Start.SetDatabaseInitializer), "PostStartup")]
namespace MvcApplication1.App_Start
{
    public static class SetDatabaseInitializer
    {
        public static void PostStartup()
        {
#pragma warning disable 618
            var initializer = IoC.Container.Resolve<IDatabaseInitializer<EntityFrameworkContext>>();
#pragma warning restore 618
            Database.SetInitializer(initializer);
        }
    }
}
