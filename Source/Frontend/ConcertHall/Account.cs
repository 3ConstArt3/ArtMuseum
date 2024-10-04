global using Presentations = Ergasia3.Source.Backend.ConcertHallXMLs.Presentation[];
global using Tickets = System.Collections.Generic.List<Ergasia3.Source.Backend.ConcertHallXMLs.Ticket>;

using Ergasia3.Source.Backend;
using static Ergasia3.Source.Backend.ConcertHallUtils;
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

namespace Ergasia3.Source.Frontend.ConcertHall
{
	public partial class Account : BaseForm
	{
		// the first two are stored here for easy access
		private readonly Control[] moviePanels = new Control[ TotalMoviePresentations ];
		private readonly Control[] movieBackPanels = new Control[ TotalMoviePresentations ];
		private readonly Point[] moviePanelsOffsets = new Point[ TotalMoviePresentations ];
		// the panel that the cursor is on at the current moment
		private HoveredMoviePanel hoveredMoviePanel = HoveredMoviePanel.None;

		private readonly Control[] cinemaSeats = new Control[ TotalSeats ];
		private readonly Presentations presentations;
		private readonly Tickets tickets;
		private readonly uint[] tickets_reserved_per_movie = new uint[ TotalMoviePresentations ];

		private readonly string username;

		#region Constructor definition
		public Account( string username )
		{
			InitializeComponent();
			this.username = username;

			cinemaReservedPnl.BackColor = ConcertHallUtils.ReservedSeatColor;
			moviePanels = [ moviePnl1, moviePnl2, moviePnl3 ];
			movieBackPanels = [ movieBackPnl1, movieBackPnl2, movieBackPnl3 ];
			moviePanelsOffsets = [
				CalcRelativeOffsetForControl( moviePnl1 ),
				CalcRelativeOffsetForControl( moviePnl2 ),
				CalcRelativeOffsetForControl( moviePnl3 )
			];
			cinemaSeats = ConcertHallUtils.GetCinemaSeats( panel51 );

			// all the exceptions that can happen below will be caught by the SignIn form, and
			// the Account form will not show up (because the provided information will be
			// incorrect)
			presentations = ConcertHallXMLs.GetPresentations();
			tickets = ConcertHallXMLs.GetTickets();

			// the seat count for all 3 panels is updated after the foreach loop
			movieTitle1.Text = presentations[ 0 ].Title;
			movieDate1.Text = presentations[ 0 ].Date;
			movieTime1.Text = presentations[ 0 ].Time;

			movieTitle2.Text = presentations[ 1 ].Title;
			movieDate2.Text = presentations[ 1 ].Date;
			movieTime2.Text = presentations[ 1 ].Time;

			movieTitle3.Text = presentations[ 2 ].Title;
			movieDate3.Text = presentations[ 2 ].Date;
			movieTime3.Text = presentations[ 2 ].Time;

			Array.Clear( tickets_reserved_per_movie, 0, tickets_reserved_per_movie.Length );
			foreach( var ticket in tickets )
			{
				if( ticket.Presentation_ID > TotalMoviePresentations )
					throw new ArgumentException( $"""
												Invalid seat count 
												({ticket.Presentation_ID}) for ticket!"
												"""
					);
				tickets_reserved_per_movie[ ticket.Presentation_ID ] += ticket.Seats;
				// possible TODO: perhaps make this movie panel greyed out when there are
				// no more tickets available?
				if( tickets_reserved_per_movie[ ticket.Presentation_ID ] > TotalSeats )
					throw new Exception( $"""
										Total seats exceeded for 
										movie #{ticket.Presentation_ID}!
										"""
					);
			}
			movieSeats1.Text = (TotalSeats - tickets_reserved_per_movie[ 0 ]).ToString();
			movieSeats2.Text = (TotalSeats - tickets_reserved_per_movie[ 1 ]).ToString();
			movieSeats3.Text = (TotalSeats - tickets_reserved_per_movie[ 2 ]).ToString();

			// the timer tick was being executed even before this constructor finishes, which
			// is a problem in case of an exception, so it should only be enabled after
			// everything's good here
			timer.Enabled = true;
		}
		#endregion

		#region Function definition
		private void Account_FormClosed( object sender, FormClosedEventArgs e )
		{
			new SignIn().Show();
		}

		private void timer_Tick( object sender, EventArgs e )
		{
			for( int i = 0; i < moviePanels.Length; i++ )
			{
				lightUpHoveredMoviePanel( i, moviePanelsOffsets[ i ] );
			}
			lightUpCinemaSeats();

			switch( hoveredMoviePanel )
			{
				case HoveredMoviePanel.None:
					ticketsNumberLbl.Text = string.Empty;
					break;
				case HoveredMoviePanel.Panel1:
					ticketsNumberLbl.Text = (TotalSeats - tickets_reserved_per_movie[ 0 ]).ToString();
					break;
				case HoveredMoviePanel.Panel2:
					ticketsNumberLbl.Text = (TotalSeats - tickets_reserved_per_movie[ 1 ]).ToString();
					break;
				case HoveredMoviePanel.Panel3:
					ticketsNumberLbl.Text = (TotalSeats - tickets_reserved_per_movie[ 2 ]).ToString();
					break;

			}
		}

		private void lightUpHoveredMoviePanel( int index, Point pnlOffset )
		{
			if( isCursorInControl( moviePanels[ index ], pnlOffset ) )
			{
				movieBackPanels[ index ].BackColor = Color.White;
				hoveredMoviePanel = ( HoveredMoviePanel )index;
			}
			else
			{
				movieBackPanels[ index ].BackColor =
					Palette.ColorMap[ Globals.SelectedPaletteIndex ].Color1;
				if( ( HoveredMoviePanel )index == hoveredMoviePanel )
					hoveredMoviePanel = HoveredMoviePanel.None;
			}
		}

		private void lightUpCinemaSeats()
		{
			int index = ( int )hoveredMoviePanel;
			if( hoveredMoviePanel == HoveredMoviePanel.None )
			{
				foreach( Control seat in cinemaSeats )
					seat.BackColor = Color.White;
				return;
			}

			for( uint i = 0; i < tickets_reserved_per_movie[ index ]; i++ )
				cinemaSeats[ i ].BackColor = ConcertHallUtils.ReservedSeatColor;
			for( uint i = tickets_reserved_per_movie[ index ]; i < TotalSeats; i++ )
				cinemaSeats[ i ].BackColor = Color.White;
		}

		// calculate the offset for a control relative to the form.
		// ex: the Control c is X pixels right and Y pixels down from
		// the top left corner of the form.
		// this method will return (0, 0) if c is already a parent of the
		// main form and not some panel (in which case just use c.Location)
		private static Point CalcRelativeOffsetForControl( Control c )
		{
			int x = 0, y = 0;
			while( c.Parent != null )
			{
				x += c.Location.X;
				y += c.Location.Y;
				c = c.Parent;
			}
			return new Point( x, y );
		}

		private bool isCursorInControl( Control pnl, Point pnlOffset )
		{
			Point cursorpos = PointToClient( Cursor.Position );
			if( cursorpos.X >= pnlOffset.X && cursorpos.X < pnlOffset.X + pnl.Width &&
				cursorpos.Y >= pnlOffset.Y && cursorpos.Y < pnlOffset.Y + pnl.Height )
				return true;
			return false;
		}

		private void bookNowButton_Click( object sender, EventArgs e )
		{
			new BookingHall( presentations, tickets, tickets_reserved_per_movie, username ).Show();
		}

		private void signOutButton_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ConcertHall );
		}
		#endregion

	}
}
