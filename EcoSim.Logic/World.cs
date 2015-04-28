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

        public IEntity[] Entities { get; private set; }

        public Flora[] Flora { get; private set; }

        public IEnumerable<WaterSource> WaterSources { get; private set; }

        public const int WaterRate = 2;

        public int FloraCount
        {
            get { return Flora.Count(); }
        }

        public int Height { get; private set; }
        public int Width {get; private set; }

        public bool WorldWrap { get; private set; }

        public uint Tick { get; private set; }

        public World(int width, int height, bool worldWrap)
        {
            Tick = 1;
            Height = height;
            Width = width;
            WorldWrap = worldWrap;
            
            Positions = new Position[width * height];
            Parallel.ForEach(Enumerable.Range(0, width), i =>
            {
                Parallel.ForEach(Enumerable.Range(0, height), j =>
                {
                    Positions[i + (height * j)] = new Position(this, i, j);
                });
            });

            Parallel.ForEach(Positions, p =>
            {
                p.SetSurroundingPositions();
            });

            var waterSources = new List<WaterSource>();
            foreach (var i in Enumerable.Range(0, 40))
            {
                var p = GetRandomPosition();
                var ws = new WaterSource(this, p.X, p.Y, RandNum.Integer(50, 100), (short)RandNum.Integer(3, 12));
                waterSources.Add(ws);
            }
            WaterSources = waterSources;
        }

        public Position GetRandomPosition()
        {
            var x = GetRandomWidth();
            var y = GetRandomHeight();

            var position = GetPosition(x, y);
            return position;
        }

        public void InitialiseCreatures(int startCreatures, int maxCreatures)
        {
            if (maxCreatures < startCreatures)
                throw new Exception("MaxCreatures must be greater than StartCreatures");

            Entities = new IEntity[maxCreatures];
            for (int i = 0; i < maxCreatures; i++)
            {
                Entities[i] = new Creature(this);
            }
            for (int i = 0; i < startCreatures; i++)
            {
                Entities[i].Activate();
            }

        }

        public void InitialiseFlora(int coverage)
        {
            if (coverage < 0 || coverage > 100)
            {
                throw new Exception("Coverage must be a percentage between 0 and 100");
            }
            else
            {
                var flora = new List<Flora>();
                foreach (var pos in Positions)
                {
                    if (pos.Altitude > 0 && RandNum.Integer(100) < coverage)
                        flora.Add(new Flora(this, pos.X, pos.Y));
                }
                Flora = flora.ToArray();
            }
        }

        public int CheckXCoord(int xCoord)
        {
            while (xCoord >= Width)
            {
                if (WorldWrap)
                    xCoord -= Width;
                else
                    return Width - 1;
            }
            while (xCoord < 0)
            {
                if (WorldWrap)
                    xCoord += Width;
                else
                    return 0;
            }
            return xCoord;
        }

        public int CheckYCoord(int yCoord)
        {
            while (yCoord >= Height)
            {
                if (WorldWrap)
                    yCoord -= Height;
                else
                    return Height - 1;
            }
            while (yCoord < 0)
            {
                if (WorldWrap)
                    yCoord += Height;
                else
                    return 0;
            }
            return yCoord;
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

        public IEnumerable<Position> GetRow(int row)
        {
            foreach (var i in Enumerable.Range(0, Width))
            {
                yield return GetPosition(i, row);
            }
        }

        public IEnumerable<Position> GetColumn(int column)
        {
            foreach (var i in Enumerable.Range(0, Height))
            {
                yield return GetPosition(column, i);
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
            var _cX = CheckXCoord(x);
            var _cY = CheckYCoord(y);
            var yOffset = _cY * Height;
            var i = _cX + yOffset;
            return Positions[i];
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
            if (Entities != null)
            {
                Parallel.ForEach(Entities, c =>
                {
                    c.Process();
                });
            }

            if (WaterSources != null)
            {
                Parallel.ForEach(WaterSources, ws =>
                {
                    ws.Process();
                });
            }

            if (Positions != null)
            {
                Parallel.ForEach(Positions, p =>
                {
                    p.ProcessWater();
                });
            }
            Tick++;
        }
    }
}
