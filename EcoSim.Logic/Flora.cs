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

        private World world;

        public int XCoord { get; private set; }

        public int YCoord { get; private set; }

        public int EnergyValue = 10;

        public uint GrowthTime = 0;

        public Flora(World world)
        {
            this.world = world;
            while (true)
            {
                XCoord = world.GetRandomWidth();
                YCoord = world.GetRandomHeight();
                if (world.Index[XCoord, YCoord].Flora == null)
                {
                    world.Index[XCoord, YCoord].Flora = this;
                    break;
                }
            }

        }

        public int Eat()
        {
            if (GrowthTime < world.Tick)
            {
                GrowthTime = world.Tick + (uint)RandNum.Integer(MinimumRegrowth, MaximumRegrowth);
                return EnergyValue;
            }
            return 0;
        }
    }
}
