namespace Dalek_Mint.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlTypes;

    /// <summary>
    /// Defines the <see cref="Event" />
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event()
        {
            this.IsArchived = false;
        }

        /// <summary>
        /// Defines the attending
        /// </summary>
        private int attending;

        /// <summary>
        /// Defines the interested
        /// </summary>
        private int interested;

        /// <summary>
        /// Gets or sets a value indicating whether IsApproved
        /// Gets or sets whether or not the event has been approved
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Defines the eventId
        /// </summary>
        private int eventId;

        /// <summary>
        /// the campus which the event is being hosted on
        /// </summary>
        private int campusHostId;

        /// <summary>
        /// club hosting event
        /// </summary>
        private int clubHostId;

        /// <summary>
        /// Defines the name
        /// </summary>
        private string name;

        /// <summary>
        /// Defines the description
        /// </summary>
        private string description;

        /// <summary>
        /// Defines the date
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Defines the address
        /// </summary>
        private string address;

        /// <summary>
        /// Defines the event date
        /// </summary>
        private DateTime eventDate;

        /// <summary>
        /// Defines event time
        /// </summary>
        private string eventTime;

        /// <summary>
        /// Defines the campusEvents
        /// </summary>
        private ObservableCollection<CampusEvent> campusEvents;

        /// <summary>
        /// Defines the eventAttendance
        /// </summary>
        private ObservableCollection<EventAttendance> eventAttendance;

        /// <summary>
        /// Defines the eventHost
        /// </summary>
        private ObservableCollection<Club> eventHost;

        /// <summary>
        /// Defines the city
        /// </summary>
        private string city;

        /// <summary>
        /// Defines the time
        /// </summary>
        private TimeSpan time;

        /// <summary>
        /// Defines the state
        /// </summary>
        private string state;

        /// <summary>
        /// Defines the zip
        /// </summary>
        private int zip;

        /// <summary>
        /// Defines the freeFood
        /// </summary>
        private bool freeFood;

        /// <summary>
        /// Defines the freeStuff
        /// </summary>
        private bool freeStuff;

        /// <summary>
        /// Defines the category
        /// </summary>
        private int category;

        /// <summary>
        /// Defines the categoryName
        /// </summary>
        private string categoryName;

        /// <summary>
        /// Defines the contact
        /// </summary>
        private string contact;

        /// <summary>
        /// Defines the rsvpCapable
        /// </summary>
        private bool rsvpCapable;

        /// <summary>
        /// Gets or sets the CampusEvents
        /// </summary>
        public ObservableCollection<CampusEvent> CampusEvents { get => campusEvents; set => campusEvents = value; }

        /// <summary>
        /// Gets or sets the EventAttendances
        /// </summary>
        public ObservableCollection<EventAttendance> EventAttendances { get => eventAttendance; set => eventAttendance = value; }

        /// <summary>
        /// Gets or sets the EventHosts
        /// </summary>
        public ObservableCollection<Club> EventHosts { get => eventHost; set => eventHost = value; }

        /// <summary>
        /// Gets or sets the EventId
        /// </summary>
        public int EventId { get => eventId; set => eventId = value; }

        /// <summary>
        /// Gets or sets the CampusHostId
        /// gets the campus ID from the selection
        /// </summary>
        public int CampusHostId { get => campusHostId; set => campusHostId = value; }

        /// <summary>
        /// Gets or sets the ClubHostId
        /// gets /sets the id of club hosting event
        /// </summary>
        public int ClubHostId { get => clubHostId; set => clubHostId = value; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Required]
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Gets or sets the Date
        /// </summary>
        public DateTime Date { get => date; set => date = value; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [Required]
        public string Address { get => address; set => address = value; }

        /// <summary>
        /// Gets the FullAddress
        /// </summary>
        [NotMapped]
        public string FullAddress => Address.ToString() + ' ' + City.ToString() + ", " + State.ToString() + ", " + Zip.ToString();

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        [Required]
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$", ErrorMessage = "Please use the 2 letter abbreviation for State.")]
        [MaxLength(2)]
        [Required]
        public string State { get => state; set => state = value; }

        /// <summary>
        /// Gets or sets the Zip
        /// </summary>
        [RegularExpression(@"\d{5}", ErrorMessage = "Please enter the 5 digit Zip Code only.")]
        [Range(0, 99999, ErrorMessage = "Please enter the 5 digit Zip Code Only.")]
        [Required]
        public int Zip { get => zip; set => zip = value; }

        /// <summary>
        /// Gets or sets a value indicating whether FreeFood
        /// </summary>
        public bool FreeFood { get => freeFood; set => freeFood = value; }

        /// <summary>
        /// Gets or sets a value indicating whether FreeStuff
        /// </summary>
        public bool FreeStuff { get => freeStuff; set => freeStuff = value; }

        /// <summary>
        /// Gets or sets the Category
        /// </summary>
        public int Category { get => category; set => category = value; }

        /// <summary>
        /// Gets or sets the CategoryName
        /// </summary>
        [NotMapped]
        public string CategoryName { get => categoryName; set => categoryName = value; }

        /// <summary>
        /// Gets or sets a value indicating whether RSVPCapable
        /// </summary>
        public bool RSVPCapable { get => rsvpCapable; set => rsvpCapable = value; }

        /// <summary>
        /// Gets or sets the contact who submitted the form.
        /// </summary>
        [Required]
        public string Contact { get => contact; set => contact = value; }


        /// <summary>
        /// Gets or sets the contact name who submitted the form.
        /// </summary>
        [Required]
        public string ContactName { get ; set ; }


        /// <summary>
        /// Gets or sets the events image name
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets the EventDate
        /// Takes the date and returns only the month, day, year
        /// </summary>
        [DataType(DataType.Date)]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate
        {
            get
            {
                return this.Date;
            }
            set
            {
                this.eventDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the EventTime
        /// Takes the datetime and returns only the time portion
        /// </summary>
        [DataType(DataType.Time)]
        [NotMapped]
        public TimeSpan EventTime
        {
            get
            {
                return this.Date.TimeOfDay;
            }
            set
            {
                this.time = value;
            }
        }

        /// <summary>
        /// Gets the full date in SQL DateTime format
        /// </summary>
        [NotMapped]
        public DateTime FullDate
        {
            get
            {
                return (DateTime)new SqlDateTime(this.eventDate.Add(this.time));
            }
        }

        /// <summary>
        /// Gets or sets the Attending
        /// </summary>
        [NotMapped]
        public int Attending { get => attending; set => attending = value; }

        /// <summary>
        /// Gets or sets the Interested
        /// </summary>
        [NotMapped]
        public int Interested { get => interested; set => interested = value; }
    }
}
