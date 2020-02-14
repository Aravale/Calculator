using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class BinOp : AST
    {
        public AST Left { get; set; }
        public Token Op { get; set; }
        public AST Right { get; set; }
        public BinOp(AST left, Token op, AST right)
        {
            Left = left;
            Op = op;
            Right = right;
        }
    }
}
