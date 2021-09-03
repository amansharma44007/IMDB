using System;
using System.Collections.Generic;
using System.Linq;
namespace IMDB
{
        public class ActorRepos
        {
            private List<Actor> _actorList =  new List<Actor>();

            public void Add(Actor actor)
            {
                actor.Id = _actorList.Count + 1;
                _actorList.Add(actor); 
            }
            
            public List<Actor> GetActorList()
        {
            return _actorList;
        }
        public Actor Get(int actoInt)
        {
            return _actorList.Where(i=>i.Id == actoInt).First();
        }

    }
}
