using Ergasia3.Source.Backend;
using System.Xml;

namespace Ergasia3.Source.Frontend.DJockeyHall
{
	public partial class Karaoke : BaseForm
	{
		private const string PlaySymbol = "|>";
		private const string PauseSymbol = "||";

		private readonly List<Video> videos = [];

		#region Constructor definition
		public Karaoke()
		{
			InitializeComponent();
			readSongsFromXML();

			foreach( Video s in videos )
			{
				ListViewItem newItem = songsListView.Items.Add( s.Name );
				newItem.SubItems.Add( s.Artist );
				newItem.SubItems.Add( s.Category );
				newItem.SubItems.Add( s.Duration );
			}
			volumeLbl.Text = $"{Globals.Volume}";
			pauseButton.Text = PlaySymbol;
			playingSongLbl.Text = string.Empty;
			mediaPlayer.uiMode = "none";
			mediaPlayer.settings.volume = Globals.Volume;
		}
		#endregion

		#region Function definition

		private void readSongsFromXML()
		{
			XmlDocument doc = new();
			doc.Load( "Data/KaraokeSongs.xml" );

			XmlNode? rootNode = doc.SelectSingleNode( "songs" );
			if( rootNode == null )
				throw new XmlException( "Root node != songs" );

			foreach( XmlNode song in rootNode.ChildNodes )
			{
				if( song.Attributes == null || song.Attributes.Count != 5 )
					throw new XmlException( "Incorrect amount of attributes for song!" );

				if( song.Attributes[ "title" ] == null ||
					song.Attributes[ "artist" ] == null ||
					song.Attributes[ "category" ] == null ||
					song.Attributes[ "duration" ] == null ||
					song.Attributes[ "videoPath" ] == null )
					throw new XmlException( "Incorrect attributes for song!" );

				videos.Add( new Video(
					song.Attributes[ "title" ].Value,
					song.Attributes[ "artist" ].Value,
					song.Attributes[ "category" ].Value,
					song.Attributes[ "duration" ].Value,
					song.Attributes[ "videoPath" ].Value
				) );
			}
		}

		private void Karaoke_FormClosed( object sender, FormClosedEventArgs e )
		{
			Application.OpenForms[ 1 ]?.Show();
		}

		private void songsListView_SelIndexChanged( object sender, EventArgs e )
		{
			if( songsListView.SelectedItems.Count == 0 )
				return;

			int index = songsListView.SelectedItems[ 0 ].Index;
			mediaPlayer.URL = videos[ index ].VideoPath;
			pauseButton.Text = PauseSymbol;
			playingSongLbl.Text = $"{videos[ index ].Artist} | {videos[ index ].Name} | {videos[ index ].Category}";
		}

		private void pauseButton_Click( object sender, EventArgs e )
		{
			if( pauseButton.Text.Equals( PauseSymbol ) )
			{
				pauseButton.Text = PlaySymbol;
				mediaPlayer.Ctlcontrols.pause();
			}
			else
			{
				pauseButton.Text = PauseSymbol;
				mediaPlayer.Ctlcontrols.play();
			}
		}

		private void prevSongBtn_Click( object sender, EventArgs e )
		{
			if( songsListView.Items.Count == 0 || songsListView.SelectedItems.Count == 0 )
				return;

			int curIndex = songsListView.SelectedItems[ 0 ].Index;
			songsListView.SelectedItems.Clear();
			if( curIndex > 0 )
				songsListView.Items[ curIndex - 1 ].Selected = true;
			else
				songsListView.Items[ songsListView.Items.Count - 1 ].Selected = true;
			songsListView.Select();
			updateVideo();
		}

		private void nextSongBtn_Click( object sender, EventArgs e )
		{
			if( songsListView.Items.Count == 0 || songsListView.SelectedItems.Count == 0 )
				return;

			int curIndex = songsListView.SelectedItems[ 0 ].Index;
			songsListView.SelectedItems.Clear();
			if( curIndex < songsListView.Items.Count - 1 )
				songsListView.Items[ curIndex + 1 ].Selected = true;
			else
				songsListView.Items[ 0 ].Selected = true;
			songsListView.Select();
			updateVideo();
		}

		private void updateVideo()
		{
			mediaPlayer.URL = videos[ songsListView.SelectedItems[0].Index ].VideoPath;
			mediaPlayer.Ctlcontrols.play();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.DJockeyHall );
		}
		#endregion

		private readonly struct Video( string name, string artist,
			string category, string duration, string musicpath )
		{
			public string Name { get; } = name;
			public string Artist { get; } = artist;
			public string Category { get; } = category;
			public string Duration { get; } = duration;
			public string VideoPath { get; } = musicpath;
		}
	}
}
