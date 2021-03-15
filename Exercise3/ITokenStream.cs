using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public interface ITokenStream<T>
    {
        T Next();
        T Peek();

        T BeforePeek();

        bool IsFinshed { get; }
    }
}
