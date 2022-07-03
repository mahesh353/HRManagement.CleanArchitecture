
# HRManagement.CleanArchitecture
This repository follows the clean architectural design pattern

Technologies Used 
1) C#
2) .Net Core Web API 3.1
3) Entity Framework Core

Design Patterns Used While Developing Web API Project.
1) Clean Architecture
2) Dependency Injection
3) CQRS(Command Query Resposibility Segregation)
4) Mediator Design Pattern

Packages/Libraries Used
1) MediatR for implementing Mediator design pattern
2) Fluent API for implementing Validation on server side.
3) Swagger tool for generating open api specification for API

Steps to setup the project-

1) Download the source code zip file from below link  -
   https://github.com/mahesh353/HRManagement.CleanArchitecture

2) Unzip the project & open it in Visual Studio 2019

3) Open Package Manager Console & Type below commands one by one to setup the database
   
   1) add-migration [migration_name]
   2) update database
   
4) Once done it will generate the .mdf file in your home directory restore that file in local database using server explorer(not a mandatory step)
5) Run the project It will open both api project & client project at the same time
  
