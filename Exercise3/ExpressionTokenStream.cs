using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public class ExpressionTokenStream : ITokenStream<ExpressionToken>
    {
        private List<ExpressionToken> _tokenBuffer;
        private int readIndex = 0;

        public ExpressionTokenStream(List<ExpressionToken> tokenBuffer)
        {
            _tokenBuffer = tokenBuffer;
        }

        public ExpressionToken Next()
        {
            return _tokenBuffer[readIndex++];
        }

        public ExpressionToken Peek()
        {
            return _tokenBuffer[readIndex];
        }

        public bool IsFinshed
        {
            get { return readIndex == _tokenBuffer.Count; }
        }

        public ExpressionToken BeforePeek()
        {
            return _tokenBuffer[readIndex - 1];
        }
    }
}
