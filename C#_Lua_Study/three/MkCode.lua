--����luanet.dll���﷨��ʽ��require ��luanet��
require "luanet"

--��ȡ���򼯣��﷨��ʽ��luanet.load_assembly��������������
luanet.load_assembly("three")
luanet.load_assembly("System")

--��ȡ���ͣ��﷨��ʽ��������= luanet.import_type����������.��������
Calc = luanet.import_type("three.Calc")
Console = luanet.import_type("System.Console")

print(Calc.name)
print(Calc.Jia(10, 20))
print(Calc.Jian(100, 20))
print(Calc.Cheng(50, 2))
print(Calc.Chu(10, 2))

Console.WriteLine("mkcode")
str = Console.ReadLine()
Console.WriteLine("���������" .. str)
