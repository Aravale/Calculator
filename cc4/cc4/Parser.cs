using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Parser
    {
        Lexer lexer;
        Token ct;
        Token token;
        public Parser(Lexer lex)
        {
            lexer = lex;
            ct = lexer.get_next_token();
        }

        public void error()
        {
            throw new Exception("Invalid Syntax");
        }

        public void verify(string tType)
        {
            if (ct.t_type == tType)
            {
                this.ct = this.lexer.get_next_token();
            }
            else
            {
                this.error();
            }
        }

        public AST factor()
        {
            token = ct;
            AST node;
            if (token.t_type == "INT")
            {
                verify("INT");

                return new Num(token);
            }
            else if (token.t_type == "LP")
            {
                verify("LP");
                node = expr();
                verify("RP");
                return node;
            }
            else
            {
                error();
            }

            return null;
        }

        public AST term()
        {
            AST node = factor();
            while (ct.t_type == "MUL" || ct.t_type == "DIV")
            {
                token = ct;
                if (ct.t_type == "MUL")
                {
                    verify("MUL");
                }
                else if (ct.t_type == "DIV")
                {
                    verify("DIV");
                }
                node = new BinOp(node, token, factor());
            }
            return node;
        }

        public AST expr()
        {
            AST node = term();
            while (ct.t_type == "ADD" || ct.t_type == "SUB")
            {
                token = ct;
                if (ct.t_type == "ADD")
                {
                    verify("ADD");
                }
                else if (ct.t_type == "SUB")
                {
                    verify("SUB");
                }
                node = new BinOp(node, token, term());
            }
            return node;
        }

        public AST parse()
        {
            AST expr = this.expr();
            return expr;
        }
    }
}
