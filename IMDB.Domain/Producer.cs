using System;
using System.Collections.Generic;
namespace IMDB
{
        public class Producer
        {
            public string Name { get; set; }
            public String DOB { get; set; }
            public int Id { get; set; }
            public Producer(string name1,String DOB1)
            {
                Name = name1;
                DOB = DOB1;
            }
        }
}
