@echo off
cls
:: System Parameter
set xpProgName=DosCalculator
set xpProgVer=1.0.0.1
echo.
title 欢迎使用Taoether编制的小计算器(DCal.bat) %xpProgName%_V%xpProgVer%
color 1f
rem mode con cols=80 lines=40
echo 欢迎使用Taoether编制的小计算器(DCal.bat) %xpProgName%_V%xpProgVer%
if /I {%1}=={} goto Main
if /I "%1"=="C" goto Main
if /I "%1"=="H" goto help
if /I "%1"=="V" goto ver
:Ver
echo.
rem 重要声明：
rem 本程序由陶永利编写，您可以任意传播，但请不要删除以下信息!
rem 如用于商业用途，请与作者联系。
echo Version:
echo ------------------------------
echo Program: %xpProgName%
echo Author: Taoether
echo Version: %xpProgVer%
echo IssueTime: 09:01 2009-2-18
echo UpdateTime: 9:01 2009-6-5
echo Email: taoether@gmail.com
echo HomePage: www.taoyoyo.net
echo ------------------------------
echo.
echo Version Log:
echo -----------------------------------------
echo Ver. Date. Log.
echo -----------------------------------------
echo V1000 20090218 New program issue.
echo V1001 20090605 Add new function: Clear.
echo ...
echo -----------------------------------------
if /I {%1}=={} goto Main
if /I "%1"=="H" goto end
if /I "%1"=="V" goto end
:help
echo.
echo Help:
echo -----------------------------------------
echo 此程序为计算器，输入计算表达式后，返回计算结果。
echo.
echo DCal [M]
echo.
echo [M]: 指定运行的模式
echo =空，进入计算模式
echo =C，清屏；
echo =H，显示帮助；
echo =V，显示版本；
echo.
echo 说明:
echo.
echo 1,在计算模式下：
echo 直接输入算式，回车返回计算结果；
echo 按E，退出程序；
echo 按H，显示帮助；
echo 按V，显示版本；
echo.
echo 2,该计算器可以实现简单的计算，以递减的优先权顺序支持下列操作:
echo.
echo () - 分组
echo * / % - 算数运算符
echo + - - 算数运算符
echo ^<^< ^>^> - 逻辑移位
echo - 按位“与”
echo ^^ - 按位“异”
echo ^| - 按位“或”
echo = *= /= %= += -= - 赋值
echo ^&= ^= ^|= ^<^<= ^>^>= -二进制运算赋值
echo , - 表达式分隔符
echo.
echo 如果您使用任何逻辑或取余操作符， 您需要将表达式字符串用引号扩起来。
echo 在表达式中的任何非数字字符串键作为环境变量名称，这些环境变量名称的值已在使用前转换成数字。
echo 如果指定了一个环境变量名称，但未在当前环境中定义，那么值将被定为零。
echo 这使您可以使用环境变量值做计算而不用键入那些 % 符号来得到它们的值。
echo 如果 SET /A 在命令脚本外的命令行执行的，那么它显示该表达式的最后值。
echo 该分配的操作符在分配的操作符左边需要一个环境变量名称。
echo 除十六进制有 0x 前缀， 八进制有 0 前缀的，数字值为十进位数字。
echo 因此， 0x12 与 18 和 022 相同。
echo 请注意八进制公式可能很容易搞混: 08 和 09 是无效的数字，因为 8 和 9 不是有效的八进制位数。
echo -----------------------------------------
if /I {%1}=={} goto Main
if /I "%1"=="H" goto end
if /I "%1"=="V" goto end
:Main
echo.
echo 进入计算模式: (显示帮助:请按H；显示版本:请按V；清屏:请按C；退出:请按E)
echo.
:Calc
set /p input=请输入表达式：
if /I "%input%"=="E" goto end
if /I "%input%"=="H" goto help
if /I "%input%"=="V" goto Ver
if /I "%input%"=="C" goto Clear
set /a result=%input%
echo 计算结果为：%input%=%result%
echo.
goto Calc
:Clear
cls
if /I {%1}=={} goto Main
if /I "%1"=="H" goto end
if /I "%1"=="V" goto end
:end
echo.
echo 祝您工作顺利，心情愉快!
echo. 