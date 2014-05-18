using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic.AI_Entities
{
    public class Creature
    {
        
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public bool Active { get; private set; }

        // The number of ticks until the next direction desicion is made
        private int decisionTicks = 0;
        private int xVector;
        private int yVector;

        public World World { get; private set; }

        public Creature(World world)
        {
            Active = false;
            this.World = world;
        }

        public IList<Position> GetPositions()
        {
            var positions = World.GetPositions(XCoord - 4, YCoord - 4, 8, 8);
            return positions;
        }

        public void Activate()
        {
            bool inWater;
            do
            {
                XCoord = World.GetRandomWidth();
                YCoord = World.GetRandomHeight();
                var positions = GetPositions();
                inWater = positions.Any(p => p.HasWater);
            }
            while (inWater);

            Active = true;
        }

        public static void ProcessCreature(object Creature)
        {
            (Creature as Creature).Process();
        }

        public void Process()
        {
            if (Active)
            {
                if (decisionTicks == 0)
                {
                    xVector = RandNum.Integer(-1, 2);
                    yVector = RandNum.Integer(-1, 2);
                    decisionTicks = RandNum.Integer(10, 30);
                }
                Move(xVector, yVector);
                var positions = GetPositions();
                var inWater = positions.Any(p => p.HasWater);
                if (inWater)
                {
                    xVector = -xVector;
                    yVector = -yVector;
                }
                foreach (var p in positions)
                {
                    p.EatFlora();
                }
                decisionTicks--;
            }
            
        }

        /// <summary>
        /// Moves the creature, and returns its new position.
        /// </summary>
        /// <param name="XVector"></param>
        /// <param name="YVector"></param>
        /// <returns></returns>
        private Position Move(int XVector, int YVector)
        {
            World[XCoord, YCoord].RemoveCreature();
            XCoord = World.CheckXCoord(XCoord + XVector);
            YCoord = World.CheckYCoord(YCoord + YVector);
            World[XCoord, YCoord].Creature = this;
            return World[XCoord, YCoord];
        }
    }
}
