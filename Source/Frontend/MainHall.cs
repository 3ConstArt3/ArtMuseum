using Ergasia3.Source.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ergasia3.Source.Frontend
{
	public partial class MainHall : BaseForm
	{

		#region Constructor definition
		public MainHall()
		{
			InitializeComponent();
			saveRestoreGlobals();
		}
		#endregion

		#region Function definition
		private void LetGoBtn_Click( object sender, EventArgs e )
		{
			new MenuTable().Show();
			this.Hide();
		}

		private void MainHall_FormClosing( object sender, FormClosingEventArgs e )
		{
			SaveFile.PerformSave();
		}

		private void MainHall_Shown( object sender, EventArgs e )
		{
			Palette.ApplyColorMatrix( this, Globals.SelectedPaletteIndex );
		}

		private static void saveRestoreGlobals()
		{
			if( SaveFile.SavedItems.TryGetValue( SaveFile.SN_palette, out string? value ) )
				Globals.SelectedPaletteIndex = int.Parse( value );

			var avgSound = (DeviceHall.AudioBounds[ 1 ] - DeviceHall.AudioBounds[ 0 ]) / 2;
			if( SaveFile.SavedItems.TryGetValue( SaveFile.SN_volume, out value ) )
				Globals.Volume = int.Parse( value );
			else
				Globals.Volume = DeviceHall.AudioBounds[ 0 ] + (avgSound - 6 * DeviceHall.DeltaSound);

			if( SaveFile.SavedItems.TryGetValue( SaveFile.SN_temp, out value ) )
				Globals.Temperature = ( Globals._Temperature )float.Parse( value );

			if( SaveFile.SavedItems.TryGetValue( SaveFile.SN_acState, out value ) )
				Globals.IsAcOn = bool.Parse( value );
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			//HelpFile.Show( HelpFile.MainHall );
		}
		#endregion

	}
}
