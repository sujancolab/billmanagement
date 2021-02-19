using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

using System.IO;
using System.Threading;

namespace SBGhadgev1
{
    

    public partial class PointCanvas : UserControl
    {
       

    
       
        #region Static Variables
        private static readonly Color[] CLASSES = new Color[] {  
            Color.FromArgb(255, 0, 0),  
            Color.FromArgb(0, 0, 255),  
        };
        private static readonly Color[] CLASS_FILL = new Color[] {  
            Color.FromArgb(127, 0, 0),  
            Color.FromArgb(0, 0, 127),  
        };
        private const int CIRCLE_DIAMETER = 16;
        private static readonly Random RAND = new Random();
        #endregion
       // private Bitmap[] _frames;
        private const int GRAY_LEVEL = 210;
        private const int BLACK_LEVEL = 120;
        private static readonly string MARQUEE = " SBG Engine WORKING...";
        private bool _workingAnimation;
        private int[] _marqueeValues;
        private int[] _counterValues;
        private int _marqueeIndex;
        private int _counterIndex;
        private int _counter;
        private Bitmap _canvas;
        private List<double[]> _X;
        private List<int> _Y;
        private double _C, _Gamma;
        private int _numberOfRounds;
       // private PointMode _pointMode;
       // private ClassifierMode _classifierMode;
        //private Dictionary<ClassifierMode, Bitmap> _savedCanvases;

        public PointCanvas()
        {
            InitializeComponent();

            _X = new List<double[]>();
            _Y = new List<int>();
            _C = 2;
            _Gamma = 0.5;
            _numberOfRounds = 50;
           // _savedCanvases = new Dictionary<ClassifierMode, Bitmap>();
            _marqueeValues = new int[MARQUEE.Length];
            _counterValues = new int[8];
            resetAnimation();
            PerformRecognition();
        }

        public double C
        {
            get
            {
                return _C;
            }
            set
            {
                _C = value;
            }
        }

        public double Gamma
        {
            get
            {
                return _Gamma;
            }
            set
            {
                _Gamma = value;
            }
        }

        public int NumberOfRounds
        {
            get
            {
                return _numberOfRounds;
            }
            set
            {
                _numberOfRounds = value;
            }
        }

       
        //public void SavePointSet(string filename)
        //{
        //    StreamWriter output = new StreamWriter(filename);
        //    int count = _X.Count;
        //    output.WriteLine(count);
        //    for (int i = 0; i < count; i++)
        //        output.WriteLine("{0} {1} {2}", _X[i][0], _X[i][1], _Y[i]);
        //    output.Close();
        //}

        //public void LoadPointSet(string filename)
        //{
        //    StreamReader input = new StreamReader(filename);
        //    int count = int.Parse(input.ReadLine());
        //    List<double[]> X = new List<double[]>();
        //    List<int> Y = new List<int>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        string[] parts = input.ReadLine().Split();
               
        //        //int k = 0;
        //        for (int j = 0; j < parts.Length; j+=2)
        //        {
        //            double[] point = new double[2];
        //            point[0] = double.Parse(parts[j]);
        //            point[1] = double.Parse(parts[j+1]);
        //            int y = int.Parse(parts[j+1]);
        //            X.Add(point);
        //            Y.Add(y);
        //        }
               
                
        //    }
        //    input.Close();
        //    _Y = Y;
        //    _X = X;
        //    lock (this)
        //    {
        //        _canvas = null;
        //    }
        
        //    _frames = null;
        //    Refresh();
        //}

        public void Reset()
        {
            _X.Clear();
            _Y.Clear();
            lock (this)
            {
                _canvas = null;
            }
        
          //  _frames = null;
            Refresh();
        }

        public void PerformRecognition()
        {
            _workingAnimation = true;
            animationTimer.Start();
            //classificationBW.RunWorkerAsync();
        }

        private PointF drawMarquee(Graphics g)
        {
            if (_marqueeIndex == _marqueeValues.Length)
            {
                _marqueeIndex = 0;
                for (int i = 0; i < _marqueeValues.Length; i++)
                    _marqueeValues[i] = GRAY_LEVEL;
            }
            if (_marqueeValues[_marqueeIndex] == BLACK_LEVEL)
                _marqueeIndex++;
            else _marqueeValues[_marqueeIndex] -= 5;
            float width = 0;
            float height = 0;
            for (int i = 0; i < MARQUEE.Length - 3; i++)
            {
                string s = "" + MARQUEE[i];
                SizeF test = g.MeasureString(s, Font);
                width += test.Width;
                height = Math.Max(height, test.Height);
            }
            float x = (Width - width) / 2;
            float y = (Height - height) / 2+50;
            for (int i = 0; i < MARQUEE.Length; i++)
            {
                Color c = Color.FromArgb(_marqueeValues[i], _marqueeValues[i], _marqueeValues[i]);
                if (_marqueeValues[i] == BLACK_LEVEL)
                { c = Color.Blue; }
                else { c = Color.SkyBlue; }
                SolidBrush br = new SolidBrush(c);
                string s = "" + MARQUEE[i];
                g.DrawString(s, Font, br, x, y);
                SizeF box = g.MeasureString(s, Font);
                x += box.Width;
                br.Dispose();
            }
            return new PointF((Width - width) / 2, Height / 2);
        }

        private void drawCounter(Graphics g, PointF p)
        {
            for (int i = 0; i < _counterValues.Length; i++)
                if (_counterValues[i] < GRAY_LEVEL - 30)
                    _counterValues[i] += 10;
            if (_counter == 0)
                _counterValues[_counterIndex++] = BLACK_LEVEL;
            _counter++;
            if (_counter == 3)
                _counter = 0;
            if (_counterIndex == _counterValues.Length)
                _counterIndex = 0;

            float angle = 0;
            float da = (float)(Math.PI * 2 / _counterValues.Length);
            float originX = p.X+100;
            float originY = p.Y-20;
            float barLength = 30;
            float barWidth = 7;
            for (int i = 0; i < _counterValues.Length; i++)
            {
                float x = 35 * (float)Math.Cos(angle);
                float y = 35 * (float)Math.Sin(angle);
                g.TranslateTransform(originX + x, originY + y);
                g.RotateTransform((float)(angle * 180 / Math.PI));
                Color c = Color.FromArgb(_counterValues[i], _counterValues[i], _counterValues[i]);
                if (_counterValues[i] == BLACK_LEVEL)
                { c = Color.Blue; }
                else { c = Color.DeepSkyBlue; }
                SolidBrush br = new SolidBrush(c);
                g.FillRectangle(br, (-barLength / 2)-10, (-barWidth / 2)-10, barLength, barWidth);
                g.ResetTransform();
                angle += da;
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 0, 0, Width, Height);

            if (_canvas != null)
            {
                Bitmap image;
                lock (this)
                {
                    image = new Bitmap(_canvas);
                }

                g.DrawImage(image, (Width - image.Width) / 2, (Height - image.Height) / 2, image.Width, image.Height);
            }
            Dictionary<int, List<Point>> points = new Dictionary<int, List<Point>>();
            for (int i = 0; i < _X.Count; i++)
            {
                double[] x = _X[i];

                int y = _Y[i];
                int tlx = (int)x[0] + Width / 2 - CIRCLE_DIAMETER / 2;
                int tly = (int)x[1] + Height / 2 - CIRCLE_DIAMETER / 2;
                if (!points.ContainsKey(y))
                    points[y] = new List<Point>();
                points[y].Add(new Point(tlx, tly));
            }
            foreach (int i in points.Keys)
            {
                Image ball = new Bitmap(16, 16);
                Graphics gr = Graphics.FromImage(ball);
                gr.FillEllipse(Brushes.Red, 2, 2, 10, 10);
                    //imageList1.Images[i];
                foreach (Point p in points[i])
                    g.DrawImageUnscaled(ball, p.X, p.Y);
            }
            if (_workingAnimation)
            {
                Color grayedOut = Color.FromArgb(15, 0, 0, 0);
                SolidBrush br = new SolidBrush(grayedOut);
                g.FillRectangle(br, 0, 0, Width, Height);
                br.Dispose();
                PointF p = drawMarquee(g);
                drawCounter(g, p);
            }
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    int target = e.Button == MouseButtons.Left ? 0 : 1;
        //    switch (_pointMode)
        //    {
        //        case PointMode.Single:
        //            AddPoint(e.X, e.Y, target);
        //            break;

        //        case PointMode.Sparse:
        //            for (int i = 0; i < 10; i++)
        //            {
        //                float x = (float)SampleFromGaussian(e.X, 20);
        //                float y = (float)SampleFromGaussian(e.Y, 20);
        //                AddPoint(x, y, target);
        //            }
        //            break;

        //        case PointMode.Dense:
        //            for (int i = 0; i < 20; i++)
        //            {
        //                float x = (float)SampleFromGaussian(e.X, 10);
        //                float y = (float)SampleFromGaussian(e.Y, 10);
        //                AddPoint(x, y, target);
        //            }
        //            break;
        //    }
        //    Refresh();
        //}

        //private void AddPoint(float x, float y, int target)
        //{
        //    _X.Add(new double[] { x - Width / 2, y - Height / 2 });
        //    _Y.Add(target);
        //    lock (this)
        //    {
        //        _canvas = null;
        //    }
        //    _savedCanvases.Clear();
        //    _frames = null;
        //}

        //public static int ClassCount
        //{
        //    get
        //    {
        //        return CLASSES.Length;
        //    }
        //}

        //private Classifier<double> getClassifier()
        //{
        //    switch (_classifierMode)
        //    {
        //        case ClassifierMode.SVM:
        //            return new SVM(_C, _Gamma);

        //        case ClassifierMode.Adaboost:
        //            return new ClassificationDemo.Classification.NET.Classifiers.AdaBoost<DecisionStump>(_numberOfRounds);

        //        case ClassifierMode.NearestNeighbour:
        //            return new NearestNeighbour();

        //        case ClassifierMode.NearestNeighbourFast:
        //            return new NearestNeighbourFast();

        //        case ClassifierMode.DecisionStump:
        //            return new DecisionStump();

        //        default:
        //            return null;
        //    }
        //}

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Train the classifier 
            //int[] Y = _Y.ToArray();
            //for (int i = 0; i < Y.Length; i++)
            //    Y[i] = Y[i] == 0 ? 1 : -1;
            //LabeledDataSet<double> training = new LabeledDataSet<double>(_X.ToArray(), Y);
            //Classifier<double> classifier = getClassifier();
            //classifier.Train(training);

            //// Test the classifier 
            //Bitmap image = createCanvas(classifier);
            //lock (this)
            //{
            //    _canvas = new Bitmap(image);
            //}
            //_savedCanvases[_classifierMode] = image;
        }

        private static double SampleFromGaussian(double mean, double sigma)
        {
            double x1, x2, w, y1, y2;

            do
            {
                x1 = 2.0 * RAND.NextDouble() - 1.0;
                x2 = 2.0 * RAND.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
            } while (w >= 1.0);

            w = Math.Sqrt((-2.0 * Math.Log(w)) / w);
            y1 = x1 * w;
            y2 = x2 * w;

            return y1 * sigma + mean;
        }

        protected override void OnResize(EventArgs e)
        {
            Refresh();
        }

        private void resetAnimation()
        {
            _marqueeIndex = 0;
            _counterIndex = 0;
            _counter = 0;
            for (int i = 0; i < _marqueeValues.Length; i++)
                _marqueeValues[i] = GRAY_LEVEL;
            for (int i = 0; i < _counterValues.Length; i++)
                _counterValues[i] = GRAY_LEVEL;
        }
       
        //private Bitmap createCanvas()
        //{
        //    int rows = ClientSize.Height;
        //    int columns = ClientSize.Width;
        //    Bitmap image = new Bitmap(columns, rows);
        //    int centerR = rows / 2;
        //    int centerC = columns / 2;
        //    BitmapData buf = image.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
         
        //    {
        //        byte* ptr = (byte*)buf.Scan0;
        //        int stride = buf.Stride;

        //        for (int r = 0; r < rows; r++)
        //        {
        //            byte* scan = ptr;
        //            for (int c = 0; c < columns; c++)
        //            {
        //                int x = c - centerC;
        //                int y = r - centerR;
        //                int assignment = classifier.Classify(new double[] { x, y });
        //                int index = assignment == 1 ? 0 : 1;
        //                *scan++ = CLASS_FILL[index].B;
        //                *scan++ = CLASS_FILL[index].G;
        //                *scan++ = CLASS_FILL[index].R;
        //            }
        //            ptr += stride;
        //        }
        //    }
        //    image.UnlockBits(buf);
        //    return image;
        //}

   

        //private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    resetAnimation();
        //    _workingAnimation = false;
        //    animationTimer.Stop();
        //    Refresh();
          
        //}

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void PointCanvas_Load(object sender, EventArgs e)
        {
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // PointCanvas
        //    // 
        //    this.Name = "PointCanvas";
        //    this.Load += new System.EventHandler(this.PointCanvas_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void PointCanvas_Load_1(object sender, EventArgs e)
        {

        }

        //private void adaboostBW_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    _frames = new Bitmap[_numberOfRounds];
        //    int[] Y = _Y.ToArray();
        //    for (int i = 0; i < Y.Length; i++)
        //        Y[i] = Y[i] == 0 ? 1 : -1;
        //    LabeledDataSet<double> training = new LabeledDataSet<double>(_X.ToArray(), Y);
        //    ClassificationDemo.Classification.NET.Classifiers.AdaBoost<DecisionStump> booster = new ClassificationDemo.Classification.NET.Classifiers.AdaBoost<DecisionStump>(_numberOfRounds);
        //    for (int j = 0; j < _numberOfRounds; j++)
        //    {
        //        booster.NumberOfRounds = j;
        //        booster.Train(training);
        //        Bitmap canvas = createCanvas(booster);
        //        Graphics g = Graphics.FromImage(canvas);
        //        Dictionary<int, List<Point>> points = new Dictionary<int, List<Point>>();
        //        for (int i = 0; i < _X.Count; i++)
        //        {
        //            double[] x = _X[i];
        //            int y = _Y[i];
        //            int tlx = (int)x[0] + Width / 2 - CIRCLE_DIAMETER / 2;
        //            int tly = (int)x[1] + Height / 2 - CIRCLE_DIAMETER / 2;
        //            if (!points.ContainsKey(y))
        //                points[y] = new List<Point>();
        //            points[y].Add(new Point(tlx, tly));
        //        }
        //        foreach (int i in points.Keys)
        //        {
        //            Image ball = imageList1.Images[i];
        //            foreach (Point p in points[i])
        //                g.DrawImageUnscaled(ball, p.X, p.Y);
        //        }
        //        _frames[j] = canvas;
        //    }
        //    if (_frames[_numberOfRounds - 1] != null)
        //        _savedCanvases[ClassifierMode.Adaboost] = _frames[_numberOfRounds - 1];
        //}

        //public void ProduceAdaboostAnimation()
        //{
           
        //        _workingAnimation = true;
        //        animationTimer.Start();
        //        adaboostBW.RunWorkerAsync();
          
        //}

        //private void adaboostBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    animationTimer.Stop();
        //    _workingAnimation = false;
        //    resetAnimation();
        //    RaiseAdaboostShowReady(_frames);
        //    Refresh();
        //}
    }
}