namespace Ergasia3.Source.Frontend.DJockeyHall
{
	partial class Karaoke
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			ListViewGroup listViewGroup1 = new ListViewGroup( "TItle", HorizontalAlignment.Left );
			ListViewGroup listViewGroup2 = new ListViewGroup( "Artist", HorizontalAlignment.Left );
			ListViewGroup listViewGroup3 = new ListViewGroup( "Category", HorizontalAlignment.Left );
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Karaoke ) );
			this.panel6 = new Panel();
			this.panel5 = new Panel();
			this.panel15 = new Panel();
			this.SignUpLbl = new LinkLabel();
			this.label3 = new Label();
			this.panel7 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.songsListView = new ListView();
			this.columnHeader1 = new ColumnHeader();
			this.columnHeader2 = new ColumnHeader();
			this.columnHeader3 = new ColumnHeader();
			this.columnHeader4 = new ColumnHeader();
			this.panel2 = new Panel();
			this.panel20 = new Panel();
			this.label1 = new Label();
			this.panel8 = new Panel();
			this.playingSongLbl = new TextBox();
			this.label2 = new Label();
			this.volumeLbl = new Label();
			this.panel1 = new Panel();
			this.panel9 = new Panel();
			this.panel10 = new Panel();
			this.panel11 = new Panel();
			this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.nextSongBtn = new Button();
			this.prevSongBtn = new Button();
			this.pauseButton = new Button();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel11.SuspendLayout();
			(( System.ComponentModel.ISupportInitialize )this.mediaPlayer).BeginInit();
			this.SuspendLayout();
			// 
			// panel6
			// 
			this.panel6.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel6.Controls.Add( this.panel5 );
			this.panel6.Controls.Add( this.panel7 );
			this.panel6.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel6.Location = new Point( 3, 2 );
			this.panel6.Margin = new Padding( 3, 2, 3, 2 );
			this.panel6.Name = "panel6";
			this.panel6.Size = new Size( 959, 387 );
			this.panel6.TabIndex = 16;
			// 
			// panel5
			// 
			this.panel5.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel5.Controls.Add( this.panel15 );
			this.panel5.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel5.Location = new Point( 3, 2 );
			this.panel5.Margin = new Padding( 3, 2, 3, 2 );
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size( 954, 42 );
			this.panel5.TabIndex = 33;
			// 
			// panel15
			// 
			this.panel15.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel15.Controls.Add( this.SignUpLbl );
			this.panel15.Controls.Add( this.label3 );
			this.panel15.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel15.Location = new Point( 3, 2 );
			this.panel15.Margin = new Padding( 3, 2, 3, 2 );
			this.panel15.Name = "panel15";
			this.panel15.Size = new Size( 948, 38 );
			this.panel15.TabIndex = 0;
			// 
			// SignUpLbl
			// 
			this.SignUpLbl.ActiveLinkColor = Color.Snow;
			this.SignUpLbl.AutoSize = true;
			this.SignUpLbl.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.SignUpLbl.Font = new Font( "Lucida Console", 16.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.SignUpLbl.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.SignUpLbl.LinkColor = Color.DarkSlateBlue;
			this.SignUpLbl.Location = new Point( 7, 8 );
			this.SignUpLbl.Name = "SignUpLbl";
			this.SignUpLbl.Size = new Size( 24, 22 );
			this.SignUpLbl.TabIndex = 25;
			this.SignUpLbl.TabStop = true;
			this.SignUpLbl.Text = "?";
			this.SignUpLbl.VisitedLinkColor = Color.Snow;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.label3.FlatStyle = FlatStyle.Flat;
			this.label3.Font = new Font( "Lucida Bright", 22.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.label3.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.label3.Location = new Point( 412, 3 );
			this.label3.Name = "label3";
			this.label3.Size = new Size( 140, 34 );
			this.label3.TabIndex = 22;
			this.label3.Text = "Karaoke";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel7
			// 
			this.panel7.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel7.Controls.Add( this.panel4 );
			this.panel7.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel7.Location = new Point( 3, 46 );
			this.panel7.Margin = new Padding( 3, 2, 3, 2 );
			this.panel7.Name = "panel7";
			this.panel7.Size = new Size( 954, 339 );
			this.panel7.TabIndex = 16;
			// 
			// panel4
			// 
			this.panel4.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel4.Controls.Add( this.panel3 );
			this.panel4.Controls.Add( this.panel2 );
			this.panel4.Controls.Add( this.panel1 );
			this.panel4.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel4.Location = new Point( 3, 2 );
			this.panel4.Margin = new Padding( 3, 2, 3, 2 );
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size( 948, 334 );
			this.panel4.TabIndex = 11;
			// 
			// panel3
			// 
			this.panel3.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel3.Controls.Add( this.songsListView );
			this.panel3.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel3.Location = new Point( 394, 2 );
			this.panel3.Margin = new Padding( 3, 2, 3, 2 );
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size( 551, 262 );
			this.panel3.TabIndex = 1;
			// 
			// songsListView
			// 
			this.songsListView.BackColor = Color.FromArgb(     141,     153,     174 );
			this.songsListView.BorderStyle = BorderStyle.None;
			this.songsListView.Columns.AddRange( new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4 } );
			this.songsListView.Font = new Font( "Lucida Bright", 10.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.songsListView.ForeColor = Color.FromArgb(     237,     242,     244 );
			this.songsListView.GridLines = true;
			listViewGroup1.Header = "TItle";
			listViewGroup1.Name = "Title";
			listViewGroup2.Header = "Artist";
			listViewGroup2.Name = "Artist";
			listViewGroup3.Header = "Category";
			listViewGroup3.Name = "Category";
			this.songsListView.Groups.AddRange( new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3 } );
			this.songsListView.Location = new Point( 3, 2 );
			this.songsListView.Margin = new Padding( 3, 2, 3, 2 );
			this.songsListView.Name = "songsListView";
			this.songsListView.Size = new Size( 545, 257 );
			this.songsListView.TabIndex = 1;
			this.songsListView.UseCompatibleStateImageBehavior = false;
			this.songsListView.View = View.Details;
			this.songsListView.SelectedIndexChanged += this.songsListView_SelIndexChanged;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 174;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Artist";
			this.columnHeader2.Width = 174;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Category";
			this.columnHeader3.Width = 174;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Duration";
			this.columnHeader4.Width = 174;
			// 
			// panel2
			// 
			this.panel2.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel2.Controls.Add( this.panel20 );
			this.panel2.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel2.Location = new Point( 394, 266 );
			this.panel2.Margin = new Padding( 3, 2, 3, 2 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size( 551, 66 );
			this.panel2.TabIndex = 1;
			// 
			// panel20
			// 
			this.panel20.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel20.Controls.Add( this.label1 );
			this.panel20.Controls.Add( this.panel8 );
			this.panel20.Controls.Add( this.playingSongLbl );
			this.panel20.Controls.Add( this.label2 );
			this.panel20.Controls.Add( this.volumeLbl );
			this.panel20.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel20.Location = new Point( 3, 3 );
			this.panel20.Margin = new Padding( 3, 2, 3, 2 );
			this.panel20.Name = "panel20";
			this.panel20.Size = new Size( 545, 60 );
			this.panel20.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.label1.FlatStyle = FlatStyle.Flat;
			this.label1.Font = new Font( "Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.label1.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.label1.Location = new Point( 347, 21 );
			this.label1.Name = "label1";
			this.label1.Size = new Size( 70, 18 );
			this.label1.TabIndex = 26;
			this.label1.Text = "Volume";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel8
			// 
			this.panel8.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel8.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel8.Location = new Point( 296, 6 );
			this.panel8.Margin = new Padding( 3, 2, 3, 2 );
			this.panel8.Name = "panel8";
			this.panel8.Size = new Size( 4, 47 );
			this.panel8.TabIndex = 66;
			// 
			// playingSongLbl
			// 
			this.playingSongLbl.BackColor = Color.FromArgb(     141,     153,     174 );
			this.playingSongLbl.BorderStyle = BorderStyle.None;
			this.playingSongLbl.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.playingSongLbl.ForeColor = Color.FromArgb(     237,     242,     244 );
			this.playingSongLbl.Location = new Point( 18, 20 );
			this.playingSongLbl.Margin = new Padding( 3, 2, 3, 2 );
			this.playingSongLbl.Name = "playingSongLbl";
			this.playingSongLbl.ReadOnly = true;
			this.playingSongLbl.Size = new Size( 263, 22 );
			this.playingSongLbl.TabIndex = 65;
			this.playingSongLbl.Text = "ArtistTitleCategory";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.label2.FlatStyle = FlatStyle.Flat;
			this.label2.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.label2.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.label2.Location = new Point( 474, 20 );
			this.label2.Name = "label2";
			this.label2.Size = new Size( 24, 22 );
			this.label2.TabIndex = 64;
			this.label2.Text = "%";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// volumeLbl
			// 
			this.volumeLbl.AutoSize = true;
			this.volumeLbl.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.volumeLbl.FlatStyle = FlatStyle.Flat;
			this.volumeLbl.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.volumeLbl.ForeColor = Color.FromArgb(     215,     43,     45,     66 );
			this.volumeLbl.Location = new Point( 430, 20 );
			this.volumeLbl.Name = "volumeLbl";
			this.volumeLbl.Size = new Size( 46, 22 );
			this.volumeLbl.TabIndex = 46;
			this.volumeLbl.Text = "100";
			this.volumeLbl.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel1.Controls.Add( this.panel9 );
			this.panel1.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel1.Location = new Point( 3, 2 );
			this.panel1.Margin = new Padding( 3, 2, 3, 2 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size( 388, 329 );
			this.panel1.TabIndex = 0;
			// 
			// panel9
			// 
			this.panel9.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel9.Controls.Add( this.panel10 );
			this.panel9.Controls.Add( this.nextSongBtn );
			this.panel9.Controls.Add( this.prevSongBtn );
			this.panel9.Controls.Add( this.pauseButton );
			this.panel9.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel9.Location = new Point( 3, 2 );
			this.panel9.Margin = new Padding( 3, 2, 3, 2 );
			this.panel9.Name = "panel9";
			this.panel9.Size = new Size( 383, 324 );
			this.panel9.TabIndex = 64;
			// 
			// panel10
			// 
			this.panel10.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.panel10.Controls.Add( this.panel11 );
			this.panel10.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel10.Location = new Point( 3, 2 );
			this.panel10.Margin = new Padding( 3, 2, 3, 2 );
			this.panel10.Name = "panel10";
			this.panel10.Size = new Size( 378, 257 );
			this.panel10.TabIndex = 17;
			// 
			// panel11
			// 
			this.panel11.BackColor = Color.FromArgb(     215,     141,     153,     174 );
			this.panel11.Controls.Add( this.mediaPlayer );
			this.panel11.ForeColor = Color.FromArgb(     215,     0,     0,     0 );
			this.panel11.Location = new Point( 3, 2 );
			this.panel11.Margin = new Padding( 3, 2, 3, 2 );
			this.panel11.Name = "panel11";
			this.panel11.Size = new Size( 373, 253 );
			this.panel11.TabIndex = 0;
			// 
			// mediaPlayer
			// 
			this.mediaPlayer.Enabled = true;
			this.mediaPlayer.Location = new Point( 0, 1 );
			this.mediaPlayer.Name = "mediaPlayer";
			this.mediaPlayer.OcxState = ( AxHost.State )resources.GetObject( "mediaPlayer.OcxState" );
			this.mediaPlayer.Size = new Size( 370, 249 );
			this.mediaPlayer.TabIndex = 0;
			// 
			// nextSongBtn
			// 
			this.nextSongBtn.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.nextSongBtn.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.nextSongBtn.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.nextSongBtn.Location = new Point( 279, 268 );
			this.nextSongBtn.Margin = new Padding( 3, 2, 3, 2 );
			this.nextSongBtn.Name = "nextSongBtn";
			this.nextSongBtn.Padding = new Padding( 4, 0, 0, 1 );
			this.nextSongBtn.Size = new Size( 74, 45 );
			this.nextSongBtn.TabIndex = 74;
			this.nextSongBtn.Text = ">>";
			this.nextSongBtn.UseVisualStyleBackColor = false;
			this.nextSongBtn.Click += this.nextSongBtn_Click;
			// 
			// prevSongBtn
			// 
			this.prevSongBtn.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.prevSongBtn.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.prevSongBtn.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.prevSongBtn.Location = new Point( 32, 268 );
			this.prevSongBtn.Margin = new Padding( 3, 2, 3, 2 );
			this.prevSongBtn.Name = "prevSongBtn";
			this.prevSongBtn.Padding = new Padding( 1, 0, 0, 1 );
			this.prevSongBtn.Size = new Size( 74, 45 );
			this.prevSongBtn.TabIndex = 73;
			this.prevSongBtn.Text = "<<";
			this.prevSongBtn.UseVisualStyleBackColor = false;
			this.prevSongBtn.Click += this.prevSongBtn_Click;
			// 
			// pauseButton
			// 
			this.pauseButton.BackColor = Color.FromArgb(     215,     43,     45,     66 );
			this.pauseButton.Font = new Font( "Lucida Bright", 16.2F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.pauseButton.ForeColor = Color.FromArgb(     215,     237,     242,     244 );
			this.pauseButton.Location = new Point( 130, 268 );
			this.pauseButton.Margin = new Padding( 3, 2, 3, 2 );
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Padding = new Padding( 8, 0, 0, 2 );
			this.pauseButton.Size = new Size( 127, 45 );
			this.pauseButton.TabIndex = 72;
			this.pauseButton.Text = "|>";
			this.pauseButton.UseVisualStyleBackColor = false;
			this.pauseButton.Click += this.pauseButton_Click;
			// 
			// Karaoke
			// 
			this.AutoScaleDimensions = new SizeF( 7F, 15F );
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.DarkSlateBlue;
			this.ClientSize = new Size( 964, 392 );
			this.Controls.Add( this.panel6 );
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Margin = new Padding( 3 );
			this.MaximizeBox = false;
			this.Name = "Karaoke";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosed += this.Karaoke_FormClosed;
			this.panel6.ResumeLayout( false );
			this.panel5.ResumeLayout( false );
			this.panel15.ResumeLayout( false );
			this.panel15.PerformLayout();
			this.panel7.ResumeLayout( false );
			this.panel4.ResumeLayout( false );
			this.panel3.ResumeLayout( false );
			this.panel2.ResumeLayout( false );
			this.panel20.ResumeLayout( false );
			this.panel20.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.panel9.ResumeLayout( false );
			this.panel10.ResumeLayout( false );
			this.panel11.ResumeLayout( false );
			(( System.ComponentModel.ISupportInitialize )this.mediaPlayer).EndInit();
			this.ResumeLayout( false );
		}

		#endregion
		private Panel panel6;
		private Panel panel7;
		private Panel panel4;
		private Panel panel3;
		private ListView songsListView;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private Panel panel2;
		private Panel panel20;
		private Panel panel1;
		private Panel panel9;
		private Button nextSongBtn;
		private Button prevSongBtn;
		private Button pauseButton;
		private Panel panel5;
		private Panel panel15;
		private Label label3;
		private LinkLabel SignUpLbl;
		private Label label2;
		private Label volumeLbl;
		private TextBox playingSongLbl;
		private Panel panel8;
		private Label label1;
		private Panel panel10;
		private Panel panel11;
		private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
	}
}
