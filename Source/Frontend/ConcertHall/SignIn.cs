using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Ergasia3.Source.Backend;

namespace Ergasia3.Source.Frontend.ConcertHall
{
	public partial class SignIn : BaseForm
	{

		private readonly XmlDocument document = new();

		#region Constructor definition
		public SignIn()
		{
			InitializeComponent();
			this.document.Load( AccountBase.File );
		}
		#endregion

		#region Function definition
		private void LogIn_FormClosed( object sender, FormClosedEventArgs e )
		{
			Application.OpenForms[ 0 ]?.Show();
		}

		private void SignInBtn_Click( object sender, EventArgs e )
		{
			if( AccountBase.AreFieldsEmpty( this.UsernameEmailTxtbx.Text,
											this.PasswordTxtbx.Text ) )
			{
				var message = "All fields must have a value!";
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( message, boxIcon );

				return;
			}

			try
			{ this.checkUserData(); }
			catch( Exception ex )
			{
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( ex.Message, boxIcon );
			}
		}

		private void checkUserData()
		{
			XmlNode? rootNode = this.document.SelectSingleNode( AccountBase.RootNode );
			if( rootNode == null )
			{
				var message = "No users found!";
				throw new Exception( message );
			}

			AccountBase.User? user = AccountBase.FindUser( rootNode, this.UsernameEmailTxtbx.Text );
			if( user == null )
			{
				var message = "Invalid username or email!";
				throw new Exception( message );
			}

			var encryptedPassword = Encode.encryptPassword( this.PasswordTxtbx.Text );
			if( encryptedPassword.Equals( user.Value.Password ) )
			{
				var message = "Login successful!";
				var boxIcon = MessageBoxIcon.Information;
				AppMessage.showMessageBox( message, boxIcon );

				try
				{
					new Account( user.Value.Name ).Show();
					this.Hide();
				}
				catch( XmlException e )
				{
					AppMessage.showMessageBox( $"XML Error: {e.Message}", MessageBoxIcon.Error );
				}
				catch( Exception e )
				{
					AppMessage.showMessageBox( e.Message, MessageBoxIcon.Error );
				}
			}
			else
			{
				var message = "Wrong password inserted!";
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( message, boxIcon );
			}
		}

		private void SignUpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			new SignUp().Show();
			this.Hide();
		}

		private void PreviewPasswordChkBx_CheckedChanged( object sender, EventArgs e )
		{
			var password = this.PasswordTxtbx.Text;
			if( password.Equals( string.Empty ) )
				return;

			this.PasswordTxtbx.PasswordChar = this.PreviewPasswordChkBx.Checked ? '\0' : '*';
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ConcertHall );
		}
		#endregion

	}
}