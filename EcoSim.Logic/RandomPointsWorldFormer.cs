using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace EcoSim.Logic
{
    public class RandomPointsWorldFormer : IWorldFormer
    {
        class RandomPointsWorldSeed
        {
            public RandomPointsWorldSeed(World world, RandomPointsWorldFormer worldFormer, Point point, Position parentPosition)
            {
                this.world = world;
                this.worldFormer = worldFormer;
                this.point = point;
                this.parentPositon = parentPosition;
            }

            public World world;
            public RandomPointsWorldFormer worldFormer;
            public Point point;
            public Position parentPositon;
        }

        int WorldSizePixels;
        int PixelsCompleted = 0;
        int WorkingThreads = 0;

        public int Seeds { get; set; }
        public double HighAltitudeProbability { get; set; }
        public int MinStep { get; set; }
        public int MaxStep { get; set; }

        public string Summary { get { return "Creates a world getting random coordinates and then making random steps in altitude from each of those points."; } }

        public void Generate(World world)
        {
            WorldSizePixels = world.Width * world.Height;
            for (int i = 0; i < Seeds; i++)
            {
                int y = world.GetRandomHeight();
                int x = world.GetRandomWidth();

                if (Monitor.TryEnter(world[x, y]))
                {
                    if (!world[x, y].Initialised)
                    {
                        world[x, y].Altitude = 0;// (short)world.random.Next(-100, 101);
                        world[x, y].Initialised = true;
                        RandomPointsWorldSeed worldSeed = new RandomPointsWorldSeed(world, this, new Point(x, y), world.GetPosition(x, y));

                        ThreadPool.QueueUserWorkItem(ProcessSeed, worldSeed);
                        Interlocked.Increment(ref WorkingThreads);
                        Interlocked.Increment(ref PixelsCompleted);
                    }
                    Monitor.Exit(world[x, y]);
                }
                else
                    Seeds--;
            }
            while (WorkingThreads > 0)
                Thread.Sleep(5);
            return;
        }
        
        static void ProcessSeed(object WorldSeed)
        {
            RandomPointsWorldSeed worldSeed = (RandomPointsWorldSeed)WorldSeed;
            if (RandNum.Double() > 0.1)
            {
                ThreadPool.QueueUserWorkItem(ProcessSeed, WorldSeed);
                return;
            }

            Point p = worldSeed.point;

            Position Pos = worldSeed.parentPositon; //worldSeed.world.GetPosition(p);
            for (int i = 0; i < 8; i++)
            {
                Point p2 = new Point(p.X, p.Y);
                switch (i)
                {
                    case 0: //top right
                        p2.X++;
                        p2.Y--;
                        break;

                    case 1: //right
                        p2.X++;
                        break;

                    case 2: //bottom right
                        p2.X++;
                        p2.Y++;
                        break;

                    case 3: //bottom
                        p2.Y++;
                        break;

                    case 4: //bottom left
                        p2.X--;
                        p2.Y++;
                        break;

                    case 5: //left
                        p2.X--;
                        break;

                    case 6: //top left
                        p2.X--;
                        p2.Y--;
                        break;

                    case 7: //top
                        p2.Y--;
                        break;
                }

                p2 = new Point(worldSeed.world.CheckXCoord(p2.X), worldSeed.world.CheckYCoord(p2.Y));
                Position Pos2 = worldSeed.world.GetPosition(p2);

                if (Monitor.TryEnter(Pos2))
                {
                    if (!Pos2.Initialised)
                    {
                        Pos2.Initialised = true;

                        short Step = (short)RandNum.Integer(2); //(MinStep, MaxStep);
                        if (Step == 0)
                        {
                            Pos2.Altitude = (short)Pos.Altitude;
                        }
                        else
                        {
                            if (RandNum.Double() > worldSeed.worldFormer.HighAltitudeProbability)
                                Pos2.Altitude = (short)(Pos.Altitude + Step);
                            else
                                Pos2.Altitude = (short)(Pos.Altitude - Step);
                        }

                        Interlocked.Increment(ref worldSeed.worldFormer.PixelsCompleted);

                        RandomPointsWorldSeed NewWorldSeed = new RandomPointsWorldFormer.RandomPointsWorldSeed(worldSeed.world, worldSeed.worldFormer, p2, Pos2);

                        Interlocked.Increment(ref worldSeed.worldFormer.WorkingThreads);
                        ThreadPool.QueueUserWorkItem(ProcessSeed, NewWorldSeed);
                    }
                    Monitor.Exit(Pos2);
                }
            }
            Interlocked.Decrement(ref worldSeed.worldFormer.WorkingThreads);
        }


    }
}



