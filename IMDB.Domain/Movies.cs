using System;
using System.Collections.Generic;
namespace IMDB
{
        public class Movies
        {
            public string Name { get; set; }
            public int Year { get; set; }
            public string Plot { get; set; }

            public List<Actor> _Actors { get; set; } = new List<Actor>();
            public Producer _Producer { get; set; }
            public int Id { get; set; }
        public Movies(string name, int year1, string plot1, List<Actor> a,Producer p)
            {
                Name = name;
                Year = year1;
                Plot = plot1;
                _Actors = a;
                _Producer = p;

            }
        }
}
