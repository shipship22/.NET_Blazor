@if "%SCM_TRACE_LEVEL%" NEQ "4" @echo off

echo 正在部署 .NET Blazor 博客项目...
echo.

echo 恢复 NuGet 包...
call :ExecuteCmd dotnet restore
if %ERRORLEVEL% neq 0 goto error

echo.
echo 发布项目...
call :ExecuteCmd dotnet publish Blog.API.csproj -c Release -o %DEPLOYMENT_TARGET%
if %ERRORLEVEL% neq 0 goto error

echo.
echo 部署完成！
exit /b 0

:ExecuteCmd
setlocal
set _CMD_=%*
echo 执行命令: %_CMD_%
call %_CMD_%
if %ERRORLEVEL% neq 0 goto error
exit /b 0

:error
echo.
echo 发生错误：%_CMD_%
exit /b 1