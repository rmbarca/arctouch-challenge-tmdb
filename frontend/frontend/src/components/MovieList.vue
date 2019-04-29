<template>
  <div>
    <div class="search-container"> 
      <input ref="searchInput" type="text" :placeholder="hintText" @keydown="handleSearch">
    </div>
    <movie-item v-for="movie in movies" :key="movie.id" :movie="movie"/>
  </div>
</template>

<script>
import SearchMovie from "./SearchMovie.vue";
import MovieItem from "./MovieItem";
import gql from "graphql-tag";

const GET_MOVIES_QUERY = gql`
  query getMovies($page: Int, $search: String) {
    movies(page: $page, search: $search) {
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
`;

var page = 1;
var search = "";

export default {
    name: "MovieList",
    components: { 
      MovieItem,
      SearchMovie 
  },

  data() {
    return {
      movies: [],
      hintText: "Search for an upcoming movie"
    };
  },
  methods: {
    handleSearch() {
      search = event.srcElement.value;

       this.$apollo.queries.movies.fetchMore({
          variables: { search: search },
          updateQuery: (previousResult, { fetchMoreResult }) => {
            const newResults = fetchMoreResult.movies;
            const previousEntry = previousResult.movies;

            return {
              movies: newResults,
              __typename: previousEntry.__typename
            };
          }
        })
    },

    handleScroll(event) {

      this.isUserScrolling = (window.scrollY > 0);
      let bottomOfWindow = Math.max(window.pageYOffset, document.documentElement.scrollTop, document.body.scrollTop) + window.innerHeight === document.documentElement.offsetHeight
      if (bottomOfWindow) {
        page++;

        this.$apollo.queries.movies.fetchMore({
          variables: { page: page, search: search },
          updateQuery: (previousResult, { fetchMoreResult }) => {
            const newResults = fetchMoreResult.movies;
            const previousEntry = previousResult.movies;

            return {
              movies: previousEntry.concat(newResults), //[...newResults, ...previousEntry],
              __typename: previousEntry.__typename
            };
          }
        })

      }
    }
  },
  created () {
    window.addEventListener('scroll', this.handleScroll);
  },
  destroyed () {
    window.removeEventListener('scroll', this.handleScroll);
  },

  apollo: {
    movies: {
      query: GET_MOVIES_QUERY,
      variables() {
        return {
          page: page,
          search: search
        }
      }
    }
  }
};
</script>