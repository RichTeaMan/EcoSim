using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcoSim.Logic.AI_Entities;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace EcoSim.Logic
{
    public class World
    {
        public Position[] Positions { get; private set; }

        public Creature[] Creatures { get; private set; }

        public Flora[] Flora { get; private set; }

        RandomPointsWorldFormer worldFormer;

        private ConcurrentStack<Position> PositionProcess;

        public int FloraCount
        {
            get { return Flora.Count(); }
        }

        public int Height { get; private set; }
        public int Width {get; private set; }

        public bool WorldWrap { get; private set; }

        public uint Tick { get; private set; }

        public World(int Width, int Height, bool WorldWrap)
        {
            Tick = 1;
            this.Height = Height;
            this.Width = Width;
            this.WorldWrap = WorldWrap;

            Positions = new Position[Width * Height];
            Parallel.ForEach(Enumerable.Range(0, Width), i =>
            {
                Parallel.ForEach(Enumerable.Range(0, Height), j =>
                {
                    Positions[i + (Height * j)] = new Position(this, i, j);
                });
            });
            
            PositionProcess = new ConcurrentStack<Position>();
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
                var flora = new List<Flora>();
                foreach (var pos in Positions)
                {
                    if (pos.Altitude > 0 && RandNum.Integer(100) < Coverage)
                        flora.Add(new Flora(this, pos.X, pos.Y));
                }
                Flora = flora.ToArray();
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

        /// <summary>
        /// Gets the position with the given coordinates. Will wrap if the position is out of bounds.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Position this[int x, int y]
        {
            get
            {
                return GetPosition(x, y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Position GetPosition(System.Drawing.Point point)
        {
            return GetPosition(point.X, point.Y);
        }

        public IList<Position> GetPositions(int x, int y, int width, int height)
        {
            int cX = CheckXCoord(x);
            int cY = CheckYCoord(y);
            var positions = new List<Position>();
            foreach (var i in Enumerable.Range(cX, width))
            {
                int iX = i;
                if (i >= Width)
                    iX -= Width;
                foreach (var j in Enumerable.Range(cY, height))
                {
                    int jY = j;
                    if (j >= Height)
                        jY -= Height;
                    positions.Add(GetUnsafePosition(iX, jY));
                }
            }
            return positions;
        }

        /// <summary>
        /// Gets the position with the given coordinates. Will world wrap if the position is out of bounds.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Position GetPosition(int x, int y)
        {
            return Positions[CheckXCoord(x) + (CheckYCoord(y) * Height)];
            
        }

        /// <summary>
        /// Gets the position with the given coordinates. This code is unsafe, will not world wrap and will
        /// crash if non existant coordinates are given. This method has much higher performance than the
        /// other get position methods.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Position GetUnsafePosition(int x, int y)
        {
            unsafe
            {
                return Positions[x + ((y) * Height)];
            }
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
            
            Parallel.ForEach(Creatures, c =>
            {
                c.Process();
            });

            var positionProcess = Interlocked.Exchange<ConcurrentStack<Position>>(ref PositionProcess, new ConcurrentStack<Position>());

            Position pos;
            while (positionProcess.TryPop(out pos))
            {
                pos.ProcessWater();
            }

            Tick++;
        }

        public void AddToProcessQueue(Position position)
        {
            PositionProcess.Push(position);
        }
    }
}
