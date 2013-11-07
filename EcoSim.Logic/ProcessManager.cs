using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EcoSim.Logic
{
    public static class ProcessManager
    {
        static WaitCallback creatureCallback;

        static ProcessManager()
        {
            creatureCallback = new WaitCallback(AI_Entities.Creature.ProcessCreature);
        }

        public static void QueueCreatures(World world)
        {
            foreach (AI_Entities.Creature C in world.Creatures)
            {
                if (C.Active)
                    ThreadPool.QueueUserWorkItem(creatureCallback, C);
            }                    
        }

        
    }
}
