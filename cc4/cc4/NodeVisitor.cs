using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    
    class NodeVisitor
    {
        public object visit(AST node)
        {
            string methodname = "visit_" + node.GetType().ToString().Remove(0,4);
            //object visitor = typeof(Interpreter).GetMethod(methodname).Invoke(node,null);
            
            return typeof(Interpreter).GetMethod(methodname).Invoke(this,new object[] {node});                   

        }

        public void error()
        {
            throw new Exception("Method Not Found!");
        }
    }
}
