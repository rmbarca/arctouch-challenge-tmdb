import Vue from 'vue'
import Router from 'vue-router'
import MovieList from '@/components/MovieList'
import MovieDetails from '@/components/MovieDetails'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'MovieList',
      component: MovieList
    },
    {
      path: '/:id',
      name: 'details',
      component: MovieDetails,
      props: true
    }
  ]
})
