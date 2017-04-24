using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExampleAspMVCApp;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Neat.CQRSLite.Contract.Helpers;
using Neat.CQRSLite.Contract.Commands;
using Neat.CQRSLite.Contract.Events;
using Neat.CQRSLite.Contract.Queries;
using Neat.CQRSLite.CQRS;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly:
    WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ExampleAspMVCApp
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //bind all buss
            kernel.Bind<IQueryBus>().To<QueryBus>();
            kernel.Bind<IEventBus>().To<EventBus>();
            kernel.Bind<ICommandBus>().To<CommandBus>();

            //bind multibuss
            kernel.Bind<Neat.CQRSLite.Contract.IAssistant Assistant>().ToSelf();


            // bind resolving functions 
            kernel.Bind<Func<Type, IQueryPerformer>>()
                .ToMethod(c => (T => (IQueryPerformer)c.Kernel.Get(T)));
            kernel.Bind<Func<Type, ICommandHandler>>()
                .ToMethod(c => (T => (ICommandHandler)c.Kernel.Get(T)));
            kernel.Bind<Func<Type, ICommandValidator>>()
                .ToMethod(c => (T => (ICommandValidator)c.Kernel.Get(T)));
            kernel.Bind<Func<Type, IEnumerable<IEventHandler>>>()
                .ToMethod(c => (T => c.Kernel.GetAll(T).Cast<IEventHandler>()));


            //bind all handlers
            kernel.Bind(x =>
            {
                x
                    .FromThisAssembly().SelectAllClasses()
                    .InheritedFrom(typeof(ICommandHandler<>))
                    .Join.FromThisAssembly().SelectAllClasses()
                    .InheritedFrom(typeof(ICommandValidator<>))
                    .Join.FromThisAssembly().SelectAllClasses()
                    .InheritedFrom(typeof(IEventHandler<>))
                    .Join.FromThisAssembly().SelectAllClasses()
                    .InheritedFrom(typeof(IQueryPerformer<,>))
                    .BindSingleInterface()
                    .Configure(b => b.InTransientScope());
            });
        }
    }
}