using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Exceptions
{
    public class ExpressionParser
    {
        private ITokenizer<ExpressionToken> _tokenizer;
        private int _parenthesesCounter = 0;

        public ExpressionParser(ITokenizer<ExpressionToken> tokenizer)
        {
            _tokenizer = tokenizer;
        }

        // This is a very simple parser, that only verifies if the input is correct. 
        //
        public bool ParseExpression(string input)
        {
            var tokenStream = _tokenizer.CreateTokenStream(input);

            if (tokenStream.Peek().TokenType != EExpressionTokenType.Digit &&
                tokenStream.Peek().TokenType != EExpressionTokenType.ParenthesesOpen &&
                tokenStream.Peek().TokenType != EExpressionTokenType.End)
            {
                var peeked = tokenStream.Peek();
                throw new ParseException(String.Format("Parser error at position {0}: An expression must start with a digit or \"(\"", peeked.StartIndex + 1)); // unmatched )
            }

            while (tokenStream.IsFinshed == false)
            {
                var token = tokenStream.Next();
                switch (token.TokenType)
                {

                    case EExpressionTokenType.ParenthesesOpen: // next token must be a digit or another paranthesis open
                        _parenthesesCounter++;
                        {
                            var peeked = tokenStream.Peek();
                            if (peeked.TokenType != EExpressionTokenType.Digit && peeked.TokenType != EExpressionTokenType.ParenthesesOpen)
                            {
                                throw new Exception();
                            }
                        }

                        break;
                    case EExpressionTokenType.ParenthesesClose: // next token must be an operator or end or paranthesis close
                        _parenthesesCounter--;
                        if (_parenthesesCounter < 0)
                        {
                            int countClosingParethesis = input.Count(f => f == ')');
                            int countOpeneninggParethesis = input.Count(f => f == '(');
                            if (countClosingParethesis != countOpeneninggParethesis)
                            {
                                int i = 1;
                                var peeked = tokenStream.Peek();
                                string s = input[peeked.StartIndex - i].ToString();
                                while (s.Equals(" "))
                                {
                                    s = input[peeked.StartIndex - ++i].ToString();
                                }
                                throw new ParseException(String.Format("Parser error at position {0}: unmatched \")\" in expression", peeked.StartIndex - 1)); // unmatched )
                            }
                            //int i = 1;
                            //var peeked = tokenStream.Peek();
                            //string s = input[peeked.StartIndex - i].ToString();
                            //while (s.Equals(" "))
                            //{
                            //    s = input[peeked.StartIndex - ++i].ToString();
                            //}
                            //throw new ParseException(String.Format("Unexpected input after \"{0}\" at position {1}: expected \")\",\"+\",\"-\",\"*\",\"\\\" or end of expression but found \"(\". ", s, peeked.StartIndex));
                        }
                        {
                            var peeked = tokenStream.Peek();
                            if (peeked.TokenType != EExpressionTokenType.Div && peeked.TokenType != EExpressionTokenType.Mult &&
                                peeked.TokenType != EExpressionTokenType.Add && peeked.TokenType != EExpressionTokenType.Sub &&
                                peeked.TokenType != EExpressionTokenType.End && peeked.TokenType != EExpressionTokenType.ParenthesesClose)
                            {

                                peeked = tokenStream.Peek();
                                throw new ParseException(String.Format("Parser error at position {0}: unmatched \")\" in expression", peeked.StartIndex)); // unmatched )
                            }
                        }
                        break;
                    case EExpressionTokenType.Digit: // next token must be parantheses close or an operation or end
                        {
                            var peeked = tokenStream.Peek();

                            if (peeked.TokenType != EExpressionTokenType.Add &&
                                peeked.TokenType != EExpressionTokenType.Sub &&
                                peeked.TokenType != EExpressionTokenType.Mult &&
                                peeked.TokenType != EExpressionTokenType.Div &&
                                peeked.TokenType != EExpressionTokenType.ParenthesesClose &&
                                peeked.TokenType != EExpressionTokenType.End)
                            {
                                int i = 1;
                                string s = input[peeked.StartIndex - i].ToString();
                                while (s.Equals(" "))
                                {
                                    s = input[peeked.StartIndex - ++i].ToString();
                                }
                                throw new ParseException(String.Format("Unexpected input after \"{0}\" at position {1}: expected \")\",\"+\",\"-\",\"*\",\"\\\" or end of expression but found \"(\". ", s, peeked.StartIndex));
                            }
                        }
                        break;

                    case EExpressionTokenType.Add: // next token must be parantheses or digit
                    case EExpressionTokenType.Sub:
                    case EExpressionTokenType.Mult:
                    case EExpressionTokenType.Div:
                        {
                            var peeked = tokenStream.Peek();
                            if (
                                peeked.TokenType != EExpressionTokenType.ParenthesesOpen &&
                                peeked.TokenType != EExpressionTokenType.Digit)
                            {
                                throw new Exception();
                            }
                        }
                        break;
                }
            }

            if (_parenthesesCounter != 0)
            {
                int countClosingParethesis = input.Count(f => f == ')');
                int countOpeneninggParethesis = input.Count(f => f == '(');
                if (countClosingParethesis != countOpeneninggParethesis)
                {
                    throw new ParseException(String.Format("Parser error at position {0}: unmatched \"(\" in expression", input.Length)); // unclosed parantheses
                }
            }

            return true;
        }
    }

}
