using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

partial class MainForm : Form {
	Label	resolution;
	Button	set, crop;

	StatusStrip				statusStrip;
	ToolStripStatusLabel	statusLabel;

	Size size;

	static Image cropImage(Image orig, Size s) {
		bool illegalW, illegalH;

		illegalW = orig.Width < s.Width;
		illegalH = orig.Height < s.Height;

		if (illegalW || illegalH) {
			throw new ArgumentException(
				string.Format(
					"original {0}{1}{2} < cropped {0}{1}{2}",
					illegalW ? "width" : string.Empty,
					illegalW && illegalH ? "/" : string.Empty,
					illegalH ? "height" : string.Empty
				)
			);
		}

		if (s.IsEmpty) {
			throw new ArgumentException("cropped size is empty");
		}

		Bitmap cropped = new Bitmap(s.Width, s.Height);

		Graphics g = Graphics.FromImage(cropped);

		g.InterpolationMode = InterpolationMode.Low;

		g.DrawImage(orig, 0, 0);

		return cropped;
	}

	void updateUI() {
		resolution.Text = "Resolution: ";

		if (size.IsEmpty)
			resolution.Text += "Empty";
		else
			resolution.Text += string.Format(
				"{0}x{1}",
				size.Width,
				size.Height
			);
	}

	void updateStatus(string status) {
		statusLabel.Text = status;
	}

	void setButtonClick(object sender, EventArgs e) {
		Image i = Clipboard.GetImage();

		if (i == null) {
			updateStatus("failed to get image");
			return;
		}

		size = new Size(i.Width, i.Height);

		updateStatus("new size setted");
		updateUI();
	}

	void cropButtonClick(object sender, EventArgs e) {
		Image i = Clipboard.GetImage();

		if (i == null) {
			updateStatus("failed to get image");
			return;
		}

		try {
			Clipboard.SetImage(cropImage(i, size));
		} catch (ArgumentException ae) {
			updateStatus(ae.Message);
			return;
		}

		updateStatus("cropped");
	}

	public MainForm() {
		initializeComponent();
		size = new Size(0, 0);
		updateUI();
		updateStatus("ready");
	}
}

