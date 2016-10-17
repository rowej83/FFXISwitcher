/*
 * Created by SharpDevelop.
 * User: jrowe
 * Date: 10/4/2016
 * Time: 3:43 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FFXISwitcher
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnReIndex = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textAddExclusion = new System.Windows.Forms.TextBox();
			this.listExclusions = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnReIndex
			// 
			this.btnReIndex.Location = new System.Drawing.Point(12, 209);
			this.btnReIndex.Name = "btnReIndex";
			this.btnReIndex.Size = new System.Drawing.Size(134, 90);
			this.btnReIndex.TabIndex = 1;
			this.btnReIndex.Text = "Re-Index Chars";
			this.btnReIndex.UseVisualStyleBackColor = true;
			this.btnReIndex.Click += new System.EventHandler(this.btnReIndex_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(7, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(356, 174);
			this.textBox1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.textAddExclusion);
			this.groupBox1.Controls.Add(this.listExclusions);
			this.groupBox1.Location = new System.Drawing.Point(152, 190);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(211, 119);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Exclusions (Double Click To Delete):";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(108, 51);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 58);
			this.button1.TabIndex = 2;
			this.button1.Text = "Add Above Char To Exclude";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textAddExclusion
			// 
			this.textAddExclusion.Location = new System.Drawing.Point(108, 25);
			this.textAddExclusion.Name = "textAddExclusion";
			this.textAddExclusion.Size = new System.Drawing.Size(92, 20);
			this.textAddExclusion.TabIndex = 0;
			// 
			// listExclusions
			// 
			this.listExclusions.FormattingEnabled = true;
			this.listExclusions.Location = new System.Drawing.Point(6, 25);
			this.listExclusions.Name = "listExclusions";
			this.listExclusions.Size = new System.Drawing.Size(96, 82);
			this.listExclusions.TabIndex = 0;
			this.listExclusions.DoubleClick += new System.EventHandler(this.ListExclusionsDoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 314);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnReIndex);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "FFXISwitcher";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textAddExclusion;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listExclusions;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnReIndex;
	}
}
