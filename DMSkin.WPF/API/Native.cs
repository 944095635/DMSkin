using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DMSkin
{
    public enum HitTest : int
    {
        /// <summary>  
        /// On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function produces a system beep to indicate an error).  
        /// </summary>  
        HTERROR = -2,

        /// <summary>  
        /// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).  
        /// </summary>  
        HTTRANSPARENT = -1,

        /// <summary>  
        /// On the screen background or on a dividing line between windows.  
        /// </summary>  
        HTNOWHERE = 0,

        /// <summary>  
        /// In a client area.  
        /// </summary>  
        HTCLIENT = 1,

        /// <summary>  
        /// In a title bar.  
        /// </summary>  
        HTCAPTION = 2,

        /// <summary>  
        /// In a window menu or in a Close button in a child window.  
        /// </summary>  
        HTSYSMENU = 3,

        /// <summary>  
        /// In a size box (same as HTSIZE).  
        /// </summary>  
        HTGROWBOX = 4,

        /// <summary>  
        /// In a size box (same as HTGROWBOX).  
        /// </summary>  
        HTSIZE = 4,

        /// <summary>  
        /// In a menu.  
        /// </summary>  
        HTMENU = 5,

        /// <summary>  
        /// In a horizontal scroll bar.  
        /// </summary>  
        HTHSCROLL = 6,

        /// <summary>  
        /// In the vertical scroll bar.  
        /// </summary>  
        HTVSCROLL = 7,

        /// <summary>  
        /// In a Minimize button.  
        /// </summary>  
        HTMINBUTTON = 8,

        /// <summary>  
        /// In a Minimize button.  
        /// </summary>  
        HTREDUCE = 8,

        /// <summary>  
        /// In a Maximize button.  
        /// </summary>  
        HTMAXBUTTON = 9,

        /// <summary>  
        /// In a Maximize button.  
        /// </summary>  
        HTZOOM = 9,

        /// <summary>  
        /// In the left border of a resizable window (the user can click the mouse to resize the window horizontally).  
        /// </summary>  
        HTLEFT = 10,

        /// <summary>  
        /// In the right border of a resizable window (the user can click the mouse to resize the window horizontally).  
        /// </summary>  
        HTRIGHT = 11,

        /// <summary>  
        /// In the upper-horizontal border of a window.  
        /// </summary>  
        HTTOP = 12,

        /// <summary>  
        /// In the upper-left corner of a window border.  
        /// </summary>  
        HTTOPLEFT = 13,

        /// <summary>  
        /// In the upper-right corner of a window border.  
        /// </summary>  
        HTTOPRIGHT = 14,

        /// <summary>  
        /// In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).  
        /// </summary>  
        HTBOTTOM = 15,

        /// <summary>  
        /// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).  
        /// </summary>  
        HTBOTTOMLEFT = 16,

        /// <summary>  
        /// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).  
        /// </summary>  
        HTBOTTOMRIGHT = 17,

        /// <summary>  
        /// In the border of a window that does not have a sizing border.  
        /// </summary>  
        HTBORDER = 18,

        /// <summary>  
        /// In a Close button.  
        /// </summary>  
        HTCLOSE = 20,

        /// <summary>  
        /// In a Help button.  
        /// </summary>  
        HTHELP = 21,
    };

    public enum GetWindow_Cmd : uint
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6
    }

    public enum HitTestValues
    {
        HTERROR = -2,
        HTTRANSPARENT = -1,
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21
    }

    public enum WindowMessages
    {
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,

        WM_QUIT = 0x0012,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_SHOWWINDOW = 0x0018,

        WM_ACTIVATEAPP = 0x001C,

        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_GETMINMAXINFO = 0x24,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,

        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,

        // non client area
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x84,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,

        WM_GETDLGCODE = 0x0087,

        WM_SYNCPAINT = 0x0088,

        // non client mouse
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
       
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,

        //系统边框
        WM_NCUAHDRAWCAPTION = 0xAE,
        WM_NCUAHDRAWFRAME = 0xAF,

        // keyboard
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,

        WM_SYSCOMMAND = 0x0112,

        // menu
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,

        WM_CHANGEUISTATE = 0x0127,
        WM_UPDATEUISTATE = 0x0128,
        WM_QUERYUISTATE = 0x0129,

        // mouse
        WM_MOUSEFIRST = 0x0200,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_MOUSEWHEEL = 0x020A,
        WM_MOUSELAST = 0x020D,

        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,

        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,

        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,

        WM_MOUSELEAVE = 0x02A3,
        WM_MOUSEHOVER = 0x02A1,
        WM_NCMOUSEHOVER = 0x02A0,
        WM_NCMOUSELEAVE = 0x02A2,

        WM_MDIACTIVATE = 0x0222,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,

        WM_SYSMENU = 0x313,

        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
    }

    public enum SystemCommands
    {
        SC_SIZE = 0xF000,
        SC_MOVE = 0xF010,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_MAXIMIZE2 = 0xF032,	// fired from double-click on caption
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_CLOSE = 0xF060,
        SC_VSCROLL = 0xF070,
        SC_HSCROLL = 0xF080,
        SC_MOUSEMENU = 0xF090,
        SC_KEYMENU = 0xF100,
        SC_ARRANGE = 0xF110,
        SC_RESTORE = 0xF120,
        SC_RESTORE2 = 0xF122,	// fired from double-click on caption
        SC_TASKLIST = 0xF130,
        SC_SCREENSAVE = 0xF140,
        SC_HOTKEY = 0xF150,

        SC_DEFAULT = 0xF160,
        SC_MONITORPOWER = 0xF170,
        SC_CONTEXTHELP = 0xF180,
        SC_SEPARATOR = 0xF00F
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;

        public RECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public static RECT FromXYWH(int x, int y, int width, int height)
        {
            return new RECT(x,
                            y,
                            x + width,
                            y + height);
        }
    }

    public struct POINTAPI
    {
        internal int x;
        internal int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hWndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public uint flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTS
    {
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize; // The maximized size of the window  
        public POINT ptMaxPosition; // The position of the maximized window  
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class MONITORINFOEX
    {
        public int cbSize;
        public RECT rcMonitor; // The display monitor rectangle  
        public RECT rcWork; // The working area rectangle  
        public int dwFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
        public char[] szDevice;
    }

    [Flags]
    public enum WindowStyle
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = -2147483648, //0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_CAPTION = 0x00C00000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,
        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,
        WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
        WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
        WS_CHILDWINDOW = (WS_CHILD)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeMessage
    {
        public IntPtr handle;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public System.Windows.Point p;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct APPBARDATA
    {
        public int cbSize; // initialize this field using: Marshal.SizeOf(typeof(APPBARDATA));
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public uint uEdge;
        public RECT rc;
        public int lParam;
    }

    public static class NativeMethods
    {
        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);


        private static int IntPtrToInt32(IntPtr intPtr)
        {
            return unchecked((int)intPtr.ToInt64());
        }

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            // Win32 SetWindowLong doesn't clear error on success  
            SetLastError(0);

            if (IntPtr.Size == 4)
            {
                // use SetWindowLong  
                Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            }
            else
            {
                // use SetWindowLongPtr  
                result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }


        [DllImport("gdi32.dll")]
        internal static extern IntPtr CreatePolygonRgn(ref POINTAPI lpPoint, int nCount, int nPolyFillMode);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, int dwFlags);

        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        internal static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll")]
        public static extern int PostMessage(IntPtr hwnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        public static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y,
           IntPtr hwnd, IntPtr lptpm);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wparam, POINTS pos);

        [DllImport("user32.dll")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int PostMessage(IntPtr hwnd, int msg, int wparam, POINTS pos);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("user32.dll")]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

        [DllImport("gdi32.dll")]
        public static extern int GetRgnBox(IntPtr hrgn, out RECT lprc);

        [DllImport("user32.dll")]
        public static extern Int32 GetWindowLong(IntPtr hWnd, Int32 Offset);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int smIndex);

        [DllImport("user32.dll", SetLastError = true,CharSet =CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("shell32.dll")]
        internal static extern int SHAppBarMessage(uint dwMessage, [In] ref APPBARDATA pData);

        [DllImport("user32.dll")]
        internal static extern bool GetMonitorInfo(HandleRef hmonitor, [In, Out] MONITORINFOEX monitorInfo);

    }
    public static class NativeConstants
    {
        public const int SM_CXSIZEFRAME = 32;
        public const int SM_CYSIZEFRAME = 33;
        public const int SM_CXPADDEDBORDER = 92;
        
        public const int GWL_ID = (-12);
        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);

        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCRBUTTONUP = 0x00A5;

        public const uint TPM_LEFTBUTTON = 0x0000;
        public const uint TPM_RIGHTBUTTON = 0x0002;
        public const uint TPM_RETURNCMD = 0x0100;

        public static readonly IntPtr TRUE = new IntPtr(1);
        public static readonly IntPtr FALSE = new IntPtr(0);

        public const uint ABM_GETSTATE = 0x4;
        public const int ABS_AUTOHIDE = 0x1;

        // Retrieves a handle to the display monitor that is nearest to the window  
        //检索到靠近窗口的显示监视器的处理
        public const int MONITOR_DEFAULTTONEAREST = 2;

        //不在ALT+TAB中
        public const int WS_EX_TOOLWINDOW = 0x00000080;
    }
}
