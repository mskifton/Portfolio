namespace Dalek_Mint.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="Campus" />
    /// </summary>
    public class Campus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Campus"/> class.
        /// </summary>
        public Campus()
        {
        }

        /// <summary>
        /// Defines the campusId
        /// </summary>
        private int campusId;

        /// <summary>
        /// Defines the address
        /// </summary>
        private string address;

        /// <summary>
        /// Defines the city
        /// </summary>
        private string city;

        /// <summary>
        /// Defines the state
        /// </summary>
        private string state;

        /// <summary>
        /// Defines the zip
        /// </summary>
        private int zip;

        /// <summary>
        /// Defines the phoneNumber
        /// </summary>
        private long phoneNumber;

        /// <summary>
        /// Gets or sets the CampusEvents
        /// </summary>
        public ObservableCollection<CampusEvent> CampusEvents { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Gets or sets the State
        /// </summary>
        public string State { get => state; set => state = value; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get => address; set => address = value; }

        /// <summary>
        /// Gets or sets the CampusId
        /// </summary>
        public int CampusId { get => campusId; set => campusId = value; }

        /// <summary>
        /// Gets or sets the Zip
        /// </summary>
        public int Zip { get => zip; set => zip = value; }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
