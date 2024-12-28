using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_pr3.Core.FakeDataGenerators
{
    public interface IFakeDataGenerator<T>
    {
        T GetFakeData();

    }
}
