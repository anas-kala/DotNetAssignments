using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public interface ITokenizer<T>
    {
        ITokenStream<T> CreateTokenStream(string input);

    }
}
