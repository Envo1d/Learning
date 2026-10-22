using ASP_HW3.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW3.Domain
{
    public class CacheLogic : ICacher
    {
        public IDictionary<object, object> Results { get; set; }
        public CacheLogic() => Results = new Dictionary<object, object>();
    }
}
