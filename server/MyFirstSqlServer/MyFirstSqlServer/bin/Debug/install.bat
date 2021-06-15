%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe F:\Stu\server\MyFirstSqlServer\MyFirstSqlServer\bin\Debug\MyFirstSqlServer.exe
Net Start ServiceTest
sc config ServiceTest start= auto
pause