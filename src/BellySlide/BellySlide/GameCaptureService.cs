using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide
{
    public class GameCaptureService
    {
        public class GameCaptureService
        {
            public Image<Bgr, byte> CaptureScreen(Rectangle bounds)
            {
                Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                Image<Bgr, byte> screenCapture = bitmap.ToImage<Bgr, byte>();
                return screenCapture;
            }
        }

    }

}
