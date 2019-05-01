/*
 * Created by SharpDevelop.
 * User: jens
 * Date: 2008-01-19
 * Time: 12:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace tidslinje
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
   
    	
	public partial class MainForm
	{
		private int antalmin = 0;
	
		[STAThread]
		 
		
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			Char tmchar = '\u2122';
			string t_string = "TIME" + tmchar;
			this.linkLabel1.Text= "Om " + t_string;
			this.Text=t_string;
			
			this.linkLabel1.Links.Add(0,26, "http://www.sarnat.educ.goteborg.se/time.htm");
			for (int i=1; i<=300; i++)
				this.domainUpDown1.Items.Add(i.ToString());
			
			
			
			
			
		}
		
		void DomainUpDown1SelectedItemChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void ProgressBar1Click(object sender, System.EventArgs e)
		{
				
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
			string s_antalmin=this.domainUpDown1.Text.ToString();
			
			try
			{
				antalmin = int.Parse(s_antalmin);
				antalmin = 60*antalmin;
				if (antalmin<0)
					antalmin = -1*antalmin;
				if (antalmin==0)
					antalmin = 1;
				this.progressBar1.Maximum=antalmin;
				this.progressBar1.Value=antalmin;
				this.timer1.Start();
				this.panel2.Show();
			}
			catch (Exception e1)
			{
				MessageBox.Show("Not a Number");
			}
			
		}
		
		

		
		void Timer1Tick(object sender, System.EventArgs e)
		{
			//MessageBox.Show("Hej");
			
			antalmin--;
			this.progressBar1.Value=antalmin;
			
			
			if (antalmin==0)
			{
				timer1.Stop();
				timer1.Enabled = false;
				SystemSounds.Asterisk.Play();
				//SystemSounds.Beep.Play();
				//SystemSounds.Hand.Play();
				//SystemSounds.Question.Play();
				//SystemSounds.Exclamation.Play();
				
			}
			
		}
		
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			timer1.Stop();
			timer1.Enabled = false;
			timer1.Dispose();
		}
		
		void LinkLabel1LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}
	}
}
