class MovieResponse {
    constructor(page, totalPages, totalResults, movies) {
      this.page = page
      this.totalPages = totalPages
      this.totalResults = totalResults
      this.movies = movies
    }
}
module.exports = MovieResponse
