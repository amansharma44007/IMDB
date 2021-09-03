using System;
using System.Collections.Generic;
namespace IMDB
{
    public class Actor
    {
        public string Name { get; set; }
        public String DOB { get; set; }
        public int Id { get; set; }
        public Actor(string name1,String DOB1)
        {
            Name = name1;
            DOB = DOB1;
        }
    }
}
