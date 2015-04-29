using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EcoSim.Logic;
using System.Drawing.Imaging;

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
        /// Gets if the control is drawing.
        /// </summary>
        public bool DrawMode { get; protected set; }

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
                SetWaterColors(Color.DarkBlue, Color.LightSkyBlue, 1, 100);
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

        private int[] GroundColors;
        private int LowestAltitude;
        private int HighestAltitude;

        private void SetGroundColors(Color DarkestColor, Color LightestColor, int lowest, int highest)
        {
            LowestAltitude = lowest;
            HighestAltitude = highest;

            int levels = (highest - lowest) + 1;
            GroundColors = new int[levels];

            double RedStep = DarkestColor.R - LightestColor.R;
            RedStep /= levels;

            double GreenStep = DarkestColor.G - LightestColor.G;
            GreenStep /= levels;

            double BlueStep = DarkestColor.B - LightestColor.B;
            BlueStep /= levels;

            for (int i = 0; i < levels; i++)
            {
                GroundColors[i] = Color.FromArgb(
                    Convert.ToInt32(LightestColor.R + i * RedStep),
                    Convert.ToInt32(LightestColor.G + i * GreenStep),
                    Convert.ToInt32(LightestColor.B + i * BlueStep)).ToArgb();
            }
        }

        private int[] WaterColors;
        private int LowestDepth;
        private int HighestDepth;

        private void SetWaterColors(Color DarkestColor, Color LightestColor, int lowest, int highest)
        {
            LowestDepth = lowest;
            HighestDepth = highest;

            int levels = (highest - lowest) + 1;
            WaterColors = new int[levels];

            double RedStep = DarkestColor.R - LightestColor.R;
            RedStep /= levels;

            double GreenStep = DarkestColor.G - LightestColor.G;
            GreenStep /= levels;

            double BlueStep = DarkestColor.B - LightestColor.B;
            BlueStep /= levels;

            for (int i = 0; i < levels; i++)
            {
                WaterColors[i] = Color.FromArgb(
                    Convert.ToInt32(LightestColor.R + i * RedStep),
                    Convert.ToInt32(LightestColor.G + i * GreenStep),
                    Convert.ToInt32(LightestColor.B + i * BlueStep)).ToArgb();
            }
        }

        private int GetGroundColor(int altitude)
        {
            int a = altitude - LowestAltitude;
            return GroundColors[a];
        }

        private int GetWaterColor(int altitude)
        {
            if (altitude >= HighestDepth)
                altitude = HighestDepth - 1;
            else if (altitude < LowestDepth)
                altitude = LowestDepth;
            return WaterColors[altitude];
        }

        private void DrawFunc()
        {
            if (DrawMode)
            {
                CreaturesToDraw.Clear();

                var bmpData = Draw.LockBuffer(buffer);
                int height = buffer.Height;
                int width = buffer.Width;


                // pixels are drawn in 2 distinct phases, before and after the boundary.
                // by calculating the world wrap boundary ahead of time more efficient data
                // retrieval can be achieved.
                int remainingHeight = 0;
                int preBoundaryHeight = height + YCoordinate;
                if (preBoundaryHeight > World.Height)
                {
                    remainingHeight = preBoundaryHeight - World.Height;
                    if (remainingHeight > World.Height)
                        remainingHeight = World.Height - 1;
                    preBoundaryHeight = World.Height;
                }

                int remainingWidth = 0;
                int preBoundaryWidth = width + XCoordinate;
                if (preBoundaryWidth > World.Width)
                {
                    remainingWidth = preBoundaryWidth - World.Width;
                    if (remainingWidth > World.Width)
                        remainingWidth = World.Width - 1;
                    preBoundaryWidth = World.Width;
                }

                int pixelX = 0;
                int pixelY = 0;

                for (int j = YCoordinate; j < preBoundaryHeight; j++)
                {
                    for (int i = XCoordinate; i < preBoundaryWidth; i++)
                    {
                        DrawPixel(bmpData, i, j, pixelX, pixelY);
                        pixelX++;
                    }
                    for (int i = 0; i < remainingWidth; i++)
                    {
                        DrawPixel(bmpData, i, j, pixelX, pixelY);
                        pixelX++;
                    }
                    pixelX = 0;
                    pixelY++;
                }

                for(int j = 0; j < remainingHeight; j++)
                {
                    for (int i = XCoordinate; i < preBoundaryWidth; i++)
                    {
                        DrawPixel(bmpData, i, j, pixelX, pixelY);
                        pixelX++;
                    }
                    for(int i = 0; i < remainingWidth; i++)
                    {
                        DrawPixel(bmpData, i, j, pixelX, pixelY);
                        pixelX++;
                    }
                    pixelX = 0;
                    pixelY++;
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

        private void DrawPixel(BitmapData bmpData, int x, int y, int pixelX, int pixelY)
        {
            var pos = World.GetUnsafePosition(x, y);
            if (pos.HasCreature)
                CreaturesToDraw.Add(new Point(pixelX, pixelY));
            else if (pos.HasWater)
                Draw.Pixel(bmpData, pixelX, pixelY, GetWaterColor(pos.WaterLevel));
            else if (pos.HasAliveFlora)
                Draw.Pixel(bmpData, pixelX, pixelY, Color.LawnGreen.ToArgb());
            else
                Draw.Pixel(bmpData, pixelX, pixelY, GetGroundColor(pos.Altitude));
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

            var mouseXScale = MouseX * ViewScale;
            var mouseYScale = MouseY * ViewScale;

            var xScale = XCoordinate + (int)Math.Floor(mouseXScale);
            var yScale = YCoordinate + (int)Math.Floor(mouseYScale);

            return World.GetPosition(xScale, yScale);
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