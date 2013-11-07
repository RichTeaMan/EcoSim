using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic.AI_Entities
{
    public class Creature
    {
        

        public int XCoord;
        public int YCoord;

        public bool Active;

        public World World { get; private set; }

        public Creature(World world)
        {
            Active = false;
            this.World = world;
        }

        public void Activate()
        {
            XCoord = World.GetRandomWidth();
            YCoord = World.GetRandomHeight();

            Active = true;
        }

        public static void ProcessCreature(object Creature)
        {
            (Creature as Creature).Process();
        }

        public void Process()
        {
            if(Active)
                Move(RandNum.Integer(-1, 2), RandNum.Integer(-1, 2));
        }

        private void Move(int XVector, int YVector)
        {
            World.Index[XCoord, YCoord].RemoveCreature();
            XCoord = World.CheckXCoord(XCoord + XVector);
            YCoord = World.CheckYCoord(YCoord + YVector);
            World.Index[XCoord, YCoord].Creature = this;
        }
    }
}
