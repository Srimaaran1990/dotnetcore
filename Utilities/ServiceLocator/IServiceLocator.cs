 
using System;

namespace Common.ServiceLocator
{
    public interface IServiceLocator<IService>
    {
        IService GetService();
        IService GetServiceByType(Type type);
        void RegisterService<T>() where T : class, IService;
        void UnRegisterService();
    }
}