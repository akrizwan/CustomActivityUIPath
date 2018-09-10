using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomActivity
{
    [Designer(typeof(ScreenshotDesigner))]
    public class Screenshot : NativeActivity
    {
        [DefaultValue(null)]
        public InArgument<String> Type { get; set; }
        [DefaultValue(null)]
        public InArgument<String> ImageFormat { get; set; }

        [DefaultValue(null)]
        public InArgument<IntPtr> WindowHandle { get; set; }

        [DefaultValue(null)]
        public InArgument<String> ImagePath { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            
            if(Type.Get(context)=="Capture Window")
            {
                if(ImagePath.Get(context)!=null)
                {
                    CaptureWindowToFile(WindowHandle.Get(context), ImagePath.Get(context), ParseImageFormat(ImageFormat.Get(context)));
                }
                else
                {
                    System.Drawing.Image image = CaptureWindow(WindowHandle.Get(context));
                    image.Save("D:\\button.png", ParseImageFormat(ImageFormat.Get(context)));
                }
            }
            else if(Type.Get(context)=="Capture Screen")
            {
                if (ImagePath.Get(context) != null)
                {
                    CaptureScreenToFile(ImagePath.Get(context), ParseImageFormat(ImageFormat.Get(context)));
                }
                else
                {
                    System.Drawing.Image image = CaptureScreen();
                    image.Save("D:\\Screenshot.png", ParseImageFormat(ImageFormat.Get(context)));
                }
            }
            else if(Type.Get(context)== "Capture Active Window")
            {
                if (ImagePath.Get(context) != null)
                {
                    CaptureWindowToFile(User32.GetForegroundWindow(), ImagePath.Get(context), ParseImageFormat(ImageFormat.Get(context)));
                }
                else
                {
                    System.Drawing.Image image3 = CaptureWindow(User32.GetForegroundWindow());
                    image3.Save("D:\\ScreenshotActiveWindow.png", ParseImageFormat(ImageFormat.Get(context)));
                }
            }
        }
        public static ImageFormat ParseImageFormat(string str)
        {
            return (ImageFormat)typeof(ImageFormat)
                    .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                    .GetValue(null);
        }
        public System.Drawing.Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        /// <summary>
        /// Creates an Image object containing a screen shot of a specific window
        /// </summary>
        /// <param name="handle">The handle to the window. (In windows forms, this is obtained by the Handle property)</param>
        /// <returns></returns>
        public System.Drawing.Image CaptureWindow(IntPtr handle)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // clean up 
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);

            // get a .NET image object for it
            System.Drawing.Image img = System.Drawing.Image.FromHbitmap(hBitmap);
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);

            return img;
        }

        /// <summary>
        /// Captures a screen shot of a specific window, and saves it to a file
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            System.Drawing.Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }

        /// <summary>
        /// Captures a screen shot of the entire desktop, and saves it to a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            System.Drawing.Image img = CaptureScreen();
            img.Save(filename, format);
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        }
    }
}
