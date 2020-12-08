# Instagram-clone-AspNetCore-React-Microservice

## Introduction
This is clone of Instagram built with Microservice Architecture with React and Asp.net Core. I have created this project to discover the world of Microservices and how they interact in Containerized environment. I have tried to experience the enterprise-level software development techniques like Docker container setup, development with decoupled services talking to each other using a Message Bus, separate environment for Production and Development, Git workflow and more.


## System Architecture
<p class="center">
    <img src="https://user-images.githubusercontent.com/63048473/101434729-f19eea00-392c-11eb-837e-f98583132e27.png">
</p>

### Highlights
CQRS pattern, Hangfire Job processing, RabbitMq Message Bus, Jwt Authentication, Docker Containerization, Nginx Proxy, Repository Pattern 


## Services
| Docker Image Name   | Details                      |
| ------------------- | ---------------------------- |
| rabbitmq_service    | RabbitMQ Message Bus Service |
| mysql_db_service    | Mysql DB Service             |
| mongo_db_service    | Mongo DB Service             |
| azurite_service     | Azurite Blob Storage Service |
| user_service        | User Service - .Net Core     |
| post_service        | Post Service - .Net Core     |
| newsfeed_service    | Newsfeed Service - .Net Core |
| nginx_service       | Nginx Apigateway Service     |
| web_service         | React SPA Web Application    |

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
| MongoDb          | Hangfire            |

## Application Overview
### User can Sign Up & Login
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Signup-login.gif?raw=true">
</p>

### User can edit Bio
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Edit-bio.gif?raw=true">
</p>

### User can add a Post
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Add-Post.gif?raw=true">
</p>

### UserProfile Walkthrough
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Userfeed-overview.gif?raw=true">
</p>

### User Newsfeed Walkthrough
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Newsfeed-overview.gif?raw=true">
</p>

### Realtime Newsfeed Update
<p class="center">
    <img src="https://github.com/msubhan9803/Instagram-clone-AspNetCore-React-Microservice/blob/master/extras/Realtime-Newsfeed-new.gif?raw=true">
</p>

## How to get Project Up & running -- In Development Environment
1. Clone this Repo
2. Run following commands:\
    `cd src/`\
    `dotnet build`\
    `cd ../scripts/`\
    `docker-compose -f docker-compose.dev.yml build`\
    `docker-compose -f docker-compose.dev.yml up`
3. You can now visit https://localhost:4430/ in your browser!

[comment]: # (> Seed Data:)
[comment]: # (> Emails: ironman@gmail.com | spiderman@gmail.com | superman@gmail.com | hulk@gmail.com)
[comment]: # (> Password: User@123)

## How to get Project Up & running -- In Production Environment
[In Development]

### My Social Media:
https://www.instagram.com/subisubhan \
https://www.facebook.com/mohammad.subhan.581
