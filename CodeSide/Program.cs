using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static CodeSide.Native.Win32;

namespace CodeSide
{
    static class Program
    {
        /// <summary>
        /// The identifer using for mutex
        /// </summary>
        private readonly static string MUTEX_NAME = "CodeSideInstance_" + Guid();

        /// <summary>
        /// Application instance mutex
        /// </summary>
        private static Mutex mutex = new Mutex(true, MUTEX_NAME);

        /// <summary>
        /// Get current running process guid from assemblyinfo file
        /// </summary>
        /// <returns></returns>
        private static string Guid()
        {
            // http://stackoverflow.com/questions/502303/how-do-i-programmatically-get-the-guid-of-an-application-in-net2-0
            var assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            return attribute.Value;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                if(args.Length > 0)
                {
                    var current = Process.GetCurrentProcess();

                    int i = 0;
                    Process target = null;
                    while ((target = Process.GetProcessesByName("CodeSide")
                        .FirstOrDefault(p => p.Id != current.Id && p.MainWindowHandle != IntPtr.Zero)) == null && i < 5)
                    {
                        Thread.Sleep(100);
                        i++;
                    }

                    if (IsZoomed(target.MainWindowHandle))
                        ShowWindow(target.MainWindowHandle, SW_MAXIMIZE);
                    else if (IsIconic(target.MainWindowHandle))
                        ShowWindow(target.MainWindowHandle, SW_RESTORE);

                    SetForegroundWindow(target.MainWindowHandle);

                    Native.MessagePasser.SendString(target.MainWindowHandle, string.Join(",", args));
                }

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Globals.MainWindow = new Views.MainWindow(args);
            Application.Run(Globals.MainWindow);
            
            mutex.ReleaseMutex();
        }
    }
}
