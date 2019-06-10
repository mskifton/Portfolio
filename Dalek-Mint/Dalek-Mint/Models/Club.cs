namespace Dalek_Mint.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Club" />
    /// </summary>
    public class Club
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Club"/> class.
        /// </summary>
        public Club()
        {
            this.IsArchived = false;
        }
        /// <summary>
        /// Gets or sets a value indicating whether IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets the Clubs upcoming events.
        /// </summary>
        public ObservableCollection<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets the Clubs Officers.
        /// </summary>
        public ObservableCollection<User> Officers { get; set; }

        /// <summary>
        /// Defines the clubId
        /// </summary>
        private int clubId;

        /// <summary>
        /// Defines the name
        /// </summary>
        private string name;

        /// <summary>
        /// Defines the clubMember
        /// </summary>
        private ObservableCollection<ClubMember> clubMember;

        /// <summary>
        /// Defines the clubNews
        /// </summary>
        private ObservableCollection<ClubNews> clubNews;

        /// <summary>
        /// Defines the description
        /// </summary>
        private string description;

        /// <summary>
        /// Defines the eventHost
        /// </summary>
        private ObservableCollection<EventHost> eventHost;

        /// <summary>
        /// Defines the contact
        /// </summary>
        private string contact;

        /// <summary>
        /// Gets or sets the ClubId
        /// </summary>
        public int ClubId { get => clubId; set => clubId = value; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Required]
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Gets or sets the ClubNews
        /// </summary>
        public ObservableCollection<ClubNews> ClubNews { get => clubNews; set => clubNews = value; }

        /// <summary>
        /// Gets or sets the ClubMembers
        /// </summary>
        public ObservableCollection<ClubMember> ClubMembers { get => clubMember; set => clubMember = value; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Gets or sets the EventHosts
        /// </summary>
        public ObservableCollection<EventHost> EventHosts { get => eventHost; set => eventHost = value; }

        /// <summary>
        /// Gets or sets the Contact
        /// </summary>
        public string Contact { get => contact; set => contact = value; }

        /// <summary>
        /// Gets or sets the clubs logo name
        /// </summary>
        public byte [] Image { get; set; }
    }
}
