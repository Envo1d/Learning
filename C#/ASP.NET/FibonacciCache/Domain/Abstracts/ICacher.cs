using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW3.Domain.Abstracts
{
    public interface ICacher
    {
        IDictionary<object, object> Results { get; set; }
    }
}
