using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //methot ismini alıyor
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//üstündeki aspectleri buluyor
            classAttributes.AddRange(methodAttributes);//kaçtane aspect varsa hepsini ekliyor
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));//her zaman loglama çalışacak.

            return classAttributes.OrderBy(x => x.Priority).ToArray();//bunları tek tek çalıştırıyor
        }
    }

}
