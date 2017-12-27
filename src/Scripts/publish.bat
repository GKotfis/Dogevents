echo off
%windir%\system32\inetsrv\appcmd stop site /site.name:Dogevents.Api
%windir%\system32\inetsrv\appcmd stop apppool /apppool.name:Dogevents

dotnet publish %cd%\..\Web\Dogevents.Web\Dogevents.Web.csproj -o %cd%\..\Web\Dogevents.Web\bin\Debug\Publish -c Debug

%windir%\system32\inetsrv\appcmd start site /site.name:Dogevents.Api
%windir%\system32\inetsrv\appcmd start apppool /apppool.name:Dogevents