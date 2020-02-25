

using System;

namespace Common.ServiceLocator
{
    public static class ServiceLocator<IService>
    {
        private static IServiceLocator<IService> _serviceLocator;

        public static IServiceLocator<IService> Locator
        {
            get
            {
                if (_serviceLocator == null) _serviceLocator = new ServiceLocatorImpl<IService>();
                return _serviceLocator;
            }
            set { _serviceLocator = value; }
        }


        /// <summary>
        ///   Get IService instance
        /// </summary>
        /// <returns></returns>
        public static IService GetService()
        {
            return Locator.GetService();
        }


        /// <summary>
        /// </summary>
        /// <param name = "type"> an implementation type of this interface </param>
        /// <returns></returns>
        public static IService GetServiceByType(Type type)
        {
            return Locator.GetServiceByType(type);
        }


        /// <summary>
        ///   Register IService
        /// </summary>
        /// <param name = "service">A physical instance of IService</param>
        public static void RegisterService<T>() where T : class, IService
        {
            Locator.RegisterService<T>();
        }


        /// <summary>
        ///   UnRegister IService
        /// </summary>
        /// <param name = "service">A physical instance of IService</param>
        public static void UnRegisterService()
        {
            Locator.UnRegisterService();
        }
    }
}