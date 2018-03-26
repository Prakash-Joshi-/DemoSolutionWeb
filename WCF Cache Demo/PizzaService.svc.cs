using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_Cache_Demo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PizzaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PizzaService.svc or PizzaService.svc.cs at the Solution Explorer and start debugging.
    public class PizzaService : IPizzaService
    {
        private const string CacheKey = "availablePizzas";

        private SlowRepository repository;

        public PizzaService()
        {
            this.repository = new SlowRepository();
        }

        public IEnumerable GetAvailablePizzas()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheKey))
                return (IEnumerable)cache.Get(CacheKey);
            else
            {
                IEnumerable availablePizzas = repository.GetPizzas();

                // Store data in the cache
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(CacheKey, availablePizzas, cacheItemPolicy);

                return availablePizzas;
            }
        }
    }
    public class SlowRepository
    {
        public IEnumerable GetPizzas()
        {
            Thread.Sleep(10000);

            return new List<string>() { "Hawaii", "Pepperoni", "Bolognaise" };
        }
    }
}
