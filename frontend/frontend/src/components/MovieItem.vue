<template>
  <div :key="movie.id">
    <div class="container">
      <router-link :to="{ name: 'details', params: { id: movie.id }}">
        <img :src="'https://localhost:44388'+movie.posterPath">
        <div class="text-block"> 
          <h4>{{ movie.title }}</h4>
          <h4 v-if="movie.releaseDate != null">({{ movie.releaseDate }})</h4>
          <small v-for="(genre, index) in movie.genres" :key="genre.id">
            <small v-if="index != 0">, </small><genre-item :key="genre.id" :genre="genre"/>
          </small>
        </div>
      </router-link>
    </div>
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