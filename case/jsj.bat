@echo off
cls
:: System Parameter
set xpProgName=DosCalculator
set xpProgVer=1.0.0.1
echo.
title ��ӭʹ��Taoether���Ƶ�С������(DCal.bat) %xpProgName%_V%xpProgVer%
color 1f
rem mode con cols=80 lines=40
echo ��ӭʹ��Taoether���Ƶ�С������(DCal.bat) %xpProgName%_V%xpProgVer%
if /I {%1}=={} goto Main
if /I "%1"=="C" goto Main
if /I "%1"=="H" goto help
if /I "%1"=="V" goto ver
:Ver
echo.
rem ��Ҫ������
rem ����������������д�����������⴫�������벻Ҫɾ��������Ϣ!
rem ��������ҵ��;������������ϵ��
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
echo �˳���Ϊ�����������������ʽ�󣬷��ؼ�������
echo.
echo DCal [M]
echo.
echo [M]: ָ�����е�ģʽ
echo =�գ��������ģʽ
echo =C��������
echo =H����ʾ������
echo =V����ʾ�汾��
echo.
echo ˵��:
echo.
echo 1,�ڼ���ģʽ�£�
echo ֱ��������ʽ���س����ؼ�������
echo ��E���˳�����
echo ��H����ʾ������
echo ��V����ʾ�汾��
echo.
echo 2,�ü���������ʵ�ּ򵥵ļ��㣬�Եݼ�������Ȩ˳��֧�����в���:
echo.
echo () - ����
echo * / % - ���������
echo + - - ���������
echo ^<^< ^>^> - �߼���λ
echo - ��λ���롱
echo ^^ - ��λ���족
echo ^| - ��λ����
echo = *= /= %= += -= - ��ֵ
echo ^&= ^= ^|= ^<^<= ^>^>= -���������㸳ֵ
echo , - ���ʽ�ָ���
echo.
echo �����ʹ���κ��߼���ȡ��������� ����Ҫ�����ʽ�ַ�����������������
echo �ڱ��ʽ�е��κη������ַ�������Ϊ�����������ƣ���Щ�����������Ƶ�ֵ����ʹ��ǰת�������֡�
echo ���ָ����һ�������������ƣ���δ�ڵ�ǰ�����ж��壬��ôֵ������Ϊ�㡣
echo ��ʹ������ʹ�û�������ֵ����������ü�����Щ % �������õ����ǵ�ֵ��
echo ��� SET /A ������ű����������ִ�еģ���ô����ʾ�ñ��ʽ�����ֵ��
echo �÷���Ĳ������ڷ���Ĳ����������Ҫһ�������������ơ�
echo ��ʮ�������� 0x ǰ׺�� �˽����� 0 ǰ׺�ģ�����ֵΪʮ��λ���֡�
echo ��ˣ� 0x12 �� 18 �� 022 ��ͬ��
echo ��ע��˽��ƹ�ʽ���ܺ����׸��: 08 �� 09 ����Ч�����֣���Ϊ 8 �� 9 ������Ч�İ˽���λ����
echo -----------------------------------------
if /I {%1}=={} goto Main
if /I "%1"=="H" goto end
if /I "%1"=="V" goto end
:Main
echo.
echo �������ģʽ: (��ʾ����:�밴H����ʾ�汾:�밴V������:�밴C���˳�:�밴E)
echo.
:Calc
set /p input=��������ʽ��
if /I "%input%"=="E" goto end
if /I "%input%"=="H" goto help
if /I "%input%"=="V" goto Ver
if /I "%input%"=="C" goto Clear
set /a result=%input%
echo ������Ϊ��%input%=%result%
echo.
goto Calc
:Clear
cls
if /I {%1}=={} goto Main
if /I "%1"=="H" goto end
if /I "%1"=="V" goto end
:end
echo.
echo ף������˳�����������!
echo. 