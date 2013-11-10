using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic
{
    public class Flora
    {
        private static int MinimumRegrowth = 100;
        private static int MaximumRegrowth = 1000;

        public World World { get; private set; }

        public int XCoord { get; private set; }

        public int YCoord { get; private set; }

        public int EnergyValue = 10;

        public uint GrowthTime = 0;

        public Flora(World world, int x, int y)
        {
            World = world;
            if (world[x, y].Flora == null)
            {
                world[x, y].Flora = this;
            }
            else
            {
                throw new Exception("Flora already exists at this location.");
            }
        }

        public int Eat()
        {
            if (GrowthTime < World.Tick)
            {
                GrowthTime = World.Tick + (uint)RandNum.Integer(MinimumRegrowth, MaximumRegrowth);
                return EnergyValue;
            }
            return 0;
        }
    }
}
