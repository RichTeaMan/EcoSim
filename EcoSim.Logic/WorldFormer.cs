using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace EcoSim.Logic
{
    public class WorldFormer
    {
        class WorldSeed
        {
            public WorldSeed(World world, WorldFormer worldFormer, Point point, Position parentPosition)
            {
                this.world = world;
                this.worldFormer = worldFormer;
                this.point = point;
                this.parentPositon = parentPosition;
            }

            public World world;
            public WorldFormer worldFormer;
            public Point point;
            public Position parentPositon;
        }

        private static WaitCallback callBack = new WaitCallback(ProcessSeed);

        private double HighAltitudeProbability;
        int WorldSizePixels;
        int PixelsCompleted = 0;
        int WorkingThreads = 0;
        public void InitialGeneration(World world, int Seeds, double HighAltitudeProbabilty, int MinStep, int MaxStep)
        {
            this.HighAltitudeProbability = HighAltitudeProbabilty;
            WorldSizePixels = world.Width * world.Height;
            for (int i = 0; i < Seeds; i++)
            {
                int y = world.GetRandomHeight();
                int x = world.GetRandomWidth();

                if (Monitor.TryEnter(world.Index[x, y]))
                {
                    if (!world.Index[x, y].Initialised)
                    {
                        world.Index[x, y].Altitude = 0;// (short)world.random.Next(-100, 101);
                        world.Index[x, y].Initialised = true;
                        WorldSeed worldSeed = new WorldSeed(world, this, new Point(x, y), world.GetPosition(x, y));
                        
                        ThreadPool.QueueUserWorkItem(WorldFormer.callBack, worldSeed);
                        Interlocked.Increment(ref WorkingThreads);
                        Interlocked.Increment(ref PixelsCompleted);
                    }
                    Monitor.Exit(world.Index[x, y]);
                }
                else
                    Seeds--;
            }
            while (WorkingThreads > 0)
                if (WorkingThreads < 20)
                    Thread.Sleep(1);
            Thread.Sleep(5);
            return;
        }

        private static object _lock;

        static void ProcessSeed(object WorldSeed)
        {
            WorldSeed worldSeed = (WorldSeed)WorldSeed;
            if (worldSeed.worldFormer.WorkingThreads > 20 && RandNum.Double() > 0.1)
            {
                ThreadPool.QueueUserWorkItem(callBack, WorldSeed);
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

                        WorldSeed NewWorldSeed = new WorldFormer.WorldSeed(worldSeed.world, worldSeed.worldFormer, p2, Pos2);

                        Interlocked.Increment(ref worldSeed.worldFormer.WorkingThreads);
                        ThreadPool.QueueUserWorkItem(callBack, NewWorldSeed);


                    }
                    Monitor.Exit(Pos2);
                }
            }
            Interlocked.Decrement(ref worldSeed.worldFormer.WorkingThreads);
        }


    }
}



