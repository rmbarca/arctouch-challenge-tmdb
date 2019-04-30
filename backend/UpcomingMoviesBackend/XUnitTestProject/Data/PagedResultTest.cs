using System.Linq;
using Xunit;
using XUnitTestProject.Fake;
using UpcomingMoviesBackend.Data.Local;
using System;

namespace XUnitTestProject.Data
{
    public class PagedResultTest
    {
        [Fact]
        public void TestPageSize()
        {
            var fake = new MovieFake();
            var paged = fake.Movies_25_Entries.AsQueryable().GetPaged(1, 10);

            Assert.True(paged.PageSize == 10);
        }

        [Fact]
        public void TestTotalPagesCount()
        {
            var pageSize = 10;

            var fake = new MovieFake();
            var movies = fake.Movies_25_Entries;
            var paged = movies.AsQueryable().GetPaged(1, pageSize);

            var ceilingResult = (movies.Count / pageSize) + (movies.Count % pageSize == 0 ? 0 : 1);

            Assert.True(paged.TotalPages == ceilingResult);
        }

        [Fact]
        public void TestCurrentPage()
        {
            var fake = new MovieFake();
            var paged = fake.Movies_25_Entries.AsQueryable().GetPaged(1, 10);

            Assert.True(paged.Page == 1);
        }

        [Fact]
        public void TestTotalResultsCount()
        {
            var fake = new MovieFake();
            var movies = fake.Movies_25_Entries;
            var paged = movies.AsQueryable().GetPaged(1, 10);

            Assert.True(paged.TotalResults == movies.Count);
        }

        [Fact]
        public void TestOutOfPageLimit()
        {
            var fake = new MovieFake();
            var movies = fake.Movies_25_Entries;
            var paged = movies.AsQueryable().GetPaged(4, 10);

            Assert.True(paged.Results.Count == 0);
        }
    }
}
