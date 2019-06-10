namespace Dalek_Mint.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Defines the userId
        /// </summary>
        private int userId;

        /// <summary>
        /// Defines the clubMember
        /// </summary>
        private ObservableCollection<ClubMember> clubMember;

        /// <summary>
        /// Defines the eventHost
        /// </summary>
        private ObservableCollection<EventHost> eventHost;

        /// <summary>
        /// Defines the email
        /// </summary>
        private string email;

        /// <summary>
        /// Defines the firstName
        /// </summary>
        private string firstName;

        /// <summary>
        /// Defines the lastName
        /// </summary>
        private string lastName;

        /// <summary>
        /// Defines the password
        /// </summary>
        private string password;

        /// <summary>
        /// Defines the title
        /// </summary>
        private string title;

        /// <summary>
        /// Defines the userGroupId
        /// </summary>
        private int userGroupId;

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get => userId; set => userId = value; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get => password; set => password = value; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get => title; set => title = value; }

        /// <summary>
        /// Gets or sets the UserGroupId
        /// </summary>
        public int UserGroupId { get => userGroupId; set => userGroupId = value; }

        /// <summary>
        /// Gets or sets the ClubMembers
        /// </summary>
        public ObservableCollection<ClubMember> ClubMembers { get => clubMember; set => clubMember = value; }

        /// <summary>
        /// Gets or sets the EventHosts
        /// </summary>
        public ObservableCollection<EventHost> EventHosts { get => eventHost; set => eventHost = value; }
    }
}
