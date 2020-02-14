using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Program
    {
        static void Main(string[] args)
        {
            string code;
            while (true)
            {
                try
                {
                    code = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
                if (code == null)
                {
                    continue;
                }
                Lexer my_lexer = new Lexer(code);
                Parser p = new Parser(my_lexer);
                Interpreter i = new Interpreter(p);
                
                int result = Convert.ToInt16(i.interpret());
                Console.WriteLine(result);
            }
        }
    }
}
