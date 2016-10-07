/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 10/4/2016
 * Time: 3:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace FFXISwitcher
{
	/// <summary>
	/// Description of Class2.
	/// </summary>
public class LowLevelKeyboardListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
 
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
 
        public event EventHandler<KeyPressedArgs> OnKeyPressed;
 
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
 
        public LowLevelKeyboardListener()
        {
            _proc = HookCallback;
        }
 
        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }
 
        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }
 
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
 
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
        	int vkCode=0;
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                 vkCode = Marshal.ReadInt32(lParam);
 
                if (OnKeyPressed != null) { OnKeyPressed(this, new KeyPressedArgs(KeyInterop.KeyFromVirtualKey(vkCode))); }
            }
 
         //   Console.WriteLine(vkCode);
             
            if (KeyInterop.KeyFromVirtualKey(vkCode) !=Key.OemPipe) {
            	   return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }else{
         
            
            return (IntPtr)(-1);
         }
         
       
        }
    }
 
    public class KeyPressedArgs : EventArgs
    {
        public Key KeyPressed { get; private set; }
 
        public KeyPressedArgs(Key key)
        {
            KeyPressed = key;
        }
    }
}
