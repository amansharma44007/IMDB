using System;
using System.Collections.Generic;
using System.Linq;
namespace IMDB
{
    partial class Program
    {
        
        static void Main(string[] args)
        {
            
            bool run = true;
            Service serviceR = new Service();
            while (run)
            {
                Console.WriteLine(@"********************************************************************************
                                    Welcome to IMDB
********************************************************************************
Select the Options:
1.List Movies
2.Add Movies
3.Add Actor
4.Add Producer
5.Delete Movie
6.Exit");
                Console.WriteLine("Enter Option here:");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        serviceR.MovieDisplay();
                        break;
                    case 2:
                       Console.WriteLine("Enter the Movie Name: ");
                        string movieName = Console.ReadLine();
                        bool movieName1 = string.IsNullOrWhiteSpace(movieName);
                        while (movieName1)
                        {
                            Console.WriteLine("Please Enter Correct movie name: ");
                            Console.WriteLine("Enter the Movie Name: ");
                            movieName = Console.ReadLine();
                            movieName1 = string.IsNullOrWhiteSpace(movieName);
                        }


                        Console.WriteLine("Enter the year of release: ");
                        string yearOfRelease = Console.ReadLine();
                        var isNumeric = int.TryParse(yearOfRelease, out int n);
                        while (!isNumeric)
                        {
                            Console.WriteLine("Please Eneter a Valid Year: ");
                            yearOfRelease = Console.ReadLine();
                            isNumeric = int.TryParse(yearOfRelease, out  n);
                        }
                        int yearOfRelease1 = int.Parse(yearOfRelease);



                        Console.WriteLine("Plot: ");
                        string plot=Console.ReadLine();


                        Console.WriteLine("Choose Actors: ");

                        bool actorList = serviceR.TrueOrFalse();
                        if (actorList == false)
                        {
                            Console.WriteLine("Sorry your Actor List is Empty");
                            break;
                        }
                        else
                        {
                            serviceR.ActorDisplay();
                        }
                        string[] stringArray = Console.ReadLine().Split();
                        bool intOrNot = serviceR.ActorListCheck(stringArray);
                        while (!intOrNot)
                        {
                            Console.WriteLine("Invalid Actor List: ");
                            Console.WriteLine("Please Choose Actors: ");
                            stringArray = Console.ReadLine().Split();
                            intOrNot = serviceR.ActorListCheck(stringArray);
                        }
                        int[] intArray = stringArray.Select(int.Parse).ToArray();


                        bool producerList = serviceR.TrueOrFalse();
                        if (producerList == false)
                        {
                            Console.WriteLine("Sorry your Producer list is Empty");
                            break;
                        }
                        else
                        {
                            serviceR.ProducerDisplay();
                        }
                        Console.WriteLine("Please Choose Only one Producer: ");
                        string intProducer = Console.ReadLine();
                        bool checkint= int.TryParse(intProducer, out int nn);
                        if (!checkint)
                        {
                            Console.WriteLine("You have not mention Producer here: ");
                            Console.WriteLine("Please Choose Only one Producer Again: ");
                            intProducer = Console.ReadLine();
                            checkint = int.TryParse(intProducer, out int nnn);
                        }
                        var producerInt = int.Parse(intProducer);
                        serviceR.ServiceAddMovie(movieName, yearOfRelease1, plot, intArray, producerInt);
                        break;
                    case 3:
                        Console.WriteLine("Enter the Actor Name: ");
                        string name = Console.ReadLine();
                        bool nameT = serviceR.NameValidate(name);
                        while (!nameT) {
                            Console.WriteLine("Enter the correct Actore Name: ");
                            Console.WriteLine("Enter the Actor Name: ");
                            name = Console.ReadLine();
                            nameT = serviceR.NameValidate(name);
                        }
                        Console.WriteLine("DOB: ");
                        string dob = Console.ReadLine();
                        bool dobT = serviceR.DobValidate(dob);
                        while (!dobT)
                        {
                            Console.WriteLine("Enter correct DOB: ");
                            Console.WriteLine("DOB: ");
                            dob = Console.ReadLine();
                            dobT = serviceR.DobValidate(dob);
                        }
                        serviceR.Add(name, dob);
                        break;
                    case 4:
                        Console.WriteLine("Enter the Producer Name: ");
                        string nameProducer = Console.ReadLine();
                        bool nameTP = serviceR.NameValidate(nameProducer);
                        while (!nameTP)
                        {
                            Console.WriteLine("Enter the correct Producer Name: ");
                            Console.WriteLine("Enter the Producer Name: ");
                            nameProducer = Console.ReadLine();
                            nameTP = serviceR.NameValidate(nameProducer);
                        }
                        Console.WriteLine("DOB: ");
                        string dobProducer = Console.ReadLine();
                        bool dobTP = serviceR.DobValidate(dobProducer);
                        while (!dobTP)
                        {
                            Console.WriteLine("Enter correct DOB: ");
                            Console.WriteLine("DOB: ");
                            dobProducer = Console.ReadLine();
                            dobT = serviceR.DobValidate(dobProducer);
                        }
                        serviceR.AddProducer(nameProducer, dobProducer);
                        break;
                    case 5:
                        serviceR.DeleteDisplay();
                        break;
                    case 6:
                        run = false;
                        break;
                    default:
                        serviceR.ActorDisplay();
                        serviceR.ProducerDisplay();
                        break;

                }
            }
        }
    }
    
}
