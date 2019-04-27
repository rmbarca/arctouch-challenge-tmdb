<template>
  <div id="app">
    <img src="./assets/logo.png">
    <search-movie/>
    <movie-list/>

    <!--<h3>Example 1</h3>
    <div>
      Data: {{ example1 }}
    </div>
    <button @click="getLanguage">Get Language</button>-->
    <hr> 
  </div>
</template>

<script>
//import axios from 'axios'
import MovieList from "./components/MovieList.vue";
import SearchMovie from "./components/SearchMovie.vue";

export default {
  name: 'App',
  
  components: {
    MovieList,
    SearchMovie
  }/*,,

  data() {
    return {
      example1: ''
    }
  }
  methods: {
    async getLanguage () {
      try {
        const res = await axios.post(
          'https://localhost:44388/api/upcomingmovies', {
          query: `{
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
          }`
        })
        
        this.example1 = res.data.data.language
      } catch (e) {
        console.log('err', e)
      }
    }
  }*/
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
