/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 10/4/2016
 * Time: 3:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace FFXISwitcher
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private LowLevelKeyboardListener _listener;
        private Process[] game;
        private List<IntPtr> instances = new List<IntPtr>();
        private int currentItem = 0;
        
        /// <summary>
        /// Forces the provided window handle to be brought to the foreground
        /// </summary>
        /// <param name="hWnd">The window handle that is to be brought to the foreground.</param>
        private void ForceForegroundWindow(IntPtr hWnd)
        {
            uint a;

            IntPtr hWndForeground = WinAPI.GetForegroundWindow();
            if (hWndForeground != hWnd)
            {
                uint thread1 = WinAPI.GetWindowThreadProcessId(hWndForeground, out a);
                uint thread2 = WinAPI.GetCurrentThreadId();

                if (thread1 != thread2)
                {
                    WinAPI.AttachThreadInput(thread1, thread2, true);
                    WinAPI.BringWindowToTop(hWnd);
                    if (WinAPI.IsIconic(hWnd))
                    {
                        WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowFlags.SW_SHOWNORMAL);
                    }
                    else
                    {
                        WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowFlags.SW_SHOW);
                    }
                    WinAPI.AttachThreadInput(thread1, thread2, false);
                }
                else
                {
                    WinAPI.SetForegroundWindow(hWnd);
                }
                if (WinAPI.IsIconic(hWnd))
                {
                    WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowFlags.SW_SHOWNORMAL);
                }
                else
                {
                    WinAPI.ShowWindow(hWnd, WinAPI.ShowWindowFlags.SW_SHOW);
                }
            }
        }
        
         /// <summary>
    /// Goes thru all available instances of pol and creates a list of handles that will 
    /// later be used to bring to the foreground by the hotkey
    /// </summary>
        private void createIndex()
        {
            instances.Clear();
            game = Process.GetProcessesByName("pol");

            if (game.Length == 0)
            {
                WriteLine("No instances of FFXI found");
                return;
            }
            if (game.Length == 1)
            {
                WriteLine("Only 1 char found. Hotkey will not be set");
                return;
            }
            foreach (Process instance in game)
            {
            
                instances.Add(instance.MainWindowHandle);

               
            }
            currentItem = 0;
            WriteLine(instances.Count.ToString() + " instances of FFXI found at "+DateTime.Now);
          
            this.Text = instances.Count.ToString() + " instances of FFXI found.";
        }
        
        
        /// <summary>
        /// iterates thru the list of handles for which window will be next to pull to the foreground and
        /// attempts to bring the window to the foreground
        /// </summary>
        /// <param name="index">index to be used within the list for which handle is next to be invoked to foreground</param>
        private void bringNextToFront(int index)
        {
      
            var handle = instances[index];
    
            if (handle == IntPtr.Zero)
            {
                return;
            }

            ForceForegroundWindow(handle);
  
        }
        
        /// <summary>
        ///  attachs the keybinding and creates initial list of available xi handles.
        /// </summary>
        public MainForm()
		{

			InitializeComponent();
			 _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
 
            _listener.HookKeyboard();
            WriteLine("Hot Key has been registered");
            createIndex();

		}
        /// <summary>
        /// event attached to when the special hotkey is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		
		 void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
           
		 	if (e.KeyPressed == Key.OemPipe)
			{

           
                bringNextToFront(currentItem);
                currentItem++;
              //  WriteLine(instances.Count.ToString() + " instances of FFXI found at "+DateTime.Now);
                if (currentItem == (instances.Count)){ currentItem = 0; }
                  

            }
	
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		/// <summary>
		/// writes to textbox1 to notify the user of any events within the app
		/// </summary>
		/// <param name="newText"></param>
		void WriteLine(string newText){
			textBox1.AppendText(newText);
			textBox1.AppendText(Environment.NewLine);
		}
		
		/// <summary>
		/// unhooks the hotkey upon closing the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainForm_FormClosing(object sender, EventArgs e){
		   _listener.UnHookKeyboard();
		}

		/// <summary>
		/// button to manually update the list of available xi handles.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnReIndex_Click(object sender, EventArgs e)
        {
            createIndex();
        }
    }
}
