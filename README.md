# arctouch-challenge-tmdb
Upcoming Movies Web App

# Backend
Backend project is developed in .NET Core 2.1 WebApi, using Visual Studio 2019 (16.0.2).

Backend is consuming TMDb Api with REST requests and it's providing movie services with GraphQL.
Local storage is handled by Entity Framework Core.
It provides two services: 1 for GraphQL and 1 for retrieving images.
For test purposes, it's configurated at port 44388 and localhost.
When debuging, it runs on IISExpress (Visual Studio) and localdb simulating SQL Server.

Third party packages used and commands on Package Manager console:
	PM> Install-Package GraphQL

For creation of database, a migration file was created with the following command:
	PM> Add-Migration UpcomingMoviesBackend.Data.Local.MovieDatabaseContext

To create database, run:
	PM> update-database
	
Unit tests are in XUnit Core Project.
Packages included:
	PM> Install-Package Moq

# Frontend
Frontend project is developed using Vue.JS library.
It runs on NPM and uses Apollo for handling GraphQL interaction.

NPM commands used to set the project up:
	> npm install -g vue-cli
	> vue init webpack frontend
	> npm install express express-graphql graphql --save
	> npm install cors --save
	> npm install vue-apollo --save
	> npm install apollo-client apollo-cache-inmemory apollo-link-http graphql-tag graphql --save
	
To get started with testing, open command prompts and execute the following instructions:
	> npm run dev

It was also used Milligram CSS library by adding these three lines inside public index.html <head> tag:
	<link rel="stylesheet" href="//fonts.googleapis.com/css?family=Roboto:300,300italic,700,700italic">
	<link rel="stylesheet" href="//cdn.rawgit.com/necolas/normalize.css/master/normalize.css">
	<link rel="stylesheet" href="//cdn.rawgit.com/milligram/milligram/master/dist/milligram.min.css">

# Not covered
As a MVP, this project does not yet provide language support.
