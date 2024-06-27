--导入luanet.dll，语法格式：require “luanet”
require "luanet"

--获取程序集，语法格式：luanet.load_assembly（“程序集名”）
luanet.load_assembly("three")
luanet.load_assembly("System")

--获取类型，语法格式：变量名= luanet.import_type（“程序集名.类名”）
Calc = luanet.import_type("three.Calc")
Console = luanet.import_type("System.Console")

print(Calc.name)
print(Calc.Jia(10, 20))
print(Calc.Jian(100, 20))
print(Calc.Cheng(50, 2))
print(Calc.Chu(10, 2))

Console.WriteLine("mkcode")
str = Console.ReadLine()
Console.WriteLine("您输入的是" .. str)
