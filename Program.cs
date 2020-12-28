using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mednafen_GUI {
	static class Program {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>

		public static string mednafenBaseDir;
		[STAThread]
		static void Main() {
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if ((new FileInfo("mednafenGUI.cfg")).Exists) {
				int errCode = 0;
				try {
					FileStream fs = new FileStream("mednafenGUI.cfg", FileMode.Open);
					StreamReader stream = new StreamReader(fs);
					mednafenBaseDir = stream.ReadLine();
					stream.Close();
					fs.Dispose();
				} catch (Exception e) {
					MessageBox.Show("An exeption occured and the developer was too tired to say what it is. Sorry.\r\nException info: " + e.Message);
					errCode = e.HResult;
					MessageBox.Show("Learn to use the command line!");
					Environment.Exit(errCode);
				}
			} 
			else {
				DialogResult messageBox = MessageBox.Show("Mednafen base directory not set. Would you like to do so now?", "MednafenGUI Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (messageBox == DialogResult.Yes) {
					FolderBrowserDialog baseFolder = new FolderBrowserDialog();
					baseFolder.ShowNewFolderButton = false;
					baseFolder.Description = "Select the folder that mednafen.exe is in.";
					DialogResult folder = baseFolder.ShowDialog();
					if (folder == DialogResult.OK) {
						int errCode = 0;
						try {
							FileStream fs = new FileStream("mednafenGUI.cfg", FileMode.Create);
							StreamWriter stream = new StreamWriter(fs);
							stream.Write(baseFolder.SelectedPath);
							stream.Close();
							fs.Dispose();
						} catch (Exception e) {
							MessageBox.Show("An exeption occured and the developer was too tired to say what it is. Sorry.\r\nException info: " + e.Message);
							errCode = e.HResult;
							Environment.Exit(errCode);
						}
						mednafenBaseDir = baseFolder.SelectedPath;
					} else {
						Environment.Exit(0);
					}
				}
			}
			Application.Run(new Form1());
		}
	}
}
