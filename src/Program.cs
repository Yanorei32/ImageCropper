using System;
using System.Windows.Forms;

class Program {
	[STAThread]
	static void Main(string[] Args) {
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new MainForm());
	}
}

