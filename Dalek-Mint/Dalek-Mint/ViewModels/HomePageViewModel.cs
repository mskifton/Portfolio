namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="HomePageViewModel" />
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// Gets or sets the UpcomingEvents
        /// </summary>
        public ObservableCollection<Event> UpcomingEvents { get; set; }

        /// <summary>
        /// Gets or sets the Clubs
        /// </summary>
        public ObservableCollection<Club> Clubs { get; set; }

        /// <summary>
        /// Gets or sets the News
        /// </summary>
        public ObservableCollection<News> News { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel"/> class.
        /// </summary>
        public HomePageViewModel()
        {
        }
    }
}
