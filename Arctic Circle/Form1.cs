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
        /// You can change the save location for the renderings in the "SaveImageButton_Click" class
        /// </summary>
        string pathString; 
        int edge_Length; //Side of each square
        Point[] Directions = new Point[5]; //pointed Lengths of Lines
        List<Point> DiamondPoints = new List<Point>(); //Coordinates of significant verteces
        int DiamondIterations; //Final Size of Diamond
        int Pause_Interval; //Pause between each increment
        int startSize;
        long PossibilitiesCounter = 0; // lb(possibilities)
        List<List<Rectangle>> Rects_List = new List<List<Rectangle>>(); //List containing all Rectangles
        List<List<Point>> MovementDirections_List = new List<List<Point>>(); //List of pointed unit vectors
        Random r = new Random();
        Pen p = new Pen(Brushes.White);
        Font f = new Font("Times New Roman", 12.0f);
        bool noClear = false;
        bool firstIteration = true;
        bool DrawInForm = true;
        List<long> timeList = new List<long>();
        Graphics g;

        Dictionary<Point, string> RectSymbols_dict = new Dictionary<Point, string>()
        {
            { new Point(1, 0), "→" },
            { new Point(-1, 0), "←" },
            { new Point(0, 1), "↓" },
            { new Point(0, -1), "↑" }
        };

        Dictionary<Point, Brush> RectBrushes_dict = new Dictionary<Point, Brush>()
        {
            { new Point(1, 0), Brushes.LawnGreen },
            { new Point(-1, 0), Brushes.Blue },
            { new Point(0, 1), Brushes.Yellow },
            { new Point(0, -1),Brushes.Red }
        };

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

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (noClear && !firstIteration)
            {
                startSize = DiamondIterations + 1;
                DiamondIterations = Convert.ToInt32(textBox2.Text);
            }
            else
            {
                firstIteration = false;
                startSize = Convert.ToInt32(textBox1.Text);
                DiamondIterations = Convert.ToInt32(textBox2.Text);
                edge_Length = Convert.ToInt32(textBox3.Text);
                Pause_Interval = Convert.ToInt32(textBox4.Text);

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
                label7.Text = "2^" + Convert.ToString(PossibilitiesCounter);
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

            /*for (int u = 0; u < Input.Count; u++)
            {
                for (int v = 1; v < Input.Count; v++)
                {
                    if (Input[v].Y < Input[v - 1].Y)
                    {
                        Input.Insert(v - 1, Input[v]);
                        Input.RemoveAt(v + 1);
                    }
                }
            }*/
        }

        void BubbleSort(List<Point> Input)
        {
            for (int v = 1; v < Input.Count; v++)
            {
                if (Input[v].X < Input[v - 1].X && Input[v].Y == Input[v - 1].Y)
                {
                    Input.Insert(v - 1, Input[v]);
                    Input.RemoveAt(v + 1);
                }
            }
        }

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
        /// Draws all Rectangles
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
        /// Gets Called for each 2x2 field detected
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            noClear = !noClear;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder Output = new StringBuilder();
            Output.Append("Iteration\tTime used [ms]\n");
            for (int i = 0; i < timeList.Count; i++)
            {
                Output.Append(String.Format("{0}\t{1}\n",i + 1, timeList[i]));
            }
            Clipboard.SetText(Convert.ToString(Output));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DiamondIterations = Convert.ToInt32(textBox2.Text);
            int ProjectedTime = 0;
            for(int x = 1; x <= DiamondIterations; x++)
            {
                //-3E-11x6 + 2E-08x5 - 7E-06x4 + 0.0012x3 - 0.0622x2 + 1.671x - 10.387
                ProjectedTime += Convert.ToInt32(0.00070478245138286500 * Math.Pow(x, 2.78491739893229000000));
            }
            TimeSpan t = TimeSpan.FromMilliseconds(Convert.ToDouble(ProjectedTime));
            label8.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DrawInForm = !DrawInForm;
        }
    }
}
