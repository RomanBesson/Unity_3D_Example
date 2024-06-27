using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface; //引入命名空间.

namespace one
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个Lua解析器对象.
            Lua lua = new Lua();

            lua["name"] = "Monkey";
            lua["age"] = 720;

            Console.WriteLine(lua["name"]);
            Console.WriteLine(lua["age"]);

            Console.ReadKey();
        }
    }
}
