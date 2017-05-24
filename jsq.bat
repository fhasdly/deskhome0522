@echo off
:Calc
set /p input=请输入算术表达式：
set /a result=%input%
echo 计算结果为：%input%=%result%
goto Calc 