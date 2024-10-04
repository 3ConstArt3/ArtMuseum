using System.Xml;

namespace Ergasia3.Source.Backend
{
	public sealed class SaveFile
	{
		private const string SaveFileName = "save.xml";
		private const string SaveFileRootNodeName = "config";
		private const string XMLReadError = "Corrupted save file";

		// all the save setting names
		public const string SN_volume = "volume";
		public const string SN_temp = "temperature";
		public const string SN_acState = "ac_state";
		public const string SN_palette = "palette";

		public static SortedDictionary<string, string> SavedItems { get; }

		private readonly static XmlDocument doc = new();
		private readonly static XmlNode rootNode;

		static SaveFile()
		{
			try
			{
				doc.Load( SaveFileName );
				rootNode = doc.SelectSingleNode( SaveFileRootNodeName );
				if( rootNode == null )
					throw new XmlException( $"{XMLReadError}: root node != {SaveFileRootNodeName}" );
			}
			catch (Exception)
			{
				rootNode = doc.CreateElement( SaveFileRootNodeName );
				doc.AppendChild( rootNode );
			}

			SavedItems = [];
			foreach( XmlNode child in rootNode.ChildNodes )
			{
				if( child.Attributes == null ||
					child.Attributes.Count != 1 ||
					child.Attributes[ "value" ] == null )
					throw new XmlException( $"{XMLReadError}: child has incorrect structure" );

				SavedItems.Add( child.Name, child.Attributes[ "value" ].Value );
			}
		}

		public static void SaveSetting( string key, string value )
		{
			// if the key already exists, update it
			if( SavedItems.ContainsKey( key ) )
				SavedItems[ key ] = value;
			else
				SavedItems.Add( key, value );
		}

		public static void PerformSave()
		{
			// we've made sure in the constructor that rootNode can't be null
			rootNode.RemoveAll();

			foreach( var kv in SavedItems )
			{
				XmlNode newNode = doc.CreateElement( kv.Key );
				XmlAttribute attr = doc.CreateAttribute( "value" );
				attr.Value = kv.Value;
				newNode.Attributes.Append( attr );
				rootNode.AppendChild( newNode );
			}
			doc.Save( SaveFileName );
		}
	}
}
