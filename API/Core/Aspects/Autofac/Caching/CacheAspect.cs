using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//gün olarak ayarladık MemoryCacheManager de
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//ReflectedType.FullName=namespace adı ve class adı  
            var arguments = invocation.Arguments.ToList();//invocation=methodun kendisi
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            var cacheVarmi = _cacheManager.IsAdd(key);
            var cacheIcerigi = _cacheManager.Get(key);

            if (_cacheManager.IsAdd(key))// IsAdd varmı yokmu kontrol ediyor
            {
                invocation.ReturnValue = _cacheManager.Get(key);//varsa cache den getir.
                return;
            }
            invocation.Proceed();//methodu çalıştır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
