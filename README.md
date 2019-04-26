# arctouch-challenge-tmdb
Upcoming Movies Web App

Backend project is developed in .NET Core 2.1 WebApi.

Backend is consuming TMDb Api with REST requests and it's providing movie services with GraphQL.
As the project does not use local storage, it needed three services: 2 for GraphQL and 1 for retrieving images.
In case of implementing local storage, using Entity Framework, for example, endpoints could be optmized and became one instead of two for GraphQL.

Third party packages used:
	Install-Package GraphQL
	
