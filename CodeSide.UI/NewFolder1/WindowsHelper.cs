﻿using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using static NativeMethods;

namespace CodeSide.UI.Helpers
{

    /// <summary>
    /// Provides helper functions for platform management
    /// </summary>
    public static class WindowsHelper
    {
        /// <summary>
        /// This operating system build info
        /// </summary>
        public static OSVERSIONINFOEX BuildInfo;

        /// <summary>
        /// Initializes the <see cref="WindowsHelper"/> class.
        /// </summary>
        static WindowsHelper()
        {
            var version = new OSVERSIONINFOEX
            {
                OSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
            };

            if (RtlGetVersion(ref version) != NTSTATUS.STATUS_SUCCESS)
                return;

            IsSeven = version.MajorVersion == 6 && version.MinorVersion == 1 && (version.BuildNumber >= 7600 && version.BuildNumber <= 7601);
            IsEight = version.MajorVersion == 6 && version.MinorVersion >= 2 && (version.BuildNumber >= 9200 && version.BuildNumber <= 9999);
            IsTen = version.MajorVersion == 10 && (version.BuildNumber >= 10240 && version.BuildNumber <= 20000);
            IsEleven = version.BuildNumber >= 22000;
            IsModern = IsTen || IsEleven;
            VisualStylesEnabled = VisualStyleInformation.IsEnabledByUser;
            BuildInfo = version;

            SystemEvents.UserPreferenceChanged += (s, e) =>
            {
                var vsEnabled = VisualStyleInformation.IsEnabledByUser;
                if (vsEnabled != VisualStylesEnabled)
                {
                    VisualStylesEnabled = vsEnabled;
                    UserPreferenceChangedEvent?.Invoke();
                }
            };
        }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 7.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 7; otherwise, <c>false</c>.
        /// </value>
        public static bool IsSeven { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 8.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 8; otherwise, <c>false</c>.
        /// </value>
        public static bool IsEight { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 10.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 10; otherwise, <c>false</c>.
        /// </value>
        public static bool IsTen { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 11.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 11; otherwise, <c>false</c>.
        /// </value>
        public static bool IsEleven { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 11.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 10 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool IsModern { get; private set; }

        /// <summary>
        /// Returns a value indicating whether Visual Styles are enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if Visual Styles are enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool VisualStylesEnabled { get; private set; }
        public static Action UserPreferenceChangedEvent { get; set; }

        /// <summary>
        /// Is the dark theme activated in the operating system <c>true</c>; otherwise <c>false</c>
        /// </summary>
        /// <returns></returns>
        public static bool IsDark()
        {
            int value = 1;
            if (IsTen || IsEleven)
            {
                try
                {
                    var personalize = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";
                    value = (int)Registry.GetValue(personalize, "AppsUseLightTheme", 1);
                }
                catch
                {
                    return false;
                }
            }

            return value == 0;
        }

        /// <summary>
        /// Set native app theme for this application
        /// </summary>
        /// <param name="handle">The window handle</param>
        /// <param name="isDark">Is dark <c>true</c> otherwise <c>false</c></param>
        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsTen || IsEleven)
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (BuildInfo.BuildNumber > 18980)
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                if (enabled)
                {
                    SetWindowTheme(handle, "DarkMode_Explorer", null);
                    //System.Windows.Forms.MessageBox.Show("Dark mode activated");
                }
                else
                    SetWindowTheme(handle, "Explorer", null);

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }
    }
}