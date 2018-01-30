using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DWMWindowClone
{
    public partial class CloneWindow : Form
    {
        private Margins _glassMargins;
        private List<IntPtr> _windowList;
        private List<String> _windowNames;
        private IntPtr _thumbHandle;
        private IntPtr _targetHwnd;
        private bool _mmcssOn = false;

        public CloneWindow()
        {
            InitializeComponent();
        }

        private bool EnumWindows(IntPtr hwnd, IntPtr lParam)
        {

            if (Win32.IsWindow(hwnd) && Win32.IsWindowVisible(hwnd))
            {
                StringBuilder str = new StringBuilder(Win32.GetWindowTextLength(hwnd) + 1);
                Win32.GetWindowText(hwnd, str, str.Capacity);
                string title = str.ToString();
                if (title.Length > 0)
                {
                    _windowNames.Add(title);
                    _windowList.Add(hwnd);
                }
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _windowList = new List<IntPtr>();
            _windowNames = new List<string>();

            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Set up the glass effect using padding as the defining glass region
            if (Win32.DwmIsCompositionEnabled())
            {
                _glassMargins = new Margins();
                _glassMargins.Top = -1;
                _glassMargins.Left = -1;
                _glassMargins.Bottom = -1;
                _glassMargins.Right = -1;
                Win32.DwmExtendFrameIntoClientArea(this.Handle, ref _glassMargins);
            }

            Win32.EnumWindowsProc enumWindowsDelegate = new Win32.EnumWindowsProc(EnumWindows);
            Win32.EnumWindows(enumWindowsDelegate, new IntPtr());
            windowList.DataSource = _windowNames;
        }

        private void UpdateThumbnail()
        {
            if (_targetHwnd.ToInt32() == 0) //no target
                return;
            var props = new DwmThumbnailProperties();
            props.dwFlags = 0x11; //destination and client area only
            //props.rcDestination.Left = 0;// this.Bounds.Left;
            //props.rcDestination.Right = this.Bounds.Width;
            //props.rcDestination.Top = 0;// this.Bounds.Top;
            //props.rcDestination.Bottom = this.Bounds.Height;
            props.fSourceClientAreaOnly = true;
            //Rect targetWindow;
            //Rect targetClient;
            bool result = Win32.GetClientRect(this.Handle, out props.rcDestination);
            //props.rcDestination.Left = -1;// this.Bounds.Left;
            //props.rcDestination.Top = -1;// this.Bounds.Top;
            //props.rcDestination.Right++;
            //props.rcDestination.Bottom++;
            //bool result = Win32.GetWindowRect(, out props.rcDestination);
            //props.rcDestination.Right = this.Bounds.Width * props.rcDestination.Right / this.Bounds.Width;
            //props.rcDestination.Bottom = this.Bounds.Height;
            Win32.DwmUpdateThumbnailProperties(_thumbHandle, ref  props);
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            _targetHwnd = _windowList[windowList.SelectedIndex];
            Text = _windowNames[windowList.SelectedIndex] + " Clone";
            windowList.Hide();
            cloneButton.Hide();
            mmcss.Hide();
            BackColor = Color.Black;
            Win32.DwmRegisterThumbnail(this.Handle, _targetHwnd, out _thumbHandle);
            Rect targetWindow;
            bool result = Win32.GetClientRect(_targetHwnd, out targetWindow);
            int width = targetWindow.Right - targetWindow.Left;
            int height = targetWindow.Bottom - targetWindow.Top;
            if(width >0 && height > 0){
                Height = height;
                Width = width;
            }
            UpdateThumbnail();
        }

        protected override void OnResize(EventArgs e)
        {
            if (_targetHwnd.ToInt32() != 0)
            {
                Rect targetWindow;
                bool result = Win32.GetWindowRect(_targetHwnd, out targetWindow);
                float targetAspect = (float)(targetWindow.Right - targetWindow.Left) / (float)(targetWindow.Bottom - targetWindow.Top);
                float currentAspect = Width / (float)Height;
                Size = new Size((int)(targetAspect * Height), Height);
            }
            UpdateThumbnail();
            base.OnResize(e);
        }

        private void mmcss_Click(object sender, EventArgs e)
        {
            _mmcssOn = !_mmcssOn;
            if (_mmcssOn)
            {
                mmcss.Text = "Disable MMCSS";
            }
            else
            {
                mmcss.Text = "Enable MMCSS";
            }
            Win32.DwmEnableMMCSS(_mmcssOn);
        }

        protected override void WndProc(ref Message m)
        {
            IntPtr result;
            int handled = Win32.DwmDefWindowProc(this.Handle, m.Msg, m.WParam, m.LParam, out result);
            if(handled == 1)
            {
                m.Result = result;
                return;
            }
            base.WndProc(ref m);
        }
    }
}
