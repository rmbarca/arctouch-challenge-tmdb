# arctouch-challenge-tmdb
Upcoming Movies Web App

Backend project is developed in .NET Core 2.1 WebApi.

Backend is consuming TMDb Api with REST requests and it's providing movie services with GraphQL.
As the project does not use local storage, it needed three services: 2 for GraphQL and 1 for retrieving images.
In case of implementing local storage, using Entity Framework, for example, endpoints could be optmized and became one instead of two for GraphQL.

Third party packages used:
	> Install-Package GraphQL
	

Frontend project is developed using Vue.JS library.

NPM commands used to set up the project:
	> npm install -g vue-cli
	> vue init webpack frontend
	>> npm install express express-graphql graphql --save
	>> npm install cors --save
	>> npm install --save axios
	> npm install vue-apollo --save
	> npm install apollo-client apollo-cache-inmemory apollo-link-http graphql-tag graphql --save
	>> npm uninstall <packageName> --save
	
To get started, open two command prompts and execute the following instructions:
	>> node server
	> npm run dev

It was also used Milligram library by adding these three lines inside public index.html <head> tag:
	<link rel="stylesheet" href="//fonts.googleapis.com/css?family=Roboto:300,300italic,700,700italic">
	<link rel="stylesheet" href="//cdn.rawgit.com/necolas/normalize.css/master/normalize.css">
	<link rel="stylesheet" href="//cdn.rawgit.com/milligram/milligram/master/dist/milligram.min.css">
	