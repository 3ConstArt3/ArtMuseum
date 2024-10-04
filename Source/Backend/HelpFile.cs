using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ergasia3.Source.Backend
{
	public class HelpFile
	{
		// these must be synhronized with the help file inside the
		// Manuals folder
		public const string ExhibitionHall = "10";
		public const string ProjectionHall = "20";
		public const string ConcertHall = "30";
		public const string DJockeyHall = "40";
		public const string DeviceHall = "50";
		public const string HowToBookTicket = "60";
		public const string HowToBuyFood = "70";
		public const string HowToPreviewArt = "80";
		public const string HowToPlaySong = "90";
		public const string HowToChangeColors = "100";
		public const string HowToChangeTemp = "110";

		public static void Show(string ID)
		{
			Help.ShowHelp( null, "Manuals/HelpFile.chm",
				HelpNavigator.TopicId, ID );
		}
	}
}
