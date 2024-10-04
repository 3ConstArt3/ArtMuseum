using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Ergasia3.Source.Backend
{
	public static class ConcertHallUtils
	{
		public const uint TotalSeats = 36;
		public const uint TotalMoviePresentations = 3;
		public static readonly Color ReservedSeatColor = Color.Red;
		public static readonly Color AvailableSeatColor = Color.Green;

		// get all the cinema seat controls inside parentCtrl and return a sorted
		// list of the panels so they can be easily accessed through a Control[] array
		public static Control[] GetCinemaSeats(Control parentCtrl)
		{
			// weird trick to convert all the controls to a list
			var cinema_controls = parentCtrl.Controls.Cast<Control>().ToList();
			// make cinema_controls contain only the panels that represent cinema
			// seats (which have their names start with 'cinemaPnl')
			cinema_controls.RemoveAll(x => !x.Name.StartsWith("cinemaPnl"));
			// sanity check
			if (cinema_controls.Count != TotalSeats)
				throw new Exception("Invalid amount of cinema panels!");
			// order it based on the control names, so [cinemaPnl04, cinemaPnl05, cinemaPnl03]
			// will become [cinemaPnl03, cinemaPnl04, cinemaPnl05]
			return cinema_controls.OrderBy(x => x.Name).ToArray();
		}

		public enum HoveredMoviePanel
		{
			None = -1,
			Panel1,
			Panel2,
			Panel3,
			max_moviepanels
		}
	}

	// a class that reads ConcertHall.xml and tickets.xml, and returns
	// the information from them to a List or Array for easy access
	public static class ConcertHallXMLs
	{
		private const string TicketsXml = "tickets.xml";
		private const string TicketsRootNode = "tickets";
		private const string TicketNode = "ticket";

		private const string TicketUsernameNode = "username";
		private const string TicketPresentationIDNode = "presentation_id";
		private const string TicketSeatsNode = "seats";

		#region ConcertHall.xml parsing
		public static Presentation[] GetPresentations()
		{
			XmlDocument doc = new();
			doc.Load("Data/ConcertHall.xml");

			XmlNode? rootNode = doc.FirstChild;
			if (rootNode == null || !rootNode.Name.Equals("concert_hall"))
				throw new XmlException("Root Node != concert_hall!");
			XmlNode? presentationsNode = rootNode.SelectSingleNode("presentations");
			if (presentationsNode == null || presentationsNode.ChildNodes.Count == 0)
				throw new XmlException("Presentations node is null or empty!");
			if (presentationsNode.ChildNodes.Count != 3)
				throw new XmlException("Movie node count != 3!");

			return readMovieNodes(presentationsNode.ChildNodes);
		}

		private static Presentation[] readMovieNodes(XmlNodeList nodes)
		{
			Presentation[] resultArray = new Presentation[3];
			for (int i = 0; i < nodes.Count; i++)
			{
				if (!nodes[i].Name.Equals("movie") || nodes[i].Attributes == null
					|| nodes[i].Attributes["id"] == null)
					throw new XmlException("Invalid movie node!");

				uint id = uint.Parse(nodes[i].Attributes["id"].Value); // this can throw
				resultArray[i] = parseMovieNode(nodes[i], id);
			}
			return resultArray;
		}

		private static Presentation parseMovieNode(XmlNode node, uint id)
		{
			if (node.ChildNodes.Count != 4)
				throw new XmlException("Movie node attribute count != 4!");

			string title = string.Empty;
			string imagePath = string.Empty;
			string date = string.Empty;
			string time = string.Empty;
			foreach (XmlNode innode in node.ChildNodes)
			{
				switch (innode.Name)
				{
					case "title":
						title = innode.InnerText;
						break;
					case "image":
						imagePath = innode.InnerText;
						break;
					case "date":
						date = innode.InnerText;
						break;
					case "time":
						time = innode.InnerText;
						break;
					default:
						throw new XmlException($"Unknown attribute: {innode.Value}");
				}
			}
			return new Presentation(id, title, imagePath, date, time);
		}
		#endregion

		#region tickets.xml parsing
		public static Tickets GetTickets()
		{
			XmlDocument doc = new();
			try
			{
				doc.Load(TicketsXml);
			}
			catch (FileNotFoundException)
			{
				return [];
			}

			XmlNode? rootNode = doc.FirstChild;
			if (rootNode == null || !rootNode.Name.Equals(TicketsRootNode))
				throw new XmlException("Root Node != tickets!");
			if (rootNode.ChildNodes.Count == 0)
				return []; // return an empty list

			return readTicketNodes(rootNode.ChildNodes);
		}

		private static Tickets readTicketNodes(XmlNodeList nodes)
		{
			Tickets resultList = [];
			foreach (XmlNode node in nodes)
			{
				if (!node.Name.Equals(TicketNode) || node.Attributes == null)
					throw new XmlException("Invalid ticket node!");

				resultList.Add(parseTicketNode(node));
			}
			return resultList;
		}

		private static Ticket parseTicketNode(XmlNode node)
		{
			if (node.ChildNodes.Count != 3)
				throw new XmlException("Ticket node attribute count != 3!");

			string username = string.Empty;
			uint presentation_id = 0;
			uint seats = 0;
			foreach (XmlNode innode in node.ChildNodes)
			{
				switch (innode.Name)
				{
					case TicketUsernameNode:
						username = innode.InnerText;
						break;
					case TicketPresentationIDNode:
						presentation_id = uint.Parse(innode.InnerText);
						break;
					case TicketSeatsNode:
						seats = uint.Parse(innode.InnerText);
						break;
					default:
						throw new XmlException($"Unknown attribute: {innode.Name}");
				}
			}
			return new Ticket(username, presentation_id, seats);
		}
		#endregion

		#region tickets.xml saving

		public static void SaveTickets(Tickets tickets)
		{
			XmlDocument doc = new();
			XmlElement rootNode = doc.CreateElement(TicketsRootNode);

			foreach (Ticket ticket in tickets)
			{
				XmlElement elem = createTicketElement(doc, ticket);
				rootNode.AppendChild(elem);
			}
			doc.AppendChild(rootNode);
			doc.Save(TicketsXml);
		}

		private static XmlElement createTicketElement(XmlDocument doc, Ticket t)
		{
			XmlElement ticketElem = doc.CreateElement(TicketNode);

			XmlElement usernameElem = doc.CreateElement(TicketUsernameNode);
			usernameElem.InnerText = t.Username;
			XmlElement presentationElem = doc.CreateElement(TicketPresentationIDNode);
			presentationElem.InnerText = t.Presentation_ID.ToString();
			XmlElement seatsElem = doc.CreateElement(TicketSeatsNode);
			seatsElem.InnerText = t.Seats.ToString();

			ticketElem.AppendChild(usernameElem);
			ticketElem.AppendChild(presentationElem);
			ticketElem.AppendChild(seatsElem);

			return ticketElem;
		}

		#endregion

		#region Structs
		public readonly struct Presentation(uint id, string title,
			string imagePath, string date, string time)
		{
			public uint Id { get; } = id;
			public string Title { get; } = title;
			public string ImagePath { get; } = imagePath;
			public string Date { get; } = date;
			public string Time { get; } = time;
		}

		public readonly struct Ticket(string username, uint presentation_id, uint seats)
		{
			public string Username { get; } = username;
			public uint Presentation_ID { get; } = presentation_id;
			public uint Seats { get; } = seats;
		}
		#endregion
	}
}
