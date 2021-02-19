using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeSide.Native
{
	public static class Win32
	{
		public const int WM_COPYDATA = 0x004A;
		public const int SW_MAXIMIZE = 3;
		public const int SW_RESTORE = 9;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyData lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);


		[DllImport("user32")]
		public static extern int RegisterWindowMessage(string message);

		[DllImport("user32.dll")]
		public static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsZoomed(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		// TODO: possibly could send custom structs by changing CopyData.lpData to an IntPtr
		public static IntPtr IntPtrAlloc<T>(T param)
		{
			IntPtr retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
			Marshal.StructureToPtr(param, retval, false);
			return retval;
		}

		public static void IntPtrFree(IntPtr preAllocated)
		{
			if (IntPtr.Zero == preAllocated) throw new InvalidOperationException("IntPtr is already 0");
			Marshal.FreeHGlobal(preAllocated);
			preAllocated = IntPtr.Zero;
		}

		public static T GetStruct<T>(IntPtr param)
		{
			return (T)Marshal.PtrToStructure(param, typeof(T));
		}

		public static IntPtr StringToIntPtr(string data)
		{
			return Marshal.StringToHGlobalAnsi(data);
		}

		public static string IntPtrToString(IntPtr data)
		{
			return Marshal.PtrToStringAnsi(data);
		}

	}
}
