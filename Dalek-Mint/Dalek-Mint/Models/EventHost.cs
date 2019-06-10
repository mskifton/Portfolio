namespace Dalek_Mint.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="EventHost" />
    /// </summary>
    public class EventHost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHost"/> class.
        /// </summary>
        public EventHost()
        {
        }

        /// <summary>
        /// Defines the eventId
        /// </summary>
        private int eventId;

        /// <summary>
        /// Defines the clubId
        /// </summary>
        private int clubId;

        /// <summary>
        /// Defines the eventHostId
        /// </summary>
        private int eventHostId;

        /// <summary>
        /// Defines the clubs
        /// </summary>
        private Club clubs;

        /// <summary>
        /// Defines the events
        /// </summary>
        private Event events;

        /// <summary>
        /// Gets or sets the EventId
        /// </summary>
        public int EventId { get => eventId; set => eventId = value; }

        /// <summary>
        /// Gets or sets the EventHostId
        /// </summary>
        [Key]
        public int EventHostId { get => eventHostId; set => eventHostId = value; }

        /// <summary>
        /// Gets or sets the ClubId
        /// </summary>
        public int ClubId { get => clubId; set => clubId = value; }

        /// <summary>
        /// Gets or sets the Events
        /// </summary>
        public virtual Event Events { get => events; set => events = value; }

        /// <summary>
        /// Gets or sets the Clubs
        /// </summary>
        public virtual Club Clubs { get => clubs; set => clubs = value; }
    }
}
