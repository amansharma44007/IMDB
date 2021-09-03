using System.Collections.Generic;
using System;
namespace IMDB
{
        public class MovieRepo
        {
            private List<Movies> _movieList = new List<Movies>();
            public void AddMovies(Movies movie)
            {
                 movie.Id = _movieList.Count + 1;
                _movieList.Add(movie);
            }
            public void MovieDeleteAt(int i)
            {
                _movieList.RemoveAt(i-1);
            }
            public List<Movies> Get()
            {
                return _movieList;
            }
        }
}
