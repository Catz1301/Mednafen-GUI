
namespace Mednafen_GUI {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.playBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.gamesListBox = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// playBtn
			// 
			this.playBtn.Location = new System.Drawing.Point(443, 324);
			this.playBtn.Name = "playBtn";
			this.playBtn.Size = new System.Drawing.Size(83, 36);
			this.playBtn.TabIndex = 1;
			this.playBtn.Text = "Play";
			this.playBtn.UseVisualStyleBackColor = true;
			this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(12, 323);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(425, 16);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "Select the game you wish to play.";
			// 
			// gamesListBox
			// 
			this.gamesListBox.FormattingEnabled = true;
			this.gamesListBox.ItemHeight = 15;
			this.gamesListBox.Location = new System.Drawing.Point(12, 12);
			this.gamesListBox.Name = "gamesListBox";
			this.gamesListBox.Size = new System.Drawing.Size(514, 304);
			this.gamesListBox.Sorted = true;
			this.gamesListBox.TabIndex = 0;
			this.gamesListBox.SelectedIndexChanged += new System.EventHandler(this.gamesListBox_SelectedIndexChanged);
			this.gamesListBox.DoubleClick += new System.EventHandler(this.playBtn_Click);
			this.gamesListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gamesListBox_KeyUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(538, 372);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.playBtn);
			this.Controls.Add(this.gamesListBox);
			this.Name = "Form1";
			this.Text = "MednafenGUI";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button playBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox gamesListBox;
	}
}

