using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public enum EExpressionTokenType
    {
        ParenthesesOpen,
        ParenthesesClose,
        Add,
        Div,
        Sub,
        Mult,
        Digit, // the first digit of a string of digits
        Whitespace,
        InvalidToken,
        End
    };

    public class ExpressionToken 
    {
        private EExpressionTokenType _tokenType;
        public EExpressionTokenType TokenType
        {
            get
            {
                return _tokenType;
            }
        }

        private string _data;

        public string Data
        {
            get { return _data; }
        }

        private int _startIndex;
        public int StartIndex
        {
            get { return _startIndex; }
        }

        public static ExpressionToken CreateToken(int startIndex, string data, EExpressionTokenType tokenType)
        {
            return new ExpressionToken(startIndex, data, tokenType);
        }

        private ExpressionToken(int startIndex, string data, EExpressionTokenType tokenType)
        {
            _startIndex = startIndex;
            _data = data;
            _tokenType = tokenType;
        }

        public override string ToString()
        {
            return $"Position: {_startIndex}, Type: {TokenType}, Data: {Data}";
        }
    }


}
