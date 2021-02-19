using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static CodeSide.Native.Win32;

namespace CodeSide.Native
{
	/// <summary>
	/// Pre-assembled class for sending/receiving strings between Windows applications.
	/// </summary>
	public static class MessagePasser
	{
		/// <summary>
		/// ReceiveData will throw if Message.Msg isn't WindowsMessageId
		/// </summary>
		public static bool ThrowOnBadMessage = true;
		/// <summary>
		/// Defaults to MS COPYDATA, can use NativeMethods.RegisterWindowMessage to create a new MessageId
		/// </summary>
		public static int WindowsMessageId = WM_COPYDATA;

		/// <summary>
		/// Sends "data" to the target window
		/// </summary>
		/// <param name="targetWindowHandle"></param>
		/// <param name="messageId">Usually WM_COPYDATA</param>
		/// <param name="id"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static int SendData(IntPtr targetWindowHandle, int messageId, int id, string message)
		{
			var data = new CopyData();
			data.dwData = new IntPtr(id);
			data.cbData = (message.Length + 1) * Marshal.SystemDefaultCharSize;
			data.lpData = message;

			var resp = SendMessage(
				targetWindowHandle,
				messageId,
				IntPtr.Zero,
				ref data
			);
			
			//var er = Marshal.GetLastWin32Error();
			/*
			 * TODO: Although the code does its job, it throws the 127 status.
			 if (er != 0)
				throw new Win32Exception(er);
			*/

			return resp.ToInt32();
		}

		/// <summary>
		/// Send a string with an id
		/// </summary>
		/// <param name="targetWindowHandle"></param>
		/// <param name="id"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static int SendString(IntPtr targetWindowHandle, int id, string message)
		{
			return SendData(targetWindowHandle, WindowsMessageId, id, message);
		}

		/// <summary>
		/// Call to send a string with message type 1.
		/// </summary>
		/// <param name="targetWindowHandle"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static int SendString(IntPtr targetWindowHandle, string message)
		{
			return SendString(targetWindowHandle, 1, message);
		}

		/// <summary>
		/// Call this from WndProc to switch on dwData
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		public static CopyData ReceiveData(Message m)
		{
			if (m.Msg != WindowsMessageId)
			{
				if (ThrowOnBadMessage)
					throw new InvalidOperationException("Message isn't WM_COPYDATA");
				return default(CopyData);
			}

			m.Result = new IntPtr(1);
			var data = (CopyData)m.GetLParam(typeof(CopyData));

			m.Result = new IntPtr(0);
			return data;
		}

		/// <summary>
		/// Call this from WndProc if you don't care about message types
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		public static string ReceiveString(Message m)
		{
			return ReceiveData(m).lpData;
		}
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CopyData
	{
		/// <summary>
		/// data to be passed, can be used as a message type identifier
		/// </summary>
		public IntPtr dwData;
		/// <summary>
		/// sizeof lpData
		/// </summary>
		public int cbData;
		/// <summary>
		/// data to be passed, can be null
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpData;
	}
}