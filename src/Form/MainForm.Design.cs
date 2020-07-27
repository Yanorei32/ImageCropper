using System;
using System.Drawing;
using System.Windows.Forms;

partial class MainForm : Form {
	void initializeComponent() {
		const int
			textBoxW = 320,
			margin	= 13,
			padding	= 6;

		int curW = 0, curH = 0;

		this.resolution		= new Label();
		this.set			= new Button();
		this.crop			= new Button();
		this.statusStrip	= new StatusStrip();
		this.statusLabel	= new ToolStripStatusLabel();

		this.SuspendLayout();
		curW = margin;
		curH = 0;

		/*\
		|*| Resolution
		\*/
		this.resolution.AutoSize	= false;
		this.resolution.Location	= new Point(curW, curH);
		this.resolution.Size		= new Size(textBoxW, 22);
		this.resolution.Font		= new Font("Consolas", 16F);

		curH += this.resolution.Size.Height;
		curH += padding;

		/*\
		|*| Button
		\*/
		this.set.Text			= "Set (&S)";
		this.set.Location		= new Point(curW, curH);
		this.set.Size			= new Size(textBoxW / 2 - padding, 35);
		this.set.Click			+= new EventHandler(setButtonClick);
		this.set.Font			= new Font("Consolas", 14F);
		this.set.UseMnemonic	= true;

		curW += this.crop.Size.Width * 2;
		curW += padding;

		this.crop.Text			= "Crop (&C)";
		this.crop.Location		= new Point(curW, curH);
		this.crop.Size			= new Size(textBoxW / 2 - padding, 35);
		this.crop.Click			+= new EventHandler(cropButtonClick);
		this.crop.Font			= new Font("Consolas", 14F);
		this.crop.UseMnemonic	= true;

		curW = margin;
		curH += this.crop.Size.Height;
		curH += 22;

		this.statusStrip.Items.Add(this.statusLabel);
		this.Controls.Add(statusStrip);
		
		this.ClientSize			= new Size(textBoxW + (margin * 1), curH);
		this.MinimumSize		= this.Size;
		this.MaximumSize		= this.Size;
		this.TopMost			= true;

		this.Controls.Add(this.resolution);
		this.Controls.Add(this.set);
		this.Controls.Add(this.crop);
		this.ResumeLayout(false);
	}
}

