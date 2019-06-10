namespace Dalek_Mint.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ClubMember" />
    /// </summary>
    public class ClubMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClubMember"/> class.
        /// </summary>
        public ClubMember()
        {
        }

        /// <summary>
        /// Defines the clubs
        /// </summary>
        private Club clubs;

        /// <summary>
        /// Defines the users
        /// </summary>
        private User users;

        /// <summary>
        /// Defines the clubId
        /// </summary>
        private int clubId;

        /// <summary>
        /// Defines the clubMemberId
        /// </summary>
        private int clubMemberId;

        /// <summary>
        /// Defines the userId
        /// </summary>
        private int userId;

        /// <summary>
        /// Defines if the member is an officer.
        /// </summary>
        private bool isOfficer;

        /// <summary>
        /// Defines the title
        /// </summary>
        private string title;

        /// <summary>
        /// Gets or sets the ClubId
        /// </summary>
        public int ClubId { get => clubId; set => clubId = value; }

        /// <summary>
        /// Gets or sets the ClubMemberId
        /// </summary>
        [Key]
        public int ClubMemberId { get => clubMemberId; set => clubMemberId = value; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get => userId; set => userId = value; }

        /// <summary>
        /// Gets or sets a value indicating whether IsOfficer
        /// </summary>
        public bool IsOfficer { get => isOfficer; set => isOfficer = value; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// Gets or sets the Clubs
        /// </summary>
        public virtual Club Clubs { get => clubs; set => clubs = value; }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public virtual User Users { get => users; set => users = value; }
    }
}
