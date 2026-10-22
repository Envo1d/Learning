using ASP_HW3.Domain.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW3.Domain
{
    public class CacheMiddleware
    {
        readonly private RequestDelegate next;
        readonly private ICacher cacher;
        public CacheMiddleware(RequestDelegate next, ICacher cacher)
        {
            this.next = next;
            this.cacher = cacher;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/fibonacci/index")))
            {
                Microsoft.AspNetCore.Http.PathString numn;
                context.Request.Path.StartsWithSegments(new Microsoft.AspNetCore.Http.PathString("/fibonacci/Index"), out numn);
                int num = Convert.ToInt32(numn.ToString().Remove(0,1));
                if (!cacher.Results.Keys.Contains(num))
                    cacher.Results.Add(num, await FibonacciAsync(num));
                await next.Invoke(context);
            }
            else if (context.Request.Path.StartsWithSegments(new PathString("/fibonacci")))
            {
                int num = Convert.ToInt32(context.Request.Query["num"]);
                if (!cacher.Results.Keys.Contains(num))
                    cacher.Results.Add(num, await FibonacciAsync(num));
                await next.Invoke(context);
            }
            else
                await next.Invoke(context);
        }
        public async Task<int> FibonacciAsync(int num)
        {
           return await Task.Run(() => Fibonacci(num));
        }
        private int Fibonacci(int num)
        {
            int a = 0, b = 1, c = 0;
            for (int i = 1; i < num; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}
