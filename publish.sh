dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained true
cp -r ./bin/Debug/net6.0/linux-x64/publish/RepublicExerciseDotNET ./RepublicExerciseDotNET