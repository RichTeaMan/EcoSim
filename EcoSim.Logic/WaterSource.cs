using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim.Logic
{
    public class WaterSource
    {
        public int RemainingWater { get; private set; }

        public short WaterRate { get; private set; }

        public World World { get; private set; }

        public Position Position { get; private set; }

        public int X { get { return Position.X; } }

        public int Y { get { return Position.Y; } }

        public WaterSource(World world, int x, int y, int totalWater, short waterRate)
        {
            World = world;
            Position = World[x, y];
            RemainingWater = totalWater;
            WaterRate = waterRate;
        }

        public void Process()
        {
            Position.WaterLevel += WaterRate;
            

        }
    }
}
