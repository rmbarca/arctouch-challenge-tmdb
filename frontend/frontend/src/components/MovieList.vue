<template>
  <div>
    Movies found: {{results.totalResults}}
    Page {{results.page}} of {{results.totalPages}}

    <movie-item v-for="movie in results.movies" :key="movie.id" :movie="movie">
      {{movie.id}}
    </movie-item>
  </div>
</template>

<script>
import MovieItem from "./MovieItem";
import gql from "graphql-tag";


const schema = gql`
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
  `

const GET_MOVIES = gql`
  query getMoviesResponse {
    results(page:1) {
      page
      totalPages
      totalResults
      movies {
        id
        title
        releaseDate
        posterPath
        backdropPath
        genres {
          id
          name
        }
      }
    }
  }
`;

export default {
  name: "MovieList",
  components: { MovieItem },
  data() {
    return {
      results: {}
    };
  },
  apollo: {
    results: {
      query: GET_MOVIES
    }
  }
};
</script>