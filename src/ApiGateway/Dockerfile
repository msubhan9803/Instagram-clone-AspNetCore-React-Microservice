FROM openresty/openresty:alpine-fat
COPY default.conf /etc/nginx/conf.d/default.conf

RUN mkdir -p /etc/nginx/conf.d/lua
COPY lua/agg.lua /etc/nginx/conf.d/lua

COPY localhost.crt /etc/ssl/certs/localhost.crt
COPY localhost.key /etc/ssl/private/localhost.key