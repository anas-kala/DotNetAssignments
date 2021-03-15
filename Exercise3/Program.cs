using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/**
* @author $Anas Al Kala$
*
* @date - $time$ 
*/

namespace Exercise_1_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenMapper = new ExpressionTokenMapper();
            var tokenizer = new ExpressionTokenizer(tokenMapper);

            var parser = new ExpressionParser(tokenizer);
            while (true)
            {
                var line = Console.ReadLine();
                try
                {
                    bool ret = parser.ParseExpression(line);
                    Console.WriteLine("Expression is valid.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
