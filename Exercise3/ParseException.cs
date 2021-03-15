using System;
using System.IO;

namespace Exercise_1_Exceptions
{
    public class ParseException : Exception
    {
        public ParseException(string message): base(message) { }
    }
}
