<template>
  <div :key="id">
    <div v-for="movie in movies" :key="movie.id">
      <div class="container-detail">
        <h2>{{ movie.title }}</h2>
        <img :src="movie.posterPath ? 'https://localhost:44388'+movie.posterPath : '' " >
        <img :src="movie.backdropPath ? 'https://localhost:44388'+movie.backdropPath : '' " >
      </div>
      <div class="text-block-detail"> 
        <p v-if="movie.releaseDate != null">{{ movie.releaseDate }} - 
          <span v-for="(genre, index) in movie.genres" :key="genre.id">
            <span v-if="index != 0">, </span>
            <genre-item :key="genre.id" :genre="genre"/>
          </span>
        </p>
        
        <p>{{movie.overview}}</p>
      </div>
    </div>
  </div>
</template>

<script>
import GenreItem from "./GenreItem.vue";
import gql from "graphql-tag";

const GET_MOVIE_QUERY = gql`
  query getMovies($id: Int) {
    movies(id: $id, page: 1) {
      id
      title
      releaseDate
      posterPath
      backdropPath
      overview
      genres {
        id
        name
      }
    }
  }
`;

export default {
  components: {
    GenreItem
  },
  name: "MovieDetails",
  props: ["id"],

  data() {
    return {
      movies: []
    };
  },

  apollo: {
    movies: {
      query: GET_MOVIE_QUERY,
      variables() {
        return {
          id: this.id
        }
      }
    }
  }
};
</script>