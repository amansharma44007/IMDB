using System;
using TechTalk.SpecFlow;
using IMDB;
using TechTalk.SpecFlow.Assist;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace IMDB.Tests
{
    [Binding]
    public class IMDBFeatureSteps
    {
        private ActorRepos _a1 = new ActorRepos();
        private Service _serviceR = new Service();
        private string name;
        private DateTime _dob;
        private string _MovieName;
        private int _yearOfRelease1;
        private string _Plot;
        private int[] _ActorInt;
        private int _Producer;
        private List<Movies> _listOfMovies;
        [Given(@"the actor name as ""(.*)""")]
        public void GivenTheActorNameAs(string name)
        {
            this.name = name;
            
        }
        
        [Given(@"the actor dob as ""(.*)""")]
        public void GivenTheActorDobAs(string dob)
        {
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            info.ShortDatePattern = "dd/MM/yyyy";
            //this.dob = Convert.ToDateTime(dob,info);
        }
        
        [When(@"the actor is added")]
        public void WhenTheActorIsAdded()
        {
            
            //_a1.Add(name, dob);
        }
        
        [Then(@"the actor list should be like")]
        public void ThenTheActorListShouldBeLike(Table table)
        {
            table.FindInSet(_a1.GetActorList());
            
        }

        [Given(@"the movie name as ""(.*)""")]
        public void GivenTheMovieNameAs(string p0)
        {
            var MovieName = p0;
        }

        [Given(@"the year of release as ""(.*)""")]
        public void GivenTheYearOfReleaseAs(int p0)
        {
            _yearOfRelease1 = p0;
        }

        [Given(@"the plot as ""(.*)""")]
        public void GivenThePlotAs(string p0)
        {
            _Plot = p0;
        }

        [Given(@"the actors of the movie as ""(.*)""")]
        public void GivenTheActorsOfTheMovieAs(string p0)
        {
            var Actor = p0.Split(",");
            _ActorInt = Actor.Select(int.Parse).ToArray();
        }

        [Given(@"the producer of the movie as ""(.*)""")]
        public void GivenTheProducerOfTheMovieAs(int p0)
        {
            _Producer = p0;
        }

        [When(@"the movie is added")]
        public void WhenTheMovieIsAdded()
        {
            _serviceR.ServiceAddMovie(_MovieName, _yearOfRelease1, _Plot, _ActorInt, _Producer);
        }

        [Then(@"the movie list should be like")]
        public void ThenTheMovieListShouldBeLike(Table table)
        {

            _listOfMovies = _serviceR.GetMovie();
            table.FindInSet(_listOfMovies.Select(i => new { i.Name, i.Year, i.Plot }));
            

            


        }

        [Then(@"the actors of this movie look like this")]
        public void ThenTheActorsOfThisMovieLookLikeThis(Table table)
        {
            table.FindInSet(_listOfMovies.SelectMany(i => i._Actors));
        }

        [Then(@"the producer of this movie look like this")]
        public void ThenTheProducerOfThisMovieLookLikeThis(Table table)
        {
            table.FindInSet(_listOfMovies.Select(i => i._Producer));
        }
        [BeforeScenario("AddingMovieEmpty")]
        public void BeforeList()
        {
            _serviceR.Add("Aman Sharma","30/11/1998");
            _serviceR.Add("Tony Stark", "29/5/1970");
            _serviceR.AddProducer("Kang", "1/1/1963");

        }

        [BeforeScenario("VeiwingMovie")]
        public void BeforeViewing()
        {
            _serviceR.Add("Aman Sharma","30/11/1998");
            _serviceR.Add("Tony Stark", "11/1/1999");
            _serviceR.AddProducer("kang", "1/1/1999");
            int[] ints = { 1, 2 };
            _serviceR.ServiceAddMovie("kk", 2000, "any..",ints, 1);

        }
        [Given(@"I have Movie Respository")]
        public void GivenIHaveMovieRespository()
        {
            
        }

        [When(@"I fetch the repository")]
        public void WhenIFetchTheRepository()
        {
            _listOfMovies = _serviceR.GetMovie();
        }



    }
}
