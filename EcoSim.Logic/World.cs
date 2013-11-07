using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcoSim.Logic.AI_Entities;

namespace EcoSim.Logic
{
    public class World
    {
        public Position[,] Index;

        public Creature[] Creatures;

        public Flora[] Flora;

        WorldFormer worldFormer;

        public int FloraCount
        {
            get { return Flora.Count(); }
        }

        public readonly int Height;
        public readonly int Width;

        public bool WorldWrap;

        public uint Tick { get; private set; }

        public World(int Width, int Height, bool WorldWrap)
        {
            Tick = 1;
            this.Height = Height;
            this.Width = Width;
            this.WorldWrap = WorldWrap;

            Index = new Position[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Index[i, j] = new Position(this);
                }
            }

            worldFormer = new WorldFormer();
            worldFormer.InitialGeneration(this, 20, 0.5, 0, 5);
            int x = 0;
            foreach(Position p in Index)
            {
                if (!p.Initialised)
                { x++; }
            }
        }

        public void InitialiseCreatures(int StartCreatures, int MaxCreatures)
        {
            if (MaxCreatures < StartCreatures)
                throw new Exception("MaxCreatures must be greater than StartCreatures");

            Creatures = new Creature[MaxCreatures];
            for (int i = 0; i < MaxCreatures; i++)
            {
                Creatures[i] = new Creature(this);
            }
            for (int i = 0; i < StartCreatures; i++)
            {
                Creatures[i].Activate();
            }

        }

        public void InitialiseFlora(int Coverage)
        {
            if (Coverage < 0 || Coverage > 100)
            {
                throw new Exception("Coverage must be a percentage between 0 and 100");
            }
            else
            {
                int cov = Width * Height * Coverage;
                Flora = new Flora[cov / 100];
                for (int i = 0; i < FloraCount; i++)
                {
                    Flora[i] = new Flora(this);
                }
            }
        }

        public int CheckXCoord(int XCoord)
        {
            if (XCoord >= Width)
            {
                if (WorldWrap)
                    return XCoord - Width;
                else
                    return Width - 1;
            }
            else if (XCoord < 0)
            {
                if (WorldWrap)
                    return XCoord + Width;
                else
                    return 0;
            }
            return XCoord;
        }

        public int CheckYCoord(int YCoord)
        {
            if (YCoord >= Height)
            {
                if (WorldWrap)
                    return YCoord - Height;
                else
                    return Width - 1;
            }
            else if (YCoord < 0)
            {
                if (WorldWrap)
                    return YCoord + Height;
                else
                    return 0;
            }
            return YCoord;
        }

        public Position GetPosition(System.Drawing.Point point)
        {
            return GetPosition(point.X, point.Y);
        }

        public Position GetPosition(int x, int y)
        {
            return Index[CheckXCoord(x), CheckYCoord(y)];
        }

        public int GetRandomWidth()
        {
            return RandNum.Integer(Width);
        }

        public int GetRandomHeight()
        {
            return RandNum.Integer(Height);
        }

        public void Process()
        {
            ProcessManager.QueueCreatures(this);
            Tick++;
        }
    }
}
