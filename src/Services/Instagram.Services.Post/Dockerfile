FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
RUN apk add libgdiplus --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
RUN apk update && apk add ffmpeg
WORKDIR /app
COPY ./bin/Docker .
ENV ASPNETCORE_URLS http://*:9001
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT dotnet Instagram.Services.Post.dll