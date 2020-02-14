using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Num : AST
    {
        public Token token { get; set; }
        public int Value { get; set; }
        public Num(Token token)
        {
            this.token = token;
            Value = int.Parse(token.t_value);
        }
    }
}
