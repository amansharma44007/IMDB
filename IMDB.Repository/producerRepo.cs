using System;
using System.Collections.Generic;
using System.Linq;
namespace IMDB
{
        public class producerRepo
        {
            private  List<Producer> _producerList = new List<Producer>();
            
            public Producer Get(int proInt)
            {
            return _producerList.Where(i => i.Id ==proInt).First();
            }
            public void AddProducer(Producer p1)
            {
                p1.Id = _producerList.Count + 1;
                _producerList.Add(p1);
            }
            public List<Producer> GetProducer()
        {
            return _producerList;
        }
            public void Display()
            {
                foreach (var item in _producerList)
                {
                    Console.Write("{0}.{1} ", item.Id, item.Name);
                }
                Console.WriteLine();
            }
            
        }
}
