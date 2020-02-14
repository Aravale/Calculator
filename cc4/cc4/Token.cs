using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class Token
    {
        public string t_type;
        public string t_value;

        public Token(string tt, string tv)
        {
            t_type = tt;
            t_value = tv;
        }
    }
}
