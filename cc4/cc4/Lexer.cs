using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Lexer
    {
        string code;
        int pos;
        char? cc;
        Token token;

        public Lexer(string cd)
        {
            code = cd;
            pos = 0;
            cc = code[pos];
        }

        public void error()
        {
            throw new Exception("Invalid Character or Symbol");
        }

        public void advance()
        {
            pos += 1;
            if (pos > code.Length - 1)
            {
                cc = null;
            }
            else
            {
                cc = code[pos];
            }
        }

        public void skip_white_spaces()
        {
            while (cc != null && cc == ' ')
            {
                advance();
            }
        }

        public string integer()
        {
            string my_int = "";
            while (cc != null && (cc >= '0' && cc <= '9'))
            {
                my_int += cc;
                advance();
            }

            return my_int;
        }

        public Token get_next_token()
        {
            while (cc != null)
            {
                if (cc == ' ')
                {
                    skip_white_spaces();
                    continue;
                }
                if (cc >= '0' && cc <= '9')
                {
                    token = new Token("INT", integer());
                    return token;
                }
                if (cc == '*')
                {
                    token = new Token("MUL", "*");
                    advance();
                    return token;
                }
                if (cc == '/')
                {
                    token = new Token("DIV", "/");
                    advance();
                    return token;
                }
                if (cc == '+')
                {
                    token = new Token("ADD", "+");
                    advance();
                    return token;
                }
                if (cc == '-')
                {
                    token = new Token("SUB", "-");
                    advance();
                    return token;
                }
                if (cc == '(')
                {
                    token = new Token("LP", "(");
                    advance();
                    return token;
                }
                if (cc == ')')
                {
                    token = new Token("RP", ")");
                    advance();
                    return token;
                }
                error();
            }
            token = new Token("EOF", null);
            return token;
        }
    }
}
