namespace Ergasia3.Source.Frontend.ConcertHall
{
	partial class SignIn
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
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.label3 = new Label();
			this.PreviewPasswordChkBx = new CheckBox();
			this.label2 = new Label();
			this.SignUpLbl = new LinkLabel();
			this.PasswordTxtbx = new TextBox();
			this.UsernameEmailTxtbx = new TextBox();
			this.SignInBtn = new Button();
			this.panel4 = new Panel();
			this.panel5 = new Panel();
			this.helpLbl = new LinkLabel();
			this.label1 = new Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = Color.MediumSlateBlue;
			this.panel1.Controls.Add( this.panel2 );
			this.panel1.Controls.Add( this.panel4 );
			this.panel1.ForeColor = SystemColors.ControlText;
			this.panel1.Location = new Point( 2, 3 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size( 451, 563 );
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = Color.DarkSlateBlue;
			this.panel2.Controls.Add( this.panel3 );
			this.panel2.ForeColor = SystemColors.ControlText;
			this.panel2.Location = new Point( 3, 61 );
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size( 446, 499 );
			this.panel2.TabIndex = 29;
			// 
			// panel3
			// 
			this.panel3.BackColor = Color.MediumSlateBlue;
			this.panel3.Controls.Add( this.label3 );
			this.panel3.Controls.Add( this.PreviewPasswordChkBx );
			this.panel3.Controls.Add( this.label2 );
			this.panel3.Controls.Add( this.SignUpLbl );
			this.panel3.Controls.Add( this.PasswordTxtbx );
			this.panel3.Controls.Add( this.UsernameEmailTxtbx );
			this.panel3.Controls.Add( this.SignInBtn );
			this.panel3.ForeColor = SystemColors.ControlText;
			this.panel3.Location = new Point( 3, 3 );
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size( 440, 493 );
			this.panel3.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = Color.MediumSlateBlue;
			this.label3.Font = new Font( "Lucida Bright", 9F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.label3.ForeColor = Color.DarkSlateBlue;
			this.label3.Location = new Point( 85, 235 );
			this.label3.Name = "label3";
			this.label3.Size = new Size( 150, 17 );
			this.label3.TabIndex = 35;
			this.label3.Text = "Preview password";
			// 
			// PreviewPasswordChkBx
			// 
			this.PreviewPasswordChkBx.AutoSize = true;
			this.PreviewPasswordChkBx.Font = new Font( "Lucida Bright", 9F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.PreviewPasswordChkBx.ForeColor = Color.DarkSlateBlue;
			this.PreviewPasswordChkBx.Location = new Point( 65, 235 );
			this.PreviewPasswordChkBx.Name = "PreviewPasswordChkBx";
			this.PreviewPasswordChkBx.Size = new Size( 18, 17 );
			this.PreviewPasswordChkBx.TabIndex = 34;
			this.PreviewPasswordChkBx.UseVisualStyleBackColor = true;
			this.PreviewPasswordChkBx.CheckedChanged += this.PreviewPasswordChkBx_CheckedChanged;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = Color.MediumSlateBlue;
			this.label2.Font = new Font( "Lucida Bright", 9F,   FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point,   0 );
			this.label2.ForeColor = Color.DarkSlateBlue;
			this.label2.Location = new Point( 85, 400 );
			this.label2.Name = "label2";
			this.label2.Size = new Size( 183, 18 );
			this.label2.TabIndex = 32;
			this.label2.Text = "Don't have an account?";
			// 
			// SignUpLbl
			// 
			this.SignUpLbl.ActiveLinkColor = Color.Snow;
			this.SignUpLbl.AutoSize = true;
			this.SignUpLbl.BackColor = Color.MediumSlateBlue;
			this.SignUpLbl.Font = new Font( "Lucida Bright", 10.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.SignUpLbl.ForeColor = SystemColors.ControlText;
			this.SignUpLbl.LinkColor = Color.Snow;
			this.SignUpLbl.Location = new Point( 273, 397 );
			this.SignUpLbl.Name = "SignUpLbl";
			this.SignUpLbl.Size = new Size( 77, 20 );
			this.SignUpLbl.TabIndex = 1;
			this.SignUpLbl.TabStop = true;
			this.SignUpLbl.Text = "Sign up";
			this.SignUpLbl.VisitedLinkColor = Color.Snow;
			this.SignUpLbl.LinkClicked += this.SignUpLbl_LinkClicked;
			// 
			// PasswordTxtbx
			// 
			this.PasswordTxtbx.BackColor = Color.Snow;
			this.PasswordTxtbx.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Regular, GraphicsUnit.Point,   0 );
			this.PasswordTxtbx.ForeColor = Color.DarkSlateBlue;
			this.PasswordTxtbx.Location = new Point( 67, 181 );
			this.PasswordTxtbx.MaxLength = 32;
			this.PasswordTxtbx.Name = "PasswordTxtbx";
			this.PasswordTxtbx.PasswordChar = '*';
			this.PasswordTxtbx.PlaceholderText = "Password";
			this.PasswordTxtbx.Size = new Size( 300, 35 );
			this.PasswordTxtbx.TabIndex = 31;
			// 
			// UsernameEmailTxtbx
			// 
			this.UsernameEmailTxtbx.BackColor = Color.Snow;
			this.UsernameEmailTxtbx.Font = new Font( "Lucida Bright", 13.8F, FontStyle.Regular, GraphicsUnit.Point,   0 );
			this.UsernameEmailTxtbx.ForeColor = Color.DarkSlateBlue;
			this.UsernameEmailTxtbx.Location = new Point( 67, 69 );
			this.UsernameEmailTxtbx.MaxLength = 32;
			this.UsernameEmailTxtbx.Name = "UsernameEmailTxtbx";
			this.UsernameEmailTxtbx.PlaceholderText = "Username or Email";
			this.UsernameEmailTxtbx.Size = new Size( 300, 35 );
			this.UsernameEmailTxtbx.TabIndex = 30;
			// 
			// SignInBtn
			// 
			this.SignInBtn.BackColor = Color.DarkSlateBlue;
			this.SignInBtn.Font = new Font( "Lucida Calligraphy", 13.8F, FontStyle.Bold, GraphicsUnit.Point,   0 );
			this.SignInBtn.ForeColor = Color.Snow;
			this.SignInBtn.Location = new Point( 65, 297 );
			this.SignInBtn.Name = "SignInBtn";
			this.SignInBtn.Size = new Size( 302, 67 );
			this.SignInBtn.TabIndex = 29;
			this.SignInBtn.Text = "Sign in";
			this.SignInBtn.UseVisualStyleBackColor = false;
			this.SignInBtn.Click += this.SignInBtn_Click;
			// 
			// panel4
			// 
			this.panel4.BackColor = Color.DarkSlateBlue;
			this.panel4.Controls.Add( this.panel5 );
			this.panel4.ForeColor = SystemColors.ControlText;
			this.panel4.Location = new Point( 3, 3 );
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size( 446, 56 );
			this.panel4.TabIndex = 2;
			// 
			// panel5
			// 
			this.panel5.BackColor = Color.MediumSlateBlue;
			this.panel5.Controls.Add( this.helpLbl );
			this.panel5.Controls.Add( this.label1 );
			this.panel5.ForeColor = SystemColors.ControlText;
			this.panel5.Location = new Point( 3, 3 );
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size( 440, 51 );
			this.panel5.TabIndex = 0;
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
			this.label1.Location = new Point( 152, 3 );
			this.label1.Name = "label1";
			this.label1.Size = new Size( 141, 42 );
			this.label1.TabIndex = 22;
			this.label1.Text = "Sign in";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// SignIn
			// 
			this.AutoScaleDimensions = new SizeF( 8F, 20F );
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.DarkSlateBlue;
			this.ClientSize = new Size( 456, 569 );
			this.Controls.Add( this.panel1 );
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Margin = new Padding( 3, 4, 3, 4 );
			this.Name = "SignIn";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosed += this.LogIn_FormClosed;
			this.panel1.ResumeLayout( false );
			this.panel2.ResumeLayout( false );
			this.panel3.ResumeLayout( false );
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout( false );
			this.panel5.ResumeLayout( false );
			this.panel5.PerformLayout();
			this.ResumeLayout( false );
		}

		#endregion

		private Panel panel1;
		private Panel panel4;
		private Panel panel5;
		private Label label1;
		private Panel panel2;
		private Panel panel3;
		private Label label2;
		private LinkLabel SignUpLbl;
		private TextBox PasswordTxtbx;
		private TextBox UsernameEmailTxtbx;
		private Button SignInBtn;
		private CheckBox PreviewPasswordChkBx;
		private LinkLabel helpLbl;
		private Label label3;
	}
}