using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mednafen_GUI {
	public partial class Form1:Form {
		List<string> cueFileNames = new List<string>();
		List<string> cueFilePaths = new List<string>();
		string selectedGameName = "";
		string selectedGamePath = "";
		public Form1() {
			InitializeComponent();
			List<string> games = new List<string>();
			string bdStr = Program.mednafenBaseDir;
			Console.WriteLine(bdStr);
			getDirs(bdStr);
			gamesListBox.Items.AddRange(cueFileNames.ToArray());
		}

		private void getDirs(string startingDir) {
			IEnumerable<string> directories = Directory.EnumerateDirectories(startingDir);
			foreach (string directory in directories) {
				//Console.WriteLine(directory);
				if (Directory.GetDirectories(directory, "", SearchOption.AllDirectories).Length > 0) {
					getDirs(directory);
				}
				if (Directory.GetFiles(directory).Length > 0) {
					IEnumerable<string> files = Directory.EnumerateFiles(directory);
					bool cueFound = false;
					bool binFound = false;
					string cueFileName = "";
					string cueFilePath = "";
					foreach (string file in files) {
						if (file.Contains(".bin"))
							binFound = true;
						if (file.Contains(".cue")) {
							cueFound = true;
							FileInfo fi = new FileInfo(file);
							cueFilePath = fi.FullName;
							string cueFileNameTmp = fi.Name;
							int extensionCut = fi.Name.Length - ".cue".Length;
							cueFileName = cueFileNameTmp.Substring(0, extensionCut);
						}
					}
					if (cueFound && binFound) {
						cueFilePaths.Add(cueFilePath);
						cueFileNames.Add(cueFileName);
					}
				}
			}
			//return null;
		} 

		private void playBtn_Click(object sender, EventArgs e) {
			runGame();
		}

		private void gamesListBox_SelectedIndexChanged(object sender, EventArgs e) {
			selectedGameName = (string) gamesListBox.SelectedItem;
			//MessageBox.Show(selectedGameName, "Debug");
		}

		private void gamesListBox_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
				runGame();
		}

		private void runGame() {
			if (selectedGameName != "") {
				var filePaths = cueFilePaths.GetEnumerator();
				foreach (string filePath in cueFilePaths) {
					if (filePath.Contains(selectedGameName)) {
						selectedGamePath = filePath;
						System.Diagnostics.Process process = new System.Diagnostics.Process();
						System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
						//startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
						startInfo.FileName = "\"" + Program.mednafenBaseDir + "\\mednafen.exe\"";
						startInfo.Arguments = "\"" + selectedGamePath + "\"";
						process.StartInfo = startInfo;
						process.Start();
					}
				}
			}
		}
	}
}
