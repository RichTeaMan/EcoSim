using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic.AI_Entities
{
    public class Creature : Entity
    {
        private int xVector;
        private int yVector;

        public Creature(World world) : base(world)
        {
            Size = 8;
        }

        public override void Activate()
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

        public override void Process()
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
    }
}
