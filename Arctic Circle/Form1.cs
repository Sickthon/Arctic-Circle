using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Arctic_Circle
{
    public partial class MainWindow : Form
    {
        #region
        /// <summary>
        /// You can change the save location for the renderings in the "SaveImageButton_Click" class.
        /// </summary>
        string pathString;

        /// <summary>
        /// Length in pixels of the shorter part of the Rectangle.
        /// </summary>
        int edge_Length;

        /// <summary>
        /// This Array contains 4 different unit vectors i.e. the directions used to render the diamond.
        /// </summary>
        Point[] Directions = new Point[5];

        /// <summary>
        /// List of the Coordinates of significant verteces of the diamond sorted by Y-Value.
        /// </summary>
        List<Point> DiamondPoints = new List<Point>();

        /// <summary>
        /// Final size of the diamond, the diagonals will be of the size 2 * DiamondIterations.
        /// </summary>
        int DiamondIterations;

        /// <summary>
        /// Pause[ms] between each increment.
        /// </summary>
        int Pause_Interval;

        /// <summary>
        /// The start size of the diamond, values apart from 1 don't make much sense.
        /// </summary>
        int startSize;

        /// <summary>
        /// This counts logarithmically with base 2 the amount of different possible diamonds at the current size.
        /// </summary>
        long PossibilitiesCounter = 0;

        /// <summary>
        /// This list contains all the Rectangles. They are sorted by their y-value into different lists.
        /// </summary>
        List<List<Rectangle>> Rects_List = new List<List<Rectangle>>();

        /// <summary>
        /// The list contains for each Rectangle in Rects_List at the same position the corresponding unit vector for its movement.
        /// </summary>
        List<List<Point>> MovementDirections_List = new List<List<Point>>(); //List of pointed unit vectors

        /// <summary>
        /// A new Random instance used to decide how to fill free 2x2 fields.
        /// </summary>
        Random r = new Random();

        /// <summary>
        /// A new Pen instance used to draw the arrows of the movement direction on each Rectangle. This doesn't make sense if the rectangle's size is just two pixels.
        /// </summary>
        Pen p = new Pen(Brushes.White);

        /// <summary>
        /// A new Font instance used to draw the arrows of the movement direction on each Rectangle. This doesn't make sense if the rectangle's size is just two pixels.
        /// </summary>
        Font f = new Font("Times New Roman", 12.0f);

        /// <summary>
        /// Decides whether a new rendering is started or if the previous one is continued.
        /// </summary>
        bool noClear = false;

        /// <summary>
        /// Continuing a previous rendering is only possible if there was a previous one.
        /// </summary>
        bool firstIteration = true;

        /// <summary>
        /// Decides whether the rendering should be drawn in the form after each iteration.
        /// </summary>
        bool DrawInForm = true;

        /// <summary>
        /// I used this to save the time used for each increment in order to create the duration prediction function.
        /// </summary>
        List<long> timeList = new List<long>();

        /// <summary>
        /// This Graphics instance is used to draw into the form.
        /// </summary>
        Graphics g;

        /// <summary>
        /// A Dictionary used to draw the arrows of the movement direction on each Rectangle. This doesn't make sense if the rectangle's size is just two pixels.
        /// </summary>
        Dictionary<Point, string> RectSymbols_dict = new Dictionary<Point, string>()
        {
            { new Point(1, 0), "→" },
            { new Point(-1, 0), "←" },
            { new Point(0, 1), "↓" },
            { new Point(0, -1), "↑" }
        };

        /// <summary>
        /// A Dictionary used to convert the orientation of the rectangle to its corresponding colour when drawin in the form.
        /// </summary>
        Dictionary<Point, Brush> RectBrushes_dict = new Dictionary<Point, Brush>()
        {
            { new Point(1, 0), Brushes.LawnGreen },
            { new Point(-1, 0), Brushes.Blue },
            { new Point(0, 1), Brushes.Yellow },
            { new Point(0, -1),Brushes.Red }
        };

        /// <summary>
        /// A Dictionary used to convert the orientation of the rectangle to its corresponding colour when converting to bitmap.
        /// </summary>
        Dictionary<Point, Color> RectColours_dict = new Dictionary<Point, Color>()
        {
            { new Point(1, 0), Color.LawnGreen },
            { new Point(-1, 0), Color.Blue },
            { new Point(0, 1), Color.Yellow },
            { new Point(0, -1),Color.Red }
        };
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main Function that is called for each new rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_button_Click(object sender, EventArgs e)
        {
            if (noClear && !firstIteration)
            {
                startSize = DiamondIterations + 1;
                DiamondIterations = Convert.ToInt32(EndSize_textBox.Text);
            }
            else
            {
                firstIteration = false;
                startSize = Convert.ToInt32(StartSize_textBox.Text);
                DiamondIterations = Convert.ToInt32(EndSize_textBox.Text);
                edge_Length = Convert.ToInt32(RectangleSize_textBox.Text);
                Pause_Interval = Convert.ToInt32(PauseInterval_textBox.Text);

                for (int i = 0; i < 4; i++)
                {
                    Directions[i] = new Point(Convert.ToInt32(edge_Length * Math.Cos(i * Math.PI / 2)), Convert.ToInt32(edge_Length * Math.Sin(i * Math.PI / 2)));
                }
                Directions[4] = new Point(Convert.ToInt32(edge_Length), 0);

                Rects_List.Clear();
                MovementDirections_List.Clear();
                PossibilitiesCounter = 0;
                DiamondPoints.Clear();
                g = this.CreateGraphics();

                for (int i = 0; i < (startSize - 1) * 2; i++)
                {
                    Rects_List.Add(new Rectangle[0].ToList());
                    MovementDirections_List.Add(new Point[0].ToList());
                }
            }

            Point DrawStart_point;

            for (int i = startSize; i <= DiamondIterations; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                label5.Text = String.Format("{0} / {1}", i, DiamondIterations);
                PossibilitiesCount_label.Text = "2^" + Convert.ToString(PossibilitiesCounter);
                Application.DoEvents();
                DrawStart_point = new Point(ClientSize.Width / 2 - Convert.ToInt32(edge_Length),
                    ClientSize.Height / 2 - i * Convert.ToInt32(edge_Length));
                DrawDiamond(i, DrawStart_point);

                RectMover();

                RectIterator();
                if (DrawInForm)
                {
                    g.Clear(Color.Black);
                    RectDrawer();
                }
                DrawDiamond(i, DrawStart_point);
                Thread.Sleep(Pause_Interval);
                watch.Stop();
                timeList.Add(watch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Function that generates the relevant Diamond Points. Could possibly draw the diamond but it's not needed as the rectangles fill the diamond.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="DrawPosition"></param>
        void DrawDiamond(int size, Point DrawPosition)
        {
            DiamondPoints.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int q = 0; q < 2; q++)
                {
                    //if (DrawInForm){ g.DrawLine(p, DrawPosition.X, DrawPosition.Y, DrawPosition.X + Directions[i].X, DrawPosition.Y + Directions[i].Y); }
                    DrawPosition = new Point(DrawPosition.X + Directions[i].X, DrawPosition.Y + Directions[i].Y);
                    if ((q == 1 && (i == 0 || i == 3)) || ((i == 1 || i == 3) && q == 0)) { DiamondPoints.Add(DrawPosition); }
                }

                for (int u = 0; u < size - 1; u++)
                {
                    for (int v = 1; v >= 0; v--)
                    {
                        //if (DrawInForm) { g.DrawLine(p, DrawPosition.X, DrawPosition.Y, DrawPosition.X + Directions[i + v].X, DrawPosition.Y + Directions[i + v].Y); }
                        DrawPosition = new Point(DrawPosition.X + Directions[i + v].X, DrawPosition.Y + Directions[i + v].Y);
                        if (((i == 1 || i == 2) && v == 1) || ((i == 0 || i == 3) && v == 0)) { DiamondPoints.Add(DrawPosition); }
                    }
                }
            }
            QuickSort(DiamondPoints);
            BubbleSort(DiamondPoints);
        }

        /// <summary>
        /// Sorts the DiamondPoins according to their y-value
        /// </summary>
        /// <param name="Input"></param>
        void QuickSort(List<Point> Input)
        {
            if (Input.Count == 2 || Input.Count == 0) { return; }

            int pivot = Input[(Input.Count - 1) / 2].Y;

            int bI = 0;
            int cI = 0;
            int pI = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                if (Input[i].Y < pivot)
                {
                    bI++;
                }
                else if (Input[i].Y > pivot)
                {
                    cI++;
                }
                else if (Input[i].Y == pivot)
                {
                    pI++;
                }
            }

            List<Point> b = new Point[bI].ToList();
            List<Point> c = new Point[cI].ToList();
            List<Point> p = new Point[pI].ToList();

            bI = 0;
            cI = 0;
            pI = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                if (Input[i].Y < pivot)
                {
                    b[bI] = Input[i];
                    bI++;
                }
                else if (Input[i].Y > pivot)
                {
                    c[cI] = Input[i];
                    cI++;
                }
                else if (Input[i].Y == pivot)
                {
                    p[pI] = Input[i];
                    pI++;
                }
            }

            QuickSort(b);
            QuickSort(c);
            Input.Clear();
            Input.AddRange(b);
            Input.AddRange(p);
            Input.AddRange(c);
        }

        /// <summary>
        /// Sorts the the DiamondPoints of the same y-value according to their x-value
        /// </summary>
        /// <param name="Input"></param>
        void BubbleSort(List<Point> Input)
        {
            for (int v = 1; v < Input.Count - 1; v+=2)
            {
                if (Input[v].X < Input[v - 1].X)
                {
                    Input.Insert(v - 1, Input[v]);
                    Input.RemoveAt(v + 1);
                }
            }
        }

        /// <summary>
        /// Draws all Rectangles onto the form.
        /// </summary>
        void RectDrawer()
        {
            for (int i = 0; i < Rects_List.Count; i++)
            {
                for (int h = 0; h < Rects_List[i].Count; h++)
                {
                    g.FillRectangle(RectBrushes_dict[MovementDirections_List[i][h]], Rects_List[i][h]);
                    //g.DrawString(RectSymbols_dict[MovementDirections_List[i]], f, Brushes.Black, new Point(Rects_List[i].X, Rects_List[i].Y));
                }
            }
        }

        /// <summary>
        /// Checks the diamond for free 2x2 fields.
        /// </summary>
        /// <param name="StartPosition"></param>
        /// <param name="g"></param>
        void RectIterator()
        {
            for (int u = 0; u < DiamondPoints.Count - 3; u += 2)
            {
                for (int v = DiamondPoints[u].X; v < DiamondPoints[u + 1].X - edge_Length; v += edge_Length)
                {
                    bool isFree = true;
                    RectIteratorHelper(u, v, ref isFree);
                    if (isFree)
                    {
                        newBlock(new Point(v, DiamondPoints[u].Y), u);
                    }
                }
            }
        }

        /// <summary>
        /// Sub-method of RectIterator.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="isFree"></param>
        void RectIteratorHelper(int u, int v, ref bool isFree)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y <= 2; y += 2)
                {
                    if (y == 2 && ((x == 0 && v + edge_Length * x < DiamondPoints[u + y].X) ||
                        (x == 1 && v + edge_Length * (x + 1) > DiamondPoints[u + y + 1].X)))
                    {
                        isFree = false;
                        return;
                    }
                    for (int h = u/2 + y/2 - 1; h <= u/2 + y/2 + 1; h++)
                    {
                        if (h < 0) { h = 0; }
                        if (h >= Rects_List.Count) { break; }
                        for (int i = 0; i < Rects_List[h].Count; i++)
                        {
                            if ((v + x * edge_Length == Rects_List[h][i].X && DiamondPoints[u + y].Y == Rects_List[h][i].Y) ||
                                (v + x * edge_Length == Rects_List[h][i].X + Rects_List[h][i].Width / 2 
                                && DiamondPoints[u + y].Y == Rects_List[h][i].Y) ||
                                (v + x * edge_Length == Rects_List[h][i].X && DiamondPoints[u + y].Y == Rects_List[h][i].Y + 
                                Rects_List[h][i].Height / 2))
                            {
                                isFree = false;
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Fills each free 2x2 field with a pair of rectangles.
        /// </summary>
        /// <param name="Position"></param>
        void newBlock(Point Position, int v)
        {
            PossibilitiesCounter += 2;
            if (r.Next(0, 2) == 0)
            {
                Rects_List[v / 2].Add(new Rectangle(Position, new Size(2 * edge_Length, edge_Length)));
                MovementDirections_List[v / 2].Add(new Point(0, -1));

                Rects_List[v / 2 + 1].Add(new Rectangle(new Point(Position.X, Position.Y + edge_Length), new Size(2 * edge_Length, edge_Length)));
                MovementDirections_List[v / 2 + 1].Add(new Point(0, 1));
            }
            else
            {
                Rects_List[v / 2].Add(new Rectangle(Position, new Size(edge_Length, 2 * edge_Length)));
                MovementDirections_List[v / 2].Add(new Point(-1, 0));

                Rects_List[v / 2].Add(new Rectangle(new Point(Position.X + edge_Length, Position.Y), new Size(edge_Length, 2 * edge_Length)));
                MovementDirections_List[v / 2].Add(new Point(1, 0));
            }
        }

        /// <summary>
        /// Moves the Rectangles according to the direction in MovementDirections_List.
        /// </summary>
        void RectMover()
        {
            bool isNotIntersecting = true;
            List<List<Rectangle>> Helper1 = new List<List<Rectangle>>(); //Helper0.ToList();
            List<List<Point>> Helper2 = new List<List<Point>>();

            Rects_List.Insert(0, new Rectangle[0].ToList());
            Rects_List.Add(new Rectangle[0].ToList());
            MovementDirections_List.Insert(0, new Point[0].ToList());
            MovementDirections_List.Add(new Point[0].ToList());

            for(int i = 0; i < Rects_List.Count; i++)
            {
                Helper1.Add(new Rectangle[0].ToList());
                Helper2.Add(new Point[0].ToList());
            }

            for (int v = 1; v < Rects_List.Count - 1; v++)
            {
                for (int u = 0; u < Rects_List[v].Count; u++)
                {
                    for (int y = v - 2; y <= v + 2 && y < Rects_List.Count - 1; y++)
                    {
                        if(y < 0) { y = 0; }
                        for (int x = 0; x < Rects_List[y].Count; x++)
                        {
                            Rectangle Intersect = Rectangle.Intersect(Rects_List[v][u], Rects_List[y][x]);
                            if (((Intersect.Height == 0 && Intersect.Width == 2 * edge_Length) ||
                                (Intersect.Height == 2 * edge_Length && Intersect.Width == 0)) &&
                                ((MovementDirections_List[v][u].X == -1 && MovementDirections_List[y][x].X == 1 && Rects_List[v][u].X > Rects_List[y][x].X) ||
                                (MovementDirections_List[v][u].X == 1 && MovementDirections_List[y][x].X == -1 && Rects_List[v][u].X < Rects_List[y][x].X) ||
                                (MovementDirections_List[v][u].Y == -1 && MovementDirections_List[y][x].Y == 1 && Rects_List[v][u].Y > Rects_List[y][x].Y) ||
                                (MovementDirections_List[v][u].Y == 1 && MovementDirections_List[y][x].Y == -1 && Rects_List[v][u].Y < Rects_List[y][x].Y)))
                            {
                                isNotIntersecting = false;
                            }
                        }
                    }
                    if (isNotIntersecting)
                    {
                        Helper1[v + MovementDirections_List[v][u].Y].Add(new Rectangle(Rects_List[v][u].X + MovementDirections_List[v][u].X * edge_Length,
                        Rects_List[v][u].Y + MovementDirections_List[v][u].Y * edge_Length, Rects_List[v][u].Width,
                        Rects_List[v][u].Height));
                        Helper2[v + MovementDirections_List[v][u].Y].Add(MovementDirections_List[v][u]);
                    }
                    isNotIntersecting = true;
                }
            }

            Rects_List = Helper1.ToArray().ToList();
            MovementDirections_List = Helper2.ToArray().ToList();
        }

        /// <summary>
        /// Renders the image to a bpm (or whathever file format you use in pathString).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveImageButton_Click(object sender, EventArgs e)
        {
            int size = 2 * DiamondIterations * edge_Length;
            int PositionRelativatorX = (DiamondIterations - 1) * edge_Length - Rects_List[0][0].X;
            int PositionRelativatorY = -Rects_List[0][0].Y;
            pathString = String.Format(@"C:\Users\Silvan\01 Arctic Cirle Renderings\{0:dd-MM-yyyy HH-mm}.bmp", DateTime.Now);

            Bitmap img = new Bitmap(size, size);

            for (int y = 0; y < Rects_List.Count; y++)
            {
                for (int x = 0; x < Rects_List[y].Count; x++)
                {
                    for (int j = 0; j < edge_Length; j++)
                    {
                        for (int i = 0; i < 2 * Math.Abs(MovementDirections_List[y][x].Y) * edge_Length; i++)
                        {

                            img.SetPixel(Rects_List[y][x].X + PositionRelativatorX + i,
                            Rects_List[y][x].Y + PositionRelativatorY + j,
                            RectColours_dict[MovementDirections_List[y][x]]);

                        }

                        for (int i = 0; i < 2 * Math.Abs(MovementDirections_List[y][x].X) * edge_Length; i++)
                        {
                            img.SetPixel(Rects_List[y][x].X + PositionRelativatorX + j,
                            Rects_List[y][x].Y + PositionRelativatorY + i,
                            RectColours_dict[MovementDirections_List[y][x]]);
                        }
                    }
                }
            }
            img.Save(pathString);
        }

        /// <summary>
        /// Influences noClear variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinueRendering_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            noClear = !noClear;
        }

        /// <summary>
        /// Copys measured intervals per increment from timeList to Clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetIntervals_button_Click(object sender, EventArgs e)
        {
            StringBuilder Output = new StringBuilder();
            Output.Append("Iteration\tTime used [ms]\n");
            for (int i = 0; i < timeList.Count; i++)
            {
                Output.Append(String.Format("{0}\t{1}\n",i + 1, timeList[i]));
            }
            Clipboard.SetText(Convert.ToString(Output));
        }

        /// <summary>
        /// Model adjusted to fit the data collected with timeList, more data needed for better results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeProjection_button_Click(object sender, EventArgs e)
        {
            DiamondIterations = Convert.ToInt32(EndSize_textBox.Text);
            int ProjectedTime = 0;
            for(int x = 1; x <= DiamondIterations; x++)
            {
                //-3E-11x6 + 2E-08x5 - 7E-06x4 + 0.0012x3 - 0.0622x2 + 1.671x - 10.387
                ProjectedTime += Convert.ToInt32(0.00070478245138286500 * Math.Pow(x, 2.78491739893229000000));
            }
            TimeSpan t = TimeSpan.FromMilliseconds(Convert.ToDouble(ProjectedTime));
            ProjectedTime_label.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
        }

        /// <summary>
        /// Influences DrawInform variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawInForm_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            DrawInForm = !DrawInForm;
        }
    }
}
