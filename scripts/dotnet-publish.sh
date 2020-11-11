cd ../backend/services
dotnet publish ./Instagram.Services.User -c Release -o ./Instagram.Services.User/bin/Docker
dotnet publish ./Instagram.Services.Post -c Release -o ./Instagram.Services.Post/bin/Docker
dotnet publish ./Instagram.Services.Newsfeed -c Release -o ./Instagram.Services.Newsfeed/bin/Docker