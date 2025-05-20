dotnet publish -r win-x64 -c Release -p:PublishReadyToRun=true -p:PublishSingleFile=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true
dotnet publish -r osx-x64 -c Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --self-contained
dotnet publish -r linux-arm -c Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --self-contained
dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --self-contained

cd \repos\EmbyMissingEpisodes\Build

copy /Y "C:\repos\EmbyMissingEpisodes\bin\Release\net8.0\win-x64\publish\EmbyMissingEpisodes.exe" .
"C:\Program Files\7-Zip\7z" a -tzip EmbyMissingEpisodes-WIN.zip EmbyMissingEpisodes.exe

copy /Y "C:\repos\EmbyMissingEpisodes\bin\Release\net8.0\osx-x64\publish\EmbyMissingEpisodes" .
"C:\Program Files\7-Zip\7z" a -t7z EmbyMissingEpisodes-OSX.7z EmbyMissingEpisodes

copy /Y "C:\repos\EmbyMissingEpisodes\bin\Release\net8.0\linux-arm\publish\EmbyMissingEpisodes" .
"C:\Program Files\7-Zip\7z" a -t7z EmbyMissingEpisodes-RasPi-ARM.7z EmbyMissingEpisodes

copy /Y "C:\repos\EmbyMissingEpisodes\bin\Release\net8.0\linux-x64\publish\EmbyMissingEpisodes" .
"C:\Program Files\7-Zip\7z" a -t7z EmbyMissingEpisodes-LIN64.7z EmbyMissingEpisodes
