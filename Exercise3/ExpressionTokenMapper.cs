using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercise_1_Exceptions
{
    public class ExpressionTokenMapper : ITokenMapper<EExpressionTokenType>
    {
        private Dictionary<char, EExpressionTokenType> _tokenMap = new Dictionary<char, EExpressionTokenType>()
            // This is an initialization constructor. It makes the dictionary way more readable and managable. 
            //
            {
                {'(', EExpressionTokenType.ParenthesesOpen},
                {')', EExpressionTokenType.ParenthesesClose},
                {'/', EExpressionTokenType.Div},
                {'-', EExpressionTokenType.Sub},
                {'*', EExpressionTokenType.Mult},
                {'+', EExpressionTokenType.Add},
                {'0', EExpressionTokenType.Digit},
                {'1', EExpressionTokenType.Digit},
                {'2', EExpressionTokenType.Digit},
                {'3', EExpressionTokenType.Digit},
                {'4', EExpressionTokenType.Digit},
                {'5', EExpressionTokenType.Digit},
                {'6', EExpressionTokenType.Digit},
                {'7', EExpressionTokenType.Digit},
                {'8', EExpressionTokenType.Digit},
                {'9', EExpressionTokenType.Digit},
                {' ', EExpressionTokenType.Whitespace}
            };

        public EExpressionTokenType Map(char input)
        {
            if (_tokenMap.ContainsKey(input))
            {
                return _tokenMap[input];
            }
            return EExpressionTokenType.InvalidToken;
        }
    }
}
