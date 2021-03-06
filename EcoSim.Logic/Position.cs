﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EcoSim.Logic
{
    public sealed class Position
    {
        public World World { get; private set; }

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

        public short TotalAltitude
        {
            get
            {
                return (short)(Altitude + WaterLevel);
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        internal bool Initialised = false;

        public bool HasCreature
        {
            get { return Creature != null; }
        }

        public EcoSim.Logic.AI_Entities.Entity Creature { get; set; }
        
        public Flora Flora { get; set; }

        public bool HasFlora
        {
            get { return Flora != null; }
        }

        public bool HasAliveFlora
        {
            get { return HasFlora && Flora.GrowthTime < World.Tick; }
        }

        private int _waterLevel;
        public int WaterLevel { get { return _waterLevel; } }

        public bool HasWater { get { return WaterLevel > 0; } }

        public Position NorthPosition { get; private set; }
        public Position EastPosition { get; private set; }
        public Position SouthPosition { get; private set; }
        public Position WestPosition { get; private set; }

        public IEnumerable<Position> SurroundingPositions { get; private set; }

        public Position(World world, int x, int y)
        {
            World = world;
            Altitude = 0;
            X = x;
            Y = y;
        }

        public void SetSurroundingPositions()
        {
            NorthPosition = GetNorthPosition();
            EastPosition = GetEastPosition();
            SouthPosition = GetSouthPosition();
            WestPosition = GetWestPosition();

            SurroundingPositions = new[] { NorthPosition, EastPosition, SouthPosition, WestPosition };
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
        

        /// <summary>
        /// Changes the water by the given amount, ie WaterLevel = WaterLevel + level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public int AdjustWaterLevel(int level)
        {
            Interlocked.Add(ref _waterLevel, level);
            // is there an atomic way to do this check?
            if (_waterLevel < 0)
                _waterLevel = 0;
            return _waterLevel;
        }

        private Position GetNorthPosition()
        {
            return World[X, Y - 1];
        }

        private Position GetEastPosition()
        {
            return World[X + 1, Y];
        }

        private Position GetSouthPosition()
        {
            return World[X, Y + 1];
        }

        private Position GetWestPosition()
        {
            return World[X - 1, Y];
        }
    }
}
