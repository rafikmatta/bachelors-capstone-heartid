using System;
using System.Windows;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;
using System.IO;
using System.Timers;



namespace graphing
{
    class Program
    {
        static Chart c; 
        static TimeSpan last_render_time;
        static Timer count;
        static Timer Pause;
        static bool status;

        [STAThread]
        static void Main(string[] args)
        {
            Window w = new Window();
            w.Show();
            w.Name = "graphing";
            c = new Chart(w);
            w.Content = c; 
            c.update();
            count = new Timer();
            count.Interval = 5000;
            count.Enabled = true;
            count.Elapsed += new ElapsedEventHandler(ChartData_Update);
            last_render_time = new TimeSpan(1);
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
            System.Windows.Application app = new System.Windows.Application();
            app.Run();
            

        }

        static void ChartData_Update(object source, ElapsedEventArgs e)
        {
            status = true;
            Console.WriteLine("Data Received");
            c.update();
            status = false;
        }
       


        static void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            Pause.Interval = 1000;
            if (status)
            {
                Pause.Start();
            }
 
            // ensure we only call render() once per frame
            if (last_render_time != ((RenderingEventArgs)e).RenderingTime)
            {
                c.render();
                last_render_time = ((RenderingEventArgs)e).RenderingTime;
            }
        }
    }



    class ChartCore : DrawingVisual
    {
        WriteableBitmap writeable_bitmap;

        int WIDTH = 1400;
        int HEIGHT = 1800;

        int COUNT = 1280;
        PointF[] values;

        const float pen_thickness = 5;
        float half_pen_thickness = pen_thickness / 2.0f;

        System.Drawing.Graphics bitmapGraphics;

        System.Drawing.Pen pen;
        System.Messaging.MessageQueue mq;


        public ChartCore(Window w)
        {
            int pixel_count = WIDTH * HEIGHT;

            System.Drawing.Color c = System.Drawing.Color.Red;
            pen = new System.Drawing.Pen(c, pen_thickness);

            // get DPI for this window
            System.Windows.Media.Matrix m = PresentationSource.FromVisual(w).CompositionTarget.TransformToDevice;
            //double dpi_x = m.M11 * 96.0;
            //double dpi_y = m.M22 * 96.0;

            writeable_bitmap = new WriteableBitmap(WIDTH, HEIGHT, 96, 96, PixelFormats.Pbgra32, null);

            System.Drawing.Bitmap b = new Bitmap(WIDTH, HEIGHT, WIDTH * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, writeable_bitmap.BackBuffer);
            bitmapGraphics = System.Drawing.Graphics.FromImage(b);
            bitmapGraphics.SmoothingMode = SmoothingMode.HighSpeed;
            bitmapGraphics.InterpolationMode = InterpolationMode.Default;
            bitmapGraphics.CompositingMode = CompositingMode.SourceCopy;
            bitmapGraphics.CompositingQuality = CompositingQuality.HighSpeed;

            DrawingContext dc = RenderOpen();
            dc.DrawImage(writeable_bitmap, new Rect(0, 0, WIDTH, HEIGHT));
            dc.Close();
        }

        int index = 0;
        public void update()
        {
            values = new PointF[COUNT];
            double value = 0.0;

            mq = new System.Messaging.MessageQueue(@".\Private$\MyQueue");


            string mes = null;
            int n = 0;

            for (n = 0; n < 1280; n++)
                {
                    mq.Receive();
                    mq.Receive();
                    System.Messaging.Message message = mq.Receive();
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    mes = message.Body.ToString();
                    value = System.Convert.ToDouble(mes);
                    value = Math.Abs(value - HEIGHT) - 1200;
                    values[n] = new PointF((float)n, (float)value);
                }
        }

        public void render()
        {
            writeable_bitmap.Lock();

            bitmapGraphics.DrawLine(pen, values[index+1], values[index]);
            int width = (int)(Math.Abs(values[index + 1].X - values[index].X) + pen_thickness + 4);
            int height = (int)(Math.Abs(values[index + 1].Y - values[index].Y) + pen_thickness + 4);

            int startx = (int)Math.Max((int)Math.Min(values[index + 1].X, values[index].X), 0);
            int starty = (int)Math.Max((int)Math.Min(values[index + 1].Y, values[index].Y), 0);

            bitmapGraphics.Flush(FlushIntention.Flush);
            writeable_bitmap.AddDirtyRect(new Int32Rect(startx, starty, width, height));

            index++;

            if (index + 2 >= COUNT)
            {
                index = 0;
                bitmapGraphics.Clear(System.Drawing.Color.White);
                writeable_bitmap.AddDirtyRect(new Int32Rect(0, 0, WIDTH, HEIGHT));
            }

            writeable_bitmap.Unlock();
        }
    }



    class Chart : UIElement
    {
        ContainerVisual container;
        ChartCore core;

        public Chart(Window w)
        {
            container = new ContainerVisual();

            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.Linear);
            RenderOptions.SetEdgeMode(this, EdgeMode.Aliased);

            core = new ChartCore(w);

            container.Children.Add(core);
            AddVisualChild(container);
        }

        public void render()
        {
            core.render();
        }

        public void update()
        {
            core.update();
        }

        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        protected override Visual GetVisualChild(int index)
        {
            return container;
        }
    }
}


