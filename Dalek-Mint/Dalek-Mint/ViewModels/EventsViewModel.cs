namespace Dalek_Mint.ViewModels
{
    using Dalek_Mint.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="EventsViewModel" />
    /// </summary>
    public class EventsViewModel
    {
        /// <summary>
        /// Gets or sets the Events
        /// </summary>
        public List<Event> Events { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsViewModel"/> class.
        /// </summary>
        public EventsViewModel()
        {
        }
    }
}
