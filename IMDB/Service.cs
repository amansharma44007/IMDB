using System.Collections.Generic;
using System;
namespace IMDB
{
    public class Service
    {
        ActorRepos actorR = new ActorRepos();
        producerRepo producerR = new producerRepo();
        MovieRepo movieR = new MovieRepo();
        Validate validateR = new Validate();

        public void ServiceAddMovie(string movieName,int yearOfRealease1,string plot,int[] intActorArray,int intProducer )
        {
            List<Actor> actordup = new List<Actor>();
            foreach (var item in intActorArray)
            {
                actordup.Add(actorR.Get(item));
            }
            Producer produ = producerR.Get(intProducer);

            movieR.AddMovies(new Movies(movieName, yearOfRealease1, plot, actordup, produ));

        }
        public bool NameValidate(string name)
        {
            return validateR.NameValidate(name);
        }
        public bool DobValidate(string dob)
        {
            DateTime actorDob;
            return validateR.DobValidate(dob, out actorDob);
        }
        public  void Add(string name, String dob)
        {
            Actor actor = new Actor(name, dob);
            actorR.Add(actor);
        }
        public void AddProducer(string name,string dob)
        {
            Producer produ = new Producer(name, dob);
            producerR.AddProducer(produ);
        }
        public void ActorDisplay()
        {
            
            foreach (var item in actorR.GetActorList())
            {
                Console.Write("{0}.{1} {2} ", item.Id, item.Name,item.DOB);
            }
            Console.WriteLine();
        }
        public void ProducerDisplay()
        {
            foreach (var item in producerR.GetProducer())
            {
                Console.Write("{0}.{1} ", item.Id, item.Name);
            }
            Console.WriteLine();
        }
        public void DeleteDisplay()
        {
            Console.WriteLine("Delete Movies:");
            foreach (var item in movieR.Get())
            {
                Console.Write("{0}.{1} ", item.Id, item.Name);
            }
            Console.WriteLine("\nEnter movie option here which you want to delete: ");
            int movieNum = int.Parse(Console.ReadLine());
            movieR.MovieDeleteAt(movieNum);
            Console.WriteLine("Congrats Movie deleted");
        }
        public bool TrueOrFalse()
        {
            if (actorR.GetActorList().Count == 0)

            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool TrueOrFalseP()
        {
            if (producerR.GetProducer().Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ActorListCheck(string[] token)
        {
            bool answer = validateR.ActorList(token);
            return answer;
        }
        public void MovieDisplay()
        {
            var movieList = movieR.Get();
            if (movieList.Count == 0)
            {
                Console.WriteLine("Movie List is Empty");
            }
            else
            {
                foreach (var movie in movieList)
                {
                    Console.WriteLine("{0} {1}", movie.Name, movie.Year);
                    Console.WriteLine("Plot- {0}", movie.Plot);
                    Console.Write("Actors- ");
                    foreach (var item in movie._Actors)
                    {
                        Console.Write("{0} ", item.Name);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Producer- {0}", movie._Producer.Name);
                    Console.WriteLine("************************************");
                }
            }
        }
        public List<Movies> GetMovie()
        {
            return movieR.Get();
        }
         
    }
    
}
