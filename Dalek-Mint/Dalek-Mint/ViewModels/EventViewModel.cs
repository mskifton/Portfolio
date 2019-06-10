namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="EventViewModel" />
    /// </summary>
    public class EventViewModel
    {
        /// <summary>
        /// Gets or sets the main event on the page.
        /// </summary>
        public Event MainEvent { get; set; }

        /// <summary>
        /// Gets or sets the SimilarEvents
        /// Getsn or sets the other events by the hosts.
        /// </summary>
        public ObservableCollection<Event> SimilarEvents { get; set; }
    }
}
