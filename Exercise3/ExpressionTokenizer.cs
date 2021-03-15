using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public class ExpressionTokenizer : ITokenizer<ExpressionToken>
    {
        private ITokenMapper<EExpressionTokenType> _tokenMapper;
        private int _currentIndex = 0;
        private string _inputData;


        public ExpressionTokenizer(ITokenMapper<EExpressionTokenType> tokenMapper)
        {
            _tokenMapper = tokenMapper;
        }

        private bool IsFinished
        {
            get
            {
                return (_currentIndex == _inputData.Length);
            }
        }

        public ITokenStream<ExpressionToken> CreateTokenStream(string input)
        {
            _inputData = input;
            _currentIndex = 0;
            var tokenList = new List<ExpressionToken>();
            ExpressionToken token;
            do
            {
                token = nextToken();
                tokenList.Add(token);
            } while (token.TokenType != EExpressionTokenType.End);
            return new ExpressionTokenStream(tokenList);
        }
        private ExpressionToken nextToken()
        {
            while (IsFinished == false)
            {
                ExpressionToken token = fetchNextToken();
                if (token.TokenType != EExpressionTokenType.Whitespace)
                {
                    return token;
                }
            }
            return ExpressionToken.CreateToken(_currentIndex - 1, "", EExpressionTokenType.End);
        }

        private ExpressionToken fetchNextToken()
        {
            char cur = _inputData[_currentIndex];
            var token = _tokenMapper.Map(cur);
            _currentIndex++;

            switch (token)
            {
                case EExpressionTokenType.ParenthesesOpen:
                    return ExpressionToken.CreateToken(_currentIndex - 1, "(", EExpressionTokenType.ParenthesesOpen);
                case EExpressionTokenType.ParenthesesClose:
                    return ExpressionToken.CreateToken(_currentIndex - 1, ")", EExpressionTokenType.ParenthesesClose);
                case EExpressionTokenType.Digit:
                    return tokenizeNumber(cur);
                case EExpressionTokenType.Whitespace:
                    return ExpressionToken.CreateToken(_currentIndex - 1, " ", EExpressionTokenType.Whitespace);
                case EExpressionTokenType.Add:
                    return ExpressionToken.CreateToken(_currentIndex - 1, "+", EExpressionTokenType.Add);
                case EExpressionTokenType.Sub:
                    return ExpressionToken.CreateToken(_currentIndex - 1, "-", EExpressionTokenType.Sub);
                case EExpressionTokenType.Mult:
                    return ExpressionToken.CreateToken(_currentIndex - 1, "*", EExpressionTokenType.Mult);
                case EExpressionTokenType.Div:
                    return ExpressionToken.CreateToken(_currentIndex - 1, "/", EExpressionTokenType.Div);
            }

            throw new ParseException(String.Format("Error at position {0}: \"{1}\" is not a valid input", _inputData.IndexOf(cur)+1,cur)); // unmatched )
        }

        private ExpressionToken tokenizeNumber(char digit)
        {
            int startIndex = _currentIndex - 1;
            var tokenSB = new StringBuilder();
            tokenSB.Append(digit);

            while (IsFinished == false)
            {
                char cur = _inputData[_currentIndex];
                var token = _tokenMapper.Map(cur);

                if (token == EExpressionTokenType.Digit)
                {
                    tokenSB.Append(cur);
                    _currentIndex++;
                }
                else
                {
                    break;
                }
            }
            return ExpressionToken.CreateToken(startIndex, tokenSB.ToString(), EExpressionTokenType.Digit);
        }
    }
}
