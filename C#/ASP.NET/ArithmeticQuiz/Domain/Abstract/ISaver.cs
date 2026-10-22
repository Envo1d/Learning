using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW2.Domain.Abstract
{
    public interface ISaver
    {
        Dictionary<string,int> Results { get; set; }
    }
}
