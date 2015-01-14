using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic.AI_Entities
{
    public abstract class Entity : IEntity
    {
        
        public int XCoord { get; protected set; }
        public int YCoord { get; protected set; }

        public bool Active { get; protected set; }
        public int Size { get; protected set; }

        /// <summary>
        /// Gets the ticks that the next desicion is made.
        /// </summary>
        public int decisionTicks { get; protected set; }

        public World World { get; private set; }

        protected Entity(World world)
        {
            Active = false;
            World = world;
        }

        /// <summary>
        /// Gets a list of Positions this Entity covers. Assumes the Entity is a square.
        /// </summary>
        /// <returns></returns>
        public virtual IList<Position> GetPositions()
        {
            var positions = World.GetPositions(XCoord - (Size / 2), YCoord -  (Size / 2), Size, Size);
            return positions;
        }

        public abstract void Activate();

        public abstract void Process();

        /// <summary>
        /// Moves the Entity, and returns its new position.
        /// </summary>
        /// <param name="XVector"></param>
        /// <param name="YVector"></param>
        /// <returns></returns>
        public Position Move(int XVector, int YVector)
        {
            World[XCoord, YCoord].RemoveCreature();
            XCoord = World.CheckXCoord(XCoord + XVector);
            YCoord = World.CheckYCoord(YCoord + YVector);
            World[XCoord, YCoord].Creature = this;
            return World[XCoord, YCoord];
        }
    }
}
