using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Ergasia3.Source.Backend;

namespace Ergasia3.Source.Frontend.ExhibitionHall
{
	public partial class MatterHall : BaseForm
	{

		private const string XmlPath = "Data/Gallery.xml";
		private readonly List<InformationNode> informationList = [];
		private readonly HallCategory hallCategory;
		private int currentNode = 0;

		#region Constructor definition
		public MatterHall( HallCategory hallCategory )
		{
			InitializeComponent();

			this.hallCategory = hallCategory;
			this.initializeElements();
			this.KeyDown += keyPress;
		}
		#endregion

		#region Function definition
		private void initializeElements()
		{
			this.readGalleryFile();
			this.randomizeNode();
			this.refreshHallContent();
		}

		private void keyPress( object? sender, KeyEventArgs e )
		{
			if( sender == null )
				return;

			if( e.KeyCode == Keys.A || e.KeyCode == Keys.Left )
			{
				PreviousBtn_Click( sender, e );
			}
			else if( e.KeyCode == Keys.D || e.KeyCode == Keys.Right )
			{
				NextBtn_Click( sender, e );
			}
		}

		private void NextBtn_Click( object sender, EventArgs e )
		{
			var direction = 1;
			this.updateContent( direction );
		}

		private void PreviousBtn_Click( object sender, EventArgs e )
		{
			var direction = -1;
			this.updateContent( direction );
		}

		private void updateContent( int direction )
		{
			if( this.informationList.Count <= 0 )
				return;

			this.currentNode += direction + this.informationList.Count;
			this.currentNode %= this.informationList.Count;

			this.refreshHallContent();
		}

		private void randomizeNode()
		{
			var randomSeed = new Random().NextDouble();
			var randomNode = ( int )(randomSeed * this.informationList.Count);
			this.currentNode = randomNode;
		}

		private void refreshHallContent()
		{
			var imageUrl = this.informationList[ currentNode ].ImagePath;
			this.ImagePbx.Load( imageUrl );

			var information = this.informationList[ this.currentNode ].Information;
			this.InformationTxtbx.Text = information;
		}

		private void readGalleryFile()
		{
			XmlDocument document = new();
			document.Load( XmlPath );

			XmlNode? rootNode = document.SelectSingleNode( "gallery" );
			if( rootNode == null )
			{
				var message = $"Couldn't find root node!";
				throw new Exception( message );
			}

			var categoryNode = "";
			switch( this.hallCategory )
			{
				case HallCategory.Art:
					categoryNode = "art";
					break;
				case HallCategory.Music:
					categoryNode = "music";
					break;
				case HallCategory.Movies:
					categoryNode = "movies";
					break;
			}

			XmlNode? artContent = rootNode.SelectSingleNode( categoryNode );
			if( artContent == null )
			{
				var message = $"Couldn't find selection choice {categoryNode}";
				throw new Exception( message );
			}

			foreach( XmlNode node in artContent.ChildNodes )
			{
				XmlNode? imageNode = node.SelectSingleNode( "image" );
				XmlNode? informationNode = node.SelectSingleNode( "info" );

				if( imageNode == null || informationNode == null )
					continue;
				if( imageNode?.Attributes?[ "path" ] == null )
					continue;

				var imagePath = imageNode.Attributes[ "path" ]?.Value;
				var information = informationNode.InnerText.Replace( Environment.NewLine, " " );
				information = information.Replace( "\t", "" );

				this.informationList.Add( new InformationNode( imagePath, information ) );
			}
		}

		private void MatterHall_FormClosed( object sender, FormClosedEventArgs e )
		{
			new SelectionHall().Show();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ExhibitionHall );
		}
		#endregion


		private readonly struct InformationNode( string imagePath, string information )
		{
			internal readonly string ImagePath { get; } = imagePath;
			internal readonly string Information { get; } = information;
		}
	}
}