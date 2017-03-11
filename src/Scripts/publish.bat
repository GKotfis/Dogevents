echo off
%windir%\system32\inetsrv\appcmd stop site /site.name:Dogevents
%windir%\system32\inetsrv\appcmd stop apppool /apppool.name:Dogevents

dotnet publish %cd%\..\Web\Dogevents.Web\Dogevents.Web.csproj -o %cd%\..\..\publish -c Release

%windir%\system32\inetsrv\appcmd start site /site.name:Dogevents
%windir%\system32\inetsrv\appcmd start apppool /apppool.name:Dogevents