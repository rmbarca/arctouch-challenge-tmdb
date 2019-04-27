const express = require('express')
const { graphql, buildSchema } = require('graphql')
const graphqlHTTP = require('express-graphql')
const cors = require('cors')

const schema = buildSchema(`
type Query { 
  language: String
}
`)

/*
type Query { 
  language: String
  getGenres: [Genre]
}

type Genre {
  name: String
}

type Movie {
  title: String
  releaseDate: String
  posterPath: String
  backdropPath: String
  genres: [Genre]
}

type MovieResponse {
  page: Int
  totalPages: Int
  totalResults: Int
  movies: [Movie]
}

const genres = [
  new Genre('Documentary'),
  new Genre('Fiction')
]
*/

const rootValue = {
    language: () => 'GraphQL',
    //getGenres: () => genres
}


const app = express()
app.use(cors())
app.use('/graphql', graphqlHTTP({
  rootValue, schema, graphiql: true
}))
app.listen(4000, () => console.log('Listening on 4000'))