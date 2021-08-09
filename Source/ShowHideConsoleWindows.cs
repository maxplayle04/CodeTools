using System;
using System.Runtime.InteropServices;

namespace MakeMeRest.Engine
{
    /// <summary>
    /// A basic class with code which can control the system, or the application.
    /// </summary>
    internal class SystemEngine
    {
        private static SystemEngine e;
        public static SystemEngine Instance => e ??= new SystemEngine();
        
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        /// <summary>
        /// Show the console window for this application.
        /// </summary>
        void ShowConsoleWindow() => ShowWindow(GetConsoleWindow(), SW_SHOW);
        
        /// <summary>
        /// Hide the console window for this application.
        /// </summary>
        void HideConsoleWindow() => ShowWindow(GetConsoleWindow(), SW_HIDE);


        private bool _bIsConsoleWindowShowing = false;
        public bool bIsConsoleWindowShowing
        {
            set
            {
                if (value)
                {
                    _bIsConsoleWindowShowing = true;
                    ShowConsoleWindow();
                }
                else
                {
                    _bIsConsoleWindowShowing = false;
                    HideConsoleWindow();
                }
            }
            get => _bIsConsoleWindowShowing;
        }
    }
}
