using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace MouseKeyboardActivityMonitor.MouseTracker
{
    class HeatMap
    {

        private Image heatMapImage;
        private Graphics g;

        public HeatMap(float[,] m)
        {

            heatMapImage = new Bitmap(MouseTracker.screenWidth, MouseTracker.screenHeight, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(heatMapImage);

            Thread t = new Thread(() => drawMap(m));
            t.Start();

        }

        private void drawMap(float[,] m)
        {

            float maxValue = 0;
            for(int j = 4; j < (MouseTracker.screenHeight / 3) + 4; j++) {
                for (int i = 4; i < (MouseTracker.screenWidth/ 3) + 4; i++)
                {
                    if (m[j, i] > maxValue)
                        maxValue = m[j, i];
                }
            }

            System.IO.StreamWriter file2 = new System.IO.StreamWriter(@"G:\Pictures\test.txt");

            for (int j = 4; j < (MouseTracker.screenHeight / 3) + 4; j++)
            {
                for (int i = 4; i < (MouseTracker.screenWidth / 3) + 4; i++)
                {
                    Color color = Color.Blue; 

                    if(m[j,i] <= 0.25 * maxValue)
                        color = Color.FromArgb(0, (int) (255 * m[j,i] / (0.25 * maxValue)), 255);
                    else if (m[j, i] > 0.25 * maxValue && m[j,i] <= 0.5 * maxValue)
                        color = Color.FromArgb(0, 255, 255 - (int)((m[j, i] - 0.25 * maxValue) * 255 / (0.25 * maxValue)));
                    else if (m[j, i] > 0.5 * maxValue && m[j, i] <= 0.75 * maxValue)
                        color = Color.FromArgb((int)((m[j, i] - 0.5 * maxValue) * 255 / (0.25 * maxValue)), 255, 0);
                    else if (m[j, i] > 0.75 * maxValue)
                        color = Color.FromArgb(255, 255 - (int)((m[j, i] - 0.75 * maxValue) * 255 / (0.25 * maxValue)), 0);

                    file2.WriteLine((i - 4).ToString() + " " + (j - 4).ToString() + " " + m[j, i].ToString() + " " + color.R.ToString() + " " + color.G.ToString() + " " + color.B.ToString());


                    g.FillRectangle(new SolidBrush(color), (i * 3) - 12, (j * 3) - 12, 3, 3);

                    
                }
            }

            heatMapImage.Save(@"G:\Pictures\test2.png", ImageFormat.Png);
            Console.WriteLine("Done!");
        }

    }
}