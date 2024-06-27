using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace three
{
    class Program
    {
        static void Main(string[] args)
        {
            Lua lua = new Lua();
            lua.DoFile("MkCode.lua");


            Console.ReadKey();
        }
    }
}
