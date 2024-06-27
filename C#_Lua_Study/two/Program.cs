using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuaInterface;

namespace two
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化一个lua解析器对象.
            Lua lua = new Lua();

            //1.变量的声明与访问.
            lua.DoString("name = 'Monkey' age = 72 address = 'BeiJing'");
            lua.DoString("print(name, age, address)");

            //2.for 循环语句.
            lua.DoString(@"for i = 0, 10, 1 do 
                            print(i) 
                        end");

            //3.函数的定义与调用.
            lua.DoString(@"
                function Show()
                    print('lua show Function')
                end
                Show()
            ");

            //4.table 数组声明与访问.
            lua.DoString("myArray = {'AAA', 'BBB', 'CCC', 'DDD'}");
            lua.DoString(@"
                for i = 1, table.getn(myArray), 1 do
                    print(myArray[i])
                end
            ");

            lua.DoFile("Monkey.lua");
            string webName = lua.GetString("webName");
            string webURL = lua.GetString("webURL");
            Console.WriteLine(webName + ".." + webURL);

            double num = lua.GetNumber("num");
            Console.WriteLine(num);

            LuaFunction LuaHello = lua.GetFunction("LuaHello");
            LuaHello.Call();
            LuaFunction Add = lua.GetFunction("Add");
            Object[] obj = Add.Call(100, 20);
            Console.WriteLine(obj[0]);

            Console.ReadKey();
        }
    }
}
