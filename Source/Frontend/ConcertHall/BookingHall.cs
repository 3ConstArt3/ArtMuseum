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

namespace Ergasia3.Source.Frontend.ConcertHall
{
	public partial class BookingHall : BaseForm
	{
		private const uint MaxTicketReservations = 6;
		private const float SeatCost = 3.14f;

		private readonly Presentations presentations;
		private readonly Tickets tickets;
		private readonly string username;
		private readonly Control[] cinemaSeats;
		private ConcertHallUtils.HoveredMoviePanel selectedPanel =
			ConcertHallUtils.HoveredMoviePanel.None;
		private readonly uint[] tickets_reserved_per_movie =
			new uint[ ConcertHallUtils.TotalMoviePresentations ];

		private uint seat_reservations = 2;

		#region Constructor
		public BookingHall( Presentations p, Tickets t, uint[] tickets_reserved, string username )
		{
			InitializeComponent();
			this.username = username;
			presentations = p;
			tickets = t;
			tickets_reserved_per_movie = tickets_reserved;
			cinemaSeats = ConcertHallUtils.GetCinemaSeats( panel51 );

			cinemaReservedPnl.BackColor = ConcertHallUtils.ReservedSeatColor;
			cinemaAvailablePnl.BackColor = Color.White;

			moviePB1.Load( presentations[ 0 ].ImagePath );
			movieDate1.Text = presentations[ 0 ].Date;
			movieTime1.Text = presentations[ 0 ].Time;
			movieRadioBtn1.Text = presentations[ 0 ].Title;

			moviePB2.Load( presentations[ 1 ].ImagePath );
			movieDate2.Text = presentations[ 1 ].Date;
			movieTime2.Text = presentations[ 1 ].Time;
			movieRadioBtn2.Text = presentations[ 1 ].Title;

			moviePB3.Load( presentations[ 2 ].ImagePath );
			movieDate3.Text = presentations[ 2 ].Date;
			movieTime3.Text = presentations[ 2 ].Time;
			movieRadioBtn3.Text = presentations[ 2 ].Title;

			updateSeatAndPriceInfo();
		}
		#endregion

		#region Methods
		private void updateSeatAndPriceInfo()
		{
			seatsLbl.Text = $"{seat_reservations}";
			float cost = SeatCost * seat_reservations;
			costTextLbl.Text = $"{cost:f2}";

			// if the cost exceeds the wallet's amount of money, make the price red
			if( cost > float.Parse( walletTextLbl.Text ) )
				costTextLbl.ForeColor = Color.Red;
			else
				costTextLbl.ForeColor = Palette.ColorMap[ Globals.SelectedPaletteIndex ].Color1;

			if( selectedPanel == ConcertHallUtils.HoveredMoviePanel.None )
				return;

			uint index = ( uint )selectedPanel;
			uint whitePanelsIndex = tickets_reserved_per_movie[ index ] + seat_reservations;
			// change the color of the seat panels (1st loop for reserved seats, 2nd for the
			// ones to be reserved, 3rd for the other available ones)
			for( uint i = 0; i < tickets_reserved_per_movie[ index ]; i++ )
				cinemaSeats[ i ].BackColor = ConcertHallUtils.ReservedSeatColor;
			for( uint i = tickets_reserved_per_movie[ index ]; i < whitePanelsIndex; i++ )
				cinemaSeats[ i ].BackColor = ConcertHallUtils.AvailableSeatColor;
			for( uint i = whitePanelsIndex; i < ConcertHallUtils.TotalSeats; i++ )
				cinemaSeats[ i ].BackColor = Color.White;
		}

		private void ACDecrementBtn_Click( object sender, EventArgs e )
		{
			if( seat_reservations > 1 )
			{
				--seat_reservations;
				updateSeatAndPriceInfo();
			}
		}

		private void ACIncrementBtn_Click( object sender, EventArgs e )
		{
			if( seat_reservations < MaxTicketReservations )
			{
				++seat_reservations;
				updateSeatAndPriceInfo();
			}
		}

		private void bookButton_Click( object sender, EventArgs e )
		{
			if( SeatCost * seat_reservations > float.Parse( walletTextLbl.Text ) )
			{
				AppMessage.showMessageBox(
					"You have insufficient funds to complete this operation!",
					MessageBoxIcon.Warning
				);
			}
			else
			{
				uint selectedMovieIndex = 0;
				if( movieRadioBtn2.Checked )
					selectedMovieIndex = 1;
				else if( movieRadioBtn3.Checked )
					selectedMovieIndex = 2;

				// try and find a ticket that this user bought for the same movie
				ConcertHallXMLs.Ticket userTicket = tickets.Find(
					t => t.Username.Equals( username ) && t.Presentation_ID == selectedMovieIndex
				);
				// if the user has already bought a ticket for this movie, show a message and exit
				// (we check for the Username being null since a struct cannot be null as a whole)
				if( userTicket.Username != null )
				{
					AppMessage.showMessageBox(
						"You have already bought a ticket for this movie!",
						MessageBoxIcon.Warning
					);
					return;
				}

				tickets.Add( new ConcertHallXMLs.Ticket( username, selectedMovieIndex, seat_reservations ) );
				ConcertHallXMLs.SaveTickets( tickets );
				AppMessage.showMessageBox( "Reservation successful!", MessageBoxIcon.Information );

				// close all the forms between the main hall and the booking hall
				while( Application.OpenForms.Count > 1 )
				{
					Application.OpenForms[ 1 ].Close();
				}
				Close();
			}
		}

		private void movieRadioBtn1_CheckedChanged( object sender, EventArgs e )
		{
			if( movieRadioBtn1.Checked )
				selectedPanel = ConcertHallUtils.HoveredMoviePanel.Panel1;
			updateSeatAndPriceInfo();
		}

		private void movieRadioBtn2_CheckedChanged( object sender, EventArgs e )
		{
			if( movieRadioBtn2.Checked )
				selectedPanel = ConcertHallUtils.HoveredMoviePanel.Panel2;
			updateSeatAndPriceInfo();
		}

		private void movieRadioBtn3_CheckedChanged( object sender, EventArgs e )
		{
			if( movieRadioBtn3.Checked )
				selectedPanel = ConcertHallUtils.HoveredMoviePanel.Panel3;
			updateSeatAndPriceInfo();
		}

		private void helpLbl_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			HelpFile.Show( HelpFile.ConcertHall );
		}
		#endregion

	}
}
