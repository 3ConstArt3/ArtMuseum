using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ergasia3.Source.Frontend.CinemaHall;
using Ergasia3.Source.Frontend.ConcertHall;
using Ergasia3.Source.Frontend.DJockeyHall;
using Ergasia3.Source.Frontend.ExhibitionHall;
using Ergasia3.Source.Backend;
using System.Xml;

namespace Ergasia3.Source.Frontend
{
	public partial class MenuTable : BaseForm
	{

		#region Constructor definition
		public MenuTable()
		{
			InitializeComponent();
		}
		#endregion

		#region Function definition
		private void NavigateBtn_Click( object sender, EventArgs e )
		{
			try
			{
				if( isHallSelected<CoffeeHall>( CinemaHallRbtn ) )
					return;
				if( isHallSelected<SignIn>( ConcertHallRbtn ) )
					return;
				if( isHallSelected<SelectionHall>( ExhibitionHallRbtn ) )
					return;
				if( isHallSelected<DJHall>( DJHallRbtn ) )
					return;
				if( isHallSelected<MainHall>( MainHallRbtn ) )
					return;
				if( isHallSelected<DeviceHall>( DeviceHallRbtn ) )
					return;

				var message = "Please select a hall to navigate through!";
				var boxIcon = MessageBoxIcon.Exclamation;
				AppMessage.showMessageBox( message, boxIcon );
			}
			catch( FileNotFoundException f )
			{
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( f.Message, boxIcon );
				this.Close();
			}
			catch( XmlException x )
			{
				var message = $"Xml Error: {x.Message}";
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( message, boxIcon );
				this.Close();
			}
			catch( Exception ex )
			{
				var message = ex.Message;
				var boxIcon = MessageBoxIcon.Warning;
				AppMessage.showMessageBox( message, boxIcon );
				this.Close();
			}
		}

		private void MenuTable_FormClosed( object sender, FormClosedEventArgs e )
		{
			Application.OpenForms[ 0 ]?.Show();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			//HelpFile.Show( HelpFile.MenuTable );
		}

		private bool isHallSelected<Type>( RadioButton radioButton ) where Type : Form, new()
		{
			if( radioButton.Checked )
			{
				new Type().Show();
				this.Hide();
				return true;
			}

			return false;
		}
		#endregion

	}
}