FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:9002
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT dotnet Instagram.Services.Newsfeed.dll