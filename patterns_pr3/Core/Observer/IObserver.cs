using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.Observer
{
    public interface IObserver
    {
        void Update(string operation, object criteria, object result);
    }
}
