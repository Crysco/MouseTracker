using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using MouseKeyboardActivityMonitor.WinApi;
using System.Threading;

namespace MouseKeyboardActivityMonitor.MouseTracker
{
    public partial class MouseTracker : Form
    {
        private readonly MouseHookListener m_MouseHookManager;

        Bitmap image;
        Graphics g;
        Pen pen = new Pen(Color.Red, 1);
        Point startPoint = new Point(0, 0);
        Point endPoint = new Point(0, 0);

        private Double monitorSize;
        public static int screenWidth, screenHeight;
        public static int maxPass = 0;

        private static float[,] tiles;

        private Boolean drawing = false;

        HeatMap map;

        private Stopwatch sw = new Stopwatch();

        public MouseTracker()
        {
            InitializeComponent();

            

            m_MouseHookManager = new MouseHookListener(new GlobalHooker());
            m_MouseHookManager.Enabled = true;

            m_MouseHookManager.MouseMove += HookManager_MouseMove;

            cbMonRes.SelectedIndex = 0;


        }

        private void MouseTracker_Load(object sender, EventArgs e)
        {

        }


        //##################################################################
        #region Event handlers of particular events. They will be activated when an appropriate check box is checked.

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            drawing = true;

            if(drawing)
            {
                endPoint = e.Location;

                if (endPoint.X < 0)
                    endPoint.X = 0;
                if (endPoint.X > screenWidth - 1)
                    endPoint.X = screenWidth - 1;
                if (endPoint.Y < 0)
                    endPoint.Y = 0;
                if (endPoint.Y > screenHeight - 1)
                    endPoint.Y = screenHeight - 1;

                g.DrawLine(pen, startPoint, endPoint);

                
                updateMap((endPoint.Y / 3) + 4, (endPoint.X / 3) + 4);          
  

                startPoint = endPoint;
            }
        }

        private void updateMap(int y, int x) {
            tiles[y, x] += 20;

            tiles[y - 1, x] += 16;
            tiles[y + 1, x] += 16;
            tiles[y, x - 1] += 16;
            tiles[y, x + 1] += 16;
            tiles[y - 1, x - 1] += 16;
            tiles[y + 1, x + 1] += 16;
            tiles[y - 1, x + 1] += 16;
            tiles[y + 1, x - 1] += 16;

            tiles[y - 2, x] += 12;
            tiles[y + 2, x] += 12;
            tiles[y, x - 2] += 12;
            tiles[y, x + 2] += 12;
            tiles[y - 2, x - 1] += 12;
            tiles[y - 2, x + 1] += 12;
            tiles[y + 2, x + 1] += 12;
            tiles[y + 2, x - 1] += 12;
            tiles[y - 1, x - 2] += 12;
            tiles[y + 1, x - 2] += 12;
            tiles[y + 1, x + 2] += 12;
            tiles[y - 1, x + 2] += 12;

            tiles[y - 3, x] += 8;
            tiles[y + 3, x] += 8;
            tiles[y, x - 3] += 8;
            tiles[y, x + 3] += 8;
            tiles[y - 2, x - 2] += 8;
            tiles[y + 2, x - 2] += 8;
            tiles[y + 2, x + 2] += 8;
            tiles[y - 2, x + 2] += 8;
            tiles[y - 3, x - 1] += 8;
            tiles[y - 3, x + 1] += 8;
            tiles[y + 3, x + 1] += 8;
            tiles[y + 3, x - 1] += 8;
            tiles[y - 1, x - 3] += 8;
            tiles[y + 1, x - 3] += 8;
            tiles[y + 1, x + 3] += 8;
            tiles[y - 1, x + 3] += 8;


            tiles[y - 4, x] += 4;
            tiles[y + 4, x] += 4;
            tiles[y, x - 4] += 4;
            tiles[y, x + 4] += 4;
            tiles[y - 2, x - 3] += 4;
            tiles[y - 2, x + 3] += 4;
            tiles[y - 3, x - 2] += 4;
            tiles[y - 3, x + 2] += 4;
            tiles[y + 2, x - 3] += 4;
            tiles[y + 2, x + 3] += 4;
            tiles[y + 3, x - 2] += 4;
            tiles[y + 3, x + 2] += 4;
            tiles[y - 4, x - 1] += 4;
            tiles[y - 4, x + 1] += 4;
            tiles[y + 4, x + 1] += 4;
            tiles[y + 4, x - 1] += 4;
            tiles[y - 1, x - 4] += 4;
            tiles[y + 1, x - 4] += 4;
            tiles[y + 1, x + 4] += 4;
            tiles[y - 1, x + 4] += 4;
        }

        private void HookManager_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void HookManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        #endregion

        private void HookManager_Supress(object sender, MouseEventExtArgs e)
        {
            
        }

        private void bStart_Click(object sender, EventArgs e)
        {

            if (tbMonSize.Text.Equals(""))
                lErrMonSize.Text = "Must enter a monitor size.";
            else
            { 
                monitorSize = Double.Parse(tbMonSize.Text);

                string[] monitorResolution = cbMonRes.SelectedItem.ToString().Split('x');
                screenWidth = Int32.Parse(monitorResolution[0]);
                screenHeight = Int32.Parse(monitorResolution[1]);

                image = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppArgb);

                g = Graphics.FromImage(image);

                tiles = new float[(screenHeight / 3) + 8, (screenWidth / 3) + 8];

                drawing = true;

                timer.Enabled = true;
                
                Thread t = new Thread(() => sw.Start());
                t.Start();

                

  
            }
        }

        

        private void bStop_Click(object sender, EventArgs e)
        {
            if (drawing)
            {
                sw.Stop();
                map = new HeatMap(tiles);

                drawing = false;
                image.Save(@"G:\Pictures\test.png", ImageFormat.Png);
            }
           
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            lTime.Text = "0:00:00:00";
            map = null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int hrs = sw.Elapsed.Hours;
            int mins = sw.Elapsed.Minutes;
            int secs = sw.Elapsed.Seconds;
            int mils = sw.Elapsed.Milliseconds / 10;

            lTime.Suspend();

            lTime.Text = hrs + ":";

            if (mins < 10)
                lTime.Text += "0" + mins + ":";
            else
                lTime.Text += mins + ":";

            if (secs < 10)
                lTime.Text += "0" + secs + ":";
            else
                lTime.Text += secs + ":";

            if (mils < 10)
                lTime.Text += "0" + mils;
            else
                lTime.Text += mils;

            lTime.Resume();
            
        }
    }
}
