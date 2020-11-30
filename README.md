# Instagram-clone-AspNetCore-React-Microservice

## Introduction
This is clone of Instagram built with Microservice Architecture with React and Asp.net Core. I have this to discover the world of Distributed Systems, Containerized world. I have tried to experience the enterprise-level software development techniques like Docker container setup, development with decoupled services talking using a Message Bus, separate environment for Production and Development, Git workflow and more. 


## System Architecture
![Instagram-clone-New](https://user-images.githubusercontent.com/63048473/100604271-1e993e80-3328-11eb-8d5e-b3416b2f4aed.png)

## Services

* User Service
* Post Service
* Newsfeed Service
* Web Service
* Nginx Apigateway Service
* Mysql DB Service
* Mongo DB Service
* Azurite Service
* RabbitMQ Service

## Main Technologies Used
* Asp.Net Core
* ReactJs
* Nginx
* RabbitMq
* Docker 
* Docker-Compose
* MySql
* MongoDb
* Hangfire
* AutoMapper
* FluentValidation
* FFMpegCore
* Azurite
* Redux
* Ant Design
* Git Version Control (obviously)

## How to get Project Up & running -- In Development Environment
1. Clone this Repo
2. Run following commands:\
    `cd src/`\
    `dotnet build`\
    `cd ../scripts/`\
    `docker-compose -f docker-compose.dev.yml build`\
    `docker-compose -f docker-compose.dev.yml up`
3. You can now visit https://localhost:4430/ in your browser!

> Seed Data: \
> Emails: ironman@gmail.com | spiderman@gmail.com | superman@gmail.com \
> Password: User@123


## How to get Project Up & running -- In Production Environment
[In Development]

### My Social Media:
https://www.instagram.com/subisubhan \
https://www.facebook.com/mohammad.subhan.581
