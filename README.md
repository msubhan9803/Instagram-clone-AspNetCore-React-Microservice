# Instagram-clone-AspNetCore-React-Microservice

## Introduction
This is clone of Instagram built with Microservice Architecture with React and Asp.net Core. I have this to discover the world of Distributed Systems, Containerized world. I have tried to experience the enterprise-level software development techniques like Docker container setup, development with decoupled services talking using a Message Bus, separate environment for Production and Development, Git workflow and more. 


## System Architecture
<p class="center">
    <img src="https://user-images.githubusercontent.com/63048473/100604271-1e993e80-3328-11eb-8d5e-b3416b2f4aed.png">
</p>

## Services
| Docker Image Name   | Details                      |
| ------------------- | ---------------------------- |
| rabbitmq_service    | RabbitMQ Message Bus Service |
| mysql_db_service    | Mysql DB Service             |
| mongo_db_service    | Mongo DB Service             |
| azurite_service     | Azurite Blob Storage Service |
| user_service        | User Service                 |
| post_service        | Post Service                 |
| newsfeed_service    | Newsfeed Service             |
| nginx_service       | Nginx Apigateway Service     |
| web_service         | Web Service                  |

## Database Schema
<p class="center">
    <img src="https://user-images.githubusercontent.com/63048473/100711198-c4a18300-33d2-11eb-82f1-95ab517fc57d.png">
</p>

## Main Technologies Used
|                  |                     |
| -----------------|---------------------|
| Asp.Net Core     | AutoMapper          |
| ReactJs          | FluentValidation    |
| Nginx            | FFMpegCore          |
| RabbitMq         | Azurite             |
| Docker           | Redux               |
| Docker-Compose   | Ant Design          |
| MySql            | Git Version Control |
| MongoDb          | nginx_service       |
| Hangfire         | web_service         |

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
