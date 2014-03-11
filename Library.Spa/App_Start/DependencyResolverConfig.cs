//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;
//using Contract.Contracts;
//using Library.EF_DataLayer;
//using Library.EF_DataLayer.Repositories;
//using Ninject;
//using Ninject.Parameters;

//namespace Library.Spa
//{
//    public class DependencyResolverConfig
//    {
//        public static void RegisterDependecy()
//        {
//            IKernel kernel = new StandardKernel();
//            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>)).WithConstructorArgument("context", new LibraryContext());
//            DependencyResolver.SetResolver(new MyResolver(kernel));
//        }
//    }

//    public class MyResolver : IDependencyResolver
//    {
//        private readonly IKernel _kernel;

//        public MyResolver(IKernel kernel)
//        {
//            _kernel = kernel;
//        }

//        public object GetService(Type serviceType)
//        {
//            return _kernel.TryGet(serviceType, new IParameter[0]);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return _kernel.GetAll(serviceType, new IParameter[0]);
//        }
//    }
//}