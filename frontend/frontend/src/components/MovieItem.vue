<template>
  <div :key="movie.id">
    <h3>{{ movie.title }}</h3>
    <span>{{ movie.releaseDate }}</span> 
    <genre-item v-for="genre in movie.genres" :key="genre.id" :genre="genre">
      {{genre.id}}
      <br>
    </genre-item>
    <img :src="'https://localhost:44388'+movie.posterPath"/>
  </div>
</template>

<script>
import GenreItem from "./GenreItem.vue";

export default {
  components: {
    GenreItem
  },
  name: "MovieItem",
  props: ["movie"]
};
</script>