using System.Web.Mvc;
using BibliotecaUteq.BAL;
using BibliotecaUteq.Controllers;
using BibliotecaUteq.DAL;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace BibliotecaUteq
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ILibrosBo, LibrosBo>();
            container.RegisterType<ILibrosDao, LibrosDao>();
            container.RegisterType<IController, HomeController>("Home");
            container.RegisterType<IController, LibrosController>("Libros");

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}