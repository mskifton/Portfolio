namespace Dalek_Mint.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="EventAttendance" />
    /// </summary>
    public class EventAttendance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventAttendance"/> class.
        /// </summary>
        public EventAttendance()
        {
        }

        /// <summary>
        /// Defines the eventId
        /// </summary>
        private int eventId;

        /// <summary>
        /// Defines the isAttending
        /// </summary>
        private short isAttending;

        /// <summary>
        /// Defines the userName
        /// </summary>
        private string userName;

        /// <summary>
        /// Defines the userEmail
        /// </summary>
        private string userEmail;

        /// <summary>
        /// Defines the events
        /// </summary>
        private Event events;

        /// <summary>
        /// Defines the eventAttendanceId
        /// </summary>
        private int eventAttendanceId;

        /// <summary>
        /// Gets or sets the EventId
        /// </summary>
        public int EventId { get => eventId; set => eventId = value; }

        /// <summary>
        /// Gets or sets the EventAttendanceId
        /// </summary>
        [Key]
        public int EventAttendanceId { get => eventAttendanceId; set => eventAttendanceId = value; }

        /// <summary>
        /// Gets or sets the IsAttending
        /// </summary>
        public short IsAttending { get => isAttending; set => isAttending = value; }

        /// <summary>
        /// Gets or sets the Events
        /// </summary>
        public virtual Event Events { get => events; set => events = value; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get => userName; set => userName = value; }

        /// <summary>
        /// Gets or sets the UserEmail
        /// </summary>
        public string UserEmail { get => userEmail; set => userEmail = value; }
    }
}
