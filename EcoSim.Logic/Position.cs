using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSim.Logic
{
    public class Position
    {
        public World World{get; private set;}

        private short _Altitude;
        public short Altitude
        {
            get { return _Altitude; }
            set
            {
                if (value >= -100)
                {
                    if (value <= 100)
                    {
                        _Altitude = value;
                    }
                    else
                    {
                        _Altitude = 100;
                    }
                }
                else
                {
                    _Altitude = -100;
                }
            }
        }

        internal bool Initialised = false;

        public bool HasCreature
        {
            get { return Creature != null; }
        }

        public EcoSim.Logic.AI_Entities.Creature Creature { get; set; }
        
        public Flora Flora { get; set; }

        public bool HasFlora
        {
            get { return Flora != null; }
        }

        public bool HasAliveFlora
        {
            get { return HasFlora && Flora.GrowthTime < World.Tick; }
        }

        public Position(World world)
        {
            World = world;
            Altitude = 0;
        }

        public void RemoveCreature()
        {
            Creature = null;
        }

        /// <summary>
        /// Removes and returns the energy value of a plant, if it exists.
        /// </summary>
        /// <returns></returns>
        public int EatFlora()
        {
            if (HasFlora)
            {
                return Flora.Eat();
            }
            return 0;
        }
    }
}
