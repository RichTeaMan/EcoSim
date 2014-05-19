using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim.Logic
{
    interface IWorldFormer
    {
        void Generate(World world);

        string Summary { get; }
    }
}
