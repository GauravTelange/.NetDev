@echo off
REM Run ASP.NET Core behind Apache proxy (Kestrel on port 5005)
set ASPNETCORE_URLS=http://127.0.0.1:5005
set ASPNETCORE_ENVIRONMENT=Production

cd /d C:\Website123
if not exist CustomerApplication.dll (
    echo Publish first to C:\Website123
    pause
    exit /b 1
)

echo Kestrel: http://127.0.0.1:5005
echo Apache (after setup): http://localhost/
dotnet CustomerApplication.dll
