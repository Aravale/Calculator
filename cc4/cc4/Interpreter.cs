using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Interpreter:NodeVisitor
    {
        Parser Parser;


        public Interpreter(Parser parser)
        {
            Parser = parser;
        }

        public int visit_BinOp(BinOp node)
        {
            if (node.Op.t_type=="ADD")
            {
                return Convert.ToInt32(visit(node.Left)) + Convert.ToInt32(visit(node.Right));
            }
            else if (node.Op.t_type == "SUB")
                {
                    return Convert.ToInt32(visit(node.Left)) - Convert.ToInt32(visit(node.Right));
                }
            else if (node.Op.t_type == "MUL")
            {
                return Convert.ToInt32(visit(node.Left)) * Convert.ToInt32(visit(node.Right));
            }
            else if (node.Op.t_type == "DIV")
            {
                return Convert.ToInt32(visit(node.Left)) / Convert.ToInt32(visit(node.Right));
            }
            return 0;
        }

        public int visit_Num(Num node)
        {
            return node.Value;
        }

        public int interpret()
        {
            AST tree = new AST();
            tree = Parser.parse();
            return (int)visit(tree);
        }
    
}
}
