using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MoulaCodeChallenge.Models;
using Unity.Mvc3;

namespace MoulaCodeChallenge
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IDbContext, DatabaseContext>();

            return container;
        }
    }
}