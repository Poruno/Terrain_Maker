using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrain_Maker.Scripts {
    // Singleton
    internal class EventManager {

        Stack<string> events;
/*
 1) events string is separated by ,
 2) format is eventOwnerID,action,args[]
i.e. 
1234567, move, 1234567, 5, 0
Which when implemented moves GameObject 1234567 to position 5, 0
 */
        public EventManager() {

        }


    }
}
