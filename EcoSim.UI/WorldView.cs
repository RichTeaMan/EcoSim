using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EcoSim.Logic;

namespace EcoSim.UI
{
    public partial class WorldView : UserControl
    {
        #region DESIGNER_PROPERTIES

        private int _XCoord = 0;
        [Browsable(true)]
        public int XCoordinate
        {
            get { return _XCoord; }
            set
            {
                if (World == null)
                    return;
                if (value < 0)
                {
                    _XCoord = World.Width + value;
                }
                else if (value >= World.Width)
                {
                    _XCoord = value - World.Width;
                }
                else
                    _XCoord = value;
            }
        }

        private int _YCoord = 0;
        [Browsable(true)]
        public int YCoordinate
        {
            get { return _YCoord; }
            set
            {
                if (World == null)
                    return;
                if (value < 0)
                {
                    _YCoord = World.Height + value;
                }
                else if (value >= World.Height)
                {
                    _YCoord = value - World.Height;
                }
                else
                    _YCoord = value;
            }
        }

        private bool _AllowNavigation = true;
        [Browsable(true)]
        public bool AllowNavigation
        {
            get { return _AllowNavigation; }
            set { _AllowNavigation = value; }
        }

        private double _ViewScale = 1;
        public double ViewScale
        {
            get { return _ViewScale; }
            set
            {
                if (value > 4)
                    _ViewScale = 4;
                else if (value < 0.1)
                    _ViewScale = 0.1;
                else
                    _ViewScale = value;
                BufferResize();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets if the control is drawing.
        /// </summary>
        public bool DrawMode = false;

        List<Point> CreaturesToDraw;
        Bitmap buffer;

        public World World { get; private set; }

        public long FramesDrawn { get; private set; }
        public long FramesPainted { get; private set; }

        public WorldView()
        {
            InitializeComponent();
            CreaturesToDraw = new List<Point>();
            DoubleBuffered = true;

            BufferResize();

            if (!DesignMode)
            {
                this.Paint += new PaintEventHandler(WorldView_Paint);
                SetGroundColors(Color.LightGoldenrodYellow, Color.Brown, -100, 100);
            }
            WaterColor = Color.FromArgb(130, Color.LightSeaGreen);
        }

        Color WaterColor;

        public void BeginDraw(World world)
        {
            World = world;
            RefreshTimer.Start();
            DrawMode = true;
        }

        public void StopDraw()
        {
            RefreshTimer.Stop();
            DrawMode = false;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (UpKey)
                YCoordinate -= 10;
            if (RightKey)
                XCoordinate += 10;
            if (DownKey)
                YCoordinate += 10;
            if (LeftKey)
                XCoordinate -= 10;
            DrawFunc();   
        }

        private void WorldView_Paint(object sender, PaintEventArgs e)
        {
            DrawFunc();
        }

        private Color[] GroundColors;
        private int LowestAltitude;
        private int HighestAltitude;

        private void SetGroundColors(Color DarkestColor, Color LightestColor, int Lowest, int Highest)
        {
            this.LowestAltitude = Lowest;
            this.HighestAltitude = Highest;

            int Levels = Highest - Lowest;
            GroundColors = new Color[Levels];

            double RedStep = DarkestColor.R - LightestColor.R;
            RedStep /= Levels;

            double GreenStep = DarkestColor.G - LightestColor.G;
            GreenStep /= Levels;

            double BlueStep = DarkestColor.B - LightestColor.B;
            BlueStep /= Levels;

            for (int i = 0; i < Levels; i++)
            {
                GroundColors[i] = Color.FromArgb(
                    Convert.ToInt32(LightestColor.R + i * RedStep),
                    Convert.ToInt32(LightestColor.G + i * GreenStep),
                    Convert.ToInt32(LightestColor.B + i * BlueStep));
            }
        }

        private Color GetGroundColor(int Altitude)
        {
            int a = -LowestAltitude + Altitude;
            return GroundColors[a];
        }

        private void DrawFunc()
        {
            if (DrawMode)
            {
                CreaturesToDraw.Clear();

                int Y = YCoordinate;
                int X = XCoordinate;
                var bmpData = Draw.LockBuffer(buffer);
                int height = buffer.Height;
                int width = buffer.Width;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        if (World.Index[X, Y].HasCreature)
                            CreaturesToDraw.Add(new Point(i, j));
                        //
                        //else
                        //if (World.Index[X, Y].Marked)
                        //    Draw.Pixel(bmpData, i, j, Color.Red);
                        else if (World.Index[X, Y].Altitude < 0)
                            Draw.Pixel(bmpData, i, j, WaterColor);
                        else if (World.Index[X, Y].HasAliveFlora)
                            Draw.Pixel(bmpData, i, j, Color.LawnGreen);
                        //Draw.Pixel(bmpData, i, j, Draw.GetBlendedColor(GetGroundColor(Interface.Position.Index[X, Y].Altitude), WaterColor));
                        else
                            Draw.Pixel(bmpData, i, j, GetGroundColor(World.Index[X, Y].Altitude));
                        X++;
                        if (X >= World.Width)
                            X -= World.Width;
                    }
                    Y++;
                    if (Y >= World.Height)
                        Y -= World.Height;
                    X = XCoordinate;
                }
                foreach (Point p in CreaturesToDraw)
                {
                    Draw.Circle(bmpData, 4, p.X, p.Y, Color.Purple);
                }
                buffer.UnlockBits(bmpData);
                Invalidate();
                FramesDrawn++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(buffer, destRect, sourceRect, GraphicsUnit.Pixel);
            FramesPainted++;
        }

        Rectangle destRect;
        Rectangle sourceRect;

        private void WorldView_Resize(object sender, EventArgs e)
        {
            destRect = new Rectangle(0, 0, Width, Height);
            BufferResize();
        }

        private void BufferResize()
        {
            double w = Width * ViewScale;
            double h = Height * ViewScale;
            buffer = new Bitmap((int)w, (int)h);
            sourceRect = new Rectangle(0, 0, (int)w, (int)h);
        }

        private int MouseX = 0;
        private int MouseY = 0;

        private void WorldView_MouseMove(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }

        public Position GetPositionAtMouseLocation()
        {
            if (World == null)
                return null;
            return World.GetPosition(XCoordinate + MouseX, YCoordinate + MouseY);
        }

        private bool UpKey = false;
        private bool DownKey = false;
        private bool LeftKey = false;
        private bool RightKey = false;

        private void WorldView_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void WorldView_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void WorldView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    UpKey = false;
                    break;

                case Keys.Right:
                    RightKey = false;
                    break;

                case Keys.Down:
                    DownKey = false;
                    break;

                case Keys.Left:
                    LeftKey = false;
                    break;
            }
        }

        private void WorldView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    UpKey = true;
                    break;

                case Keys.Right:
                    RightKey = true;
                    break;

                case Keys.Down:
                    DownKey = true;
                    break;

                case Keys.Left:
                    LeftKey = true;
                    break;
            }
        }

        private void WorldView_Click(object sender, EventArgs e)
        {

        }

    }
}