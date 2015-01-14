using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSim.Logic.AI_Entities
{
    public interface IEntity
    {
        int XCoord { get; }
        int YCoord { get; }
        int Size { get; }
        bool Active { get; }
        World World { get; }
        
        void Process();
        void Activate();
    }
}