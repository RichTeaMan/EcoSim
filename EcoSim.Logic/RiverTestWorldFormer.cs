using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim.Logic
{
    class RiverTestWorldFormer : IWorldFormer
    {
        public string Summary { get { return "Creates a world for testing water flow."; } }

        public RiverTestWorldFormer()
        {
            
        }

        public void Generate(World world)
        {
            var height = (short)world.Height;

            foreach (var rowI in Enumerable.Range(0, world.Height - 1))
            {
                foreach (var p in world.GetRow(rowI))
                {
                    p.Altitude = height;
                }
                height--;
            }
        }
    }
}
