using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Ergasia3.Source.Backend;
using Ergasia3.Source.Frontend.CinemaHall;
using Ergasia3.Source.Frontend.ConcertHall;
using Ergasia3.Source.Frontend.DJockeyHall;

namespace Ergasia3.Source.Frontend.ExhibitionHall
{

	public partial class SelectionHall : BaseForm
	{
		private readonly List<string> imagePaths = [];

		#region Constructor definition
		public SelectionHall()
		{
			InitializeComponent();
			readGeneralXML();
		}
		#endregion

		#region Function definition
		private void readGeneralXML()
		{
			XmlDocument doc = new();
			doc.Load( "Data/General.xml" );

			XmlNode rootNode = doc.SelectSingleNode( "general" );
			if( rootNode == null )
				throw new XmlException( "root node != general" );

			for( int i = 0; i < rootNode.ChildNodes.Count; i++ )
			{
				XmlNode node = rootNode.ChildNodes[ i ];
				if( node.Attributes == null ||
					node.Attributes.Count != 1 ||
					node.Attributes[ "path" ] == null )
					throw new XmlException( "invalid child structure" );

				imagePaths.Add( node.Attributes[ "path" ].Value );
			}
			if( imagePaths.Count < 3 )
				throw new Exception( "Incorrect amount of image paths in gallery.xml" );
		}

		private void HallSelection_FormClosed( object sender, FormClosedEventArgs e )
		{
			Application.OpenForms[ 1 ]?.Show();
		}

		private void PreviewBtn_Click( object sender, EventArgs e )
		{
			if( this.isHallSelected( this.ArtRbtn, HallCategory.Art ) ) return;
			if( this.isHallSelected( this.MusicRbtn, HallCategory.Music ) ) return;
			if( this.isHallSelected( this.MoviesRbtn, HallCategory.Movies ) ) return;

			var message = "Please select a hall to preview!";
			var boxIcon = MessageBoxIcon.Exclamation;
			AppMessage.showMessageBox( message, boxIcon );
		}

		private bool isHallSelected( RadioButton radioButton, HallCategory hallCategory )
		{
			if( radioButton.Checked )
			{
				new MatterHall( hallCategory ).Show();
				this.Hide();
				return true;
			}

			return false;
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ExhibitionHall );
		}
		#endregion

		private void RadioButtons_CheckedChanged( object sender, EventArgs e )
		{
			RadioButton btn = ( RadioButton )sender;
			if(btn.Name.Contains("Art"))
			{
				LogoPB.Load( imagePaths[ 0 ] );
			}
			else if(btn.Name.Contains("Music"))
			{
				LogoPB.Load( imagePaths[ 1 ] );
			}
			else if(btn.Name.Contains("Movies"))
			{
				LogoPB.Load( imagePaths[ 2 ] );
			}
		}
	}

	public enum HallCategory
	{
		Art,
		Music,
		Movies
	}
}