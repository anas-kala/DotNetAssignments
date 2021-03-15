using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public class TokenizationException : Exception
    {
        private readonly int _characterIndex;

        public int CharacterIndex
        {
            get { return _characterIndex; }
        }


        private readonly string _input;

        public string Input
        {
            get { return _input; }
        }

        public TokenizationException(string input, int characterIndex)
        {
            _input = input;
            _characterIndex = characterIndex;
        }

    }
}
