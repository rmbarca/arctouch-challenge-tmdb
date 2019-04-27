<template>
  <div>
    <movie-item v-for="movie in movies" :key="movie.id" :movie="movie">{{movie.id}}</movie-item>
  </div>
</template>

<script>
import MovieItem from "./MovieItem";
export default {
  name: "MovieList",
  components: { MovieItem },
  data() {
    return {
      movies: [
        {
          id: "123123123",
          title: "Harry Potter and the Order of the Phoenix",
          director: "David Yates",
          composer: "Nicholas Hopper",
          release_date: "2007-07-11"
        }
      ]
    };
  }
};
</script>