using Ergasia3.Source;
using Ergasia3.Source.Frontend.CinemaHall;
using Ergasia3.Source.Frontend.ConcertHall;
using Ergasia3.Source.Frontend.ExhibitionHall;
using Ergasia3.Source.Frontend.DJockeyHall;
using Ergasia3.Source.Frontend;

namespace Ergasia3.Source
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run( new MainHall() );
        }
    }
}