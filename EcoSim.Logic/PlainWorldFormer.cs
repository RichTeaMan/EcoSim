using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim.Logic
{
    public class PlainWorldFormer : IWorldFormer
    {
        public string Summary
        {
            get { return "Creates a plain world at the given altitude. Water will only generate at altitude below 0."; }
        }

        public short Altitude { get; set; }

        public PlainWorldFormer()
        {
            Altitude = 5;
        }

        public void Generate(World world)
        {
            foreach (var p in world.Positions)
            {
                p.Altitude = Altitude;
            }
        }
    }
}
