namespace Dalek_Mint.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="CampusEvent" />
    /// </summary>
    public class CampusEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CampusEvent"/> class.
        /// </summary>
        public CampusEvent()
        {
        }

        /// <summary>
        /// Defines the campus
        /// </summary>
        private Campus campus;

        /// <summary>
        /// Defines the campusEventId
        /// </summary>
        private int campusEventId;

        /// <summary>
        /// Defines the events
        /// </summary>
        private Event events;

        /// <summary>
        /// Defines the eventId
        /// </summary>
        private int eventId;

        /// <summary>
        /// Defines the campusId
        /// </summary>
        private int campusId;

        /// <summary>
        /// Gets or sets the Campus
        /// </summary>
        public virtual Campus Campus { get => campus; set => campus = value; }

        /// <summary>
        /// Gets or sets the CampusId
        /// </summary>
        public int CampusId { get => campusId; set => campusId = value; }

        /// <summary>
        /// Gets or sets the Event
        /// </summary>
        public virtual Event Event { get => events; set => events = value; }

        /// <summary>
        /// Gets or sets the EventId
        /// </summary>
        public int EventId { get => eventId; set => eventId = value; }

        /// <summary>
        /// Gets or sets the CampusEventId
        /// </summary>
        [Key]
        public int CampusEventId { get => campusEventId; set => campusEventId = value; }
    }
}
