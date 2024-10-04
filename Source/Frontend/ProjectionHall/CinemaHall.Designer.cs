namespace Ergasia3.Source.Frontend.CinemaHall
{
	partial class CinemaHall
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CinemaHall ) );
			this.panel1 = new Panel();
			this.panel8 = new Panel();
			this.panel9 = new Panel();
			this.helpLbl = new LinkLabel();
			this.label1 = new Label();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.rightArrow = new Button();
			this.leftArrow = new Button();
			this.playButton = new Button();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			(( System.ComponentModel.ISupportInitialize )this.mediaPlayer).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = Color.MediumSlateBlue;
			this.panel1.Controls.Add( this.panel8 );
			this.panel1.Controls.Add( this.panel2 );
			this.panel1.ForeColor = SystemColors.ControlText;
			this.panel1.Location = new Point( 2, 3 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size( 800, 553 );
			this.panel1.TabIndex = 1;
			// 
			// panel8
			// 
			this.panel8.BackColor = Color.DarkSlateBlue;
			this.panel8.Controls.Add( this.panel9 );
			this.panel8.ForeColor = SystemColors.ControlText;
			this.panel8.Location = new Point( 3, 3 );
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size( 794, 56 );
			this.panel8.TabIndex = 46;
			// 
			// panel9
			// 
			this.panel9.BackColor = Color.MediumSlateBlue;
			this.panel9.Controls.Add( this.helpLbl );
			this.panel9.Controls.Add( this.label1 );
			this.panel9.ForeColor = SystemColors.ControlText;
			this.panel9.Location = new Point( 3, 3 );
			this.panel9.Name = "panel9";
			this.panel9.Size = new Size( 789, 51 );
			this.panel9.TabIndex = 0;
			// 
			// helpLbl
			// 
			this.helpLbl.ActiveLinkColor = Color.Snow;
			this.helpLbl.AutoSize = true;
			this.helpLbl.BackColor = Color.MediumSlateBlue;
			this.helpLbl.Font = new Font( "Lucida Console", 16.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.helpLbl.ForeColor = SystemColors.ControlText;
			this.helpLbl.LinkColor = Color.DarkSlateBlue;
			this.helpLbl.Location = new Point( 10, 11 );
			this.helpLbl.Name = "helpLbl";
			this.helpLbl.Size = new Size( 30, 28 );
			this.helpLbl.TabIndex = 25;
			this.helpLbl.TabStop = true;
			this.helpLbl.Text = "?";
			this.helpLbl.VisitedLinkColor = Color.Snow;
			this.helpLbl.LinkClicked += this.helpLbl_LinkClicked;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.MediumSlateBlue;
			this.label1.FlatStyle = FlatStyle.Flat;
			this.label1.Font = new Font( "Lucida Bright", 22.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.label1.ForeColor = Color.Snow;
			this.label1.Location = new Point( 289, 4 );
			this.label1.Name = "label1";
			this.label1.Size = new Size( 232, 42 );
			this.label1.TabIndex = 22;
			this.label1.Text = "Cinema hall";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = Color.DarkSlateBlue;
			this.panel2.Controls.Add( this.panel3 );
			this.panel2.ForeColor = SystemColors.ControlText;
			this.panel2.Location = new Point( 3, 61 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size( 794, 488 );
			this.panel2.TabIndex = 45;
			// 
			// panel3
			// 
			this.panel3.BackColor = Color.MediumSlateBlue;
			this.panel3.Controls.Add( this.rightArrow );
			this.panel3.Controls.Add( this.leftArrow );
			this.panel3.Controls.Add( this.playButton );
			this.panel3.Controls.Add( this.panel5 );
			this.panel3.ForeColor = SystemColors.ControlText;
			this.panel3.Location = new Point( 3, 3 );
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size( 789, 481 );
			this.panel3.TabIndex = 0;
			// 
			// rightArrow
			// 
			this.rightArrow.BackColor = Color.DarkSlateBlue;
			this.rightArrow.Font = new Font( "Lucida Bright", 16.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.rightArrow.ForeColor = Color.Snow;
			this.rightArrow.Location = new Point( 615, 399 );
			this.rightArrow.Name = "rightArrow";
			this.rightArrow.Padding = new Padding( 6, 0, 0, 3 );
			this.rightArrow.Size = new Size( 107, 67 );
			this.rightArrow.TabIndex = 52;
			this.rightArrow.Text = ">>";
			this.rightArrow.UseVisualStyleBackColor = false;
			this.rightArrow.Click += this.rightArrow_Click;
			// 
			// leftArrow
			// 
			this.leftArrow.BackColor = Color.DarkSlateBlue;
			this.leftArrow.Font = new Font( "Lucida Bright", 16.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.leftArrow.ForeColor = Color.Snow;
			this.leftArrow.Location = new Point( 69, 399 );
			this.leftArrow.Name = "leftArrow";
			this.leftArrow.Padding = new Padding( 0, 0, 3, 3 );
			this.leftArrow.Size = new Size( 107, 67 );
			this.leftArrow.TabIndex = 51;
			this.leftArrow.Text = "<<";
			this.leftArrow.UseVisualStyleBackColor = false;
			this.leftArrow.Click += this.leftArrow_Click;
			// 
			// playButton
			// 
			this.playButton.BackColor = Color.DarkSlateBlue;
			this.playButton.Font = new Font( "Lucida Bright", 18F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.playButton.ForeColor = Color.Snow;
			this.playButton.Location = new Point( 290, 399 );
			this.playButton.Name = "playButton";
			this.playButton.Padding = new Padding( 9, 0, 0, 3 );
			this.playButton.Size = new Size( 219, 67 );
			this.playButton.TabIndex = 50;
			this.playButton.Text = "|>";
			this.playButton.UseVisualStyleBackColor = false;
			this.playButton.Click += this.playButton_Click;
			// 
			// panel5
			// 
			this.panel5.BackColor = Color.DarkSlateBlue;
			this.panel5.Controls.Add( this.panel4 );
			this.panel5.ForeColor = SystemColors.ControlText;
			this.panel5.Location = new Point( 3, 3 );
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size( 781, 383 );
			this.panel5.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.BackColor = Color.MediumSlateBlue;
			this.panel4.Controls.Add( this.mediaPlayer );
			this.panel4.ForeColor = SystemColors.ControlText;
			this.panel4.Location = new Point( 3, 3 );
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size( 775, 377 );
			this.panel4.TabIndex = 46;
			// 
			// mediaPlayer
			// 
			this.mediaPlayer.Enabled = true;
			this.mediaPlayer.Location = new Point( 4, 4 );
			this.mediaPlayer.Margin = new Padding( 3, 4, 3, 4 );
			this.mediaPlayer.Name = "mediaPlayer";
			this.mediaPlayer.OcxState = ( AxHost.State )resources.GetObject( "mediaPlayer.OcxState" );
			this.mediaPlayer.Size = new Size( 768, 369 );
			this.mediaPlayer.TabIndex = 0;
			// 
			// CinemaHall
			// 
			this.AutoScaleDimensions = new SizeF( 8F, 20F );
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.DarkSlateBlue;
			this.ClientSize = new Size( 805, 557 );
			this.Controls.Add( this.panel1 );
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Margin = new Padding( 3, 4, 3, 4 );
			this.Name = "CinemaHall";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosed += this.ProjectionHall_FormClosed;
			this.panel1.ResumeLayout( false );
			this.panel8.ResumeLayout( false );
			this.panel9.ResumeLayout( false );
			this.panel9.PerformLayout();
			this.panel2.ResumeLayout( false );
			this.panel3.ResumeLayout( false );
			this.panel5.ResumeLayout( false );
			this.panel4.ResumeLayout( false );
			(( System.ComponentModel.ISupportInitialize )this.mediaPlayer).EndInit();
			this.ResumeLayout( false );
		}

		#endregion

		private Panel panel1;
		private Panel panel2;
		private Panel panel3;
		private Panel panel5;
		private Panel panel4;
		private Panel panel8;
		private Panel panel9;
		private Label label1;
		private Button leftArrow;
		private Button playButton;
		private Button rightArrow;
		private LinkLabel helpLbl;
		private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
	}
}