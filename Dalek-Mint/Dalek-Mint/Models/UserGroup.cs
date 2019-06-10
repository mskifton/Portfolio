namespace Dalek_Mint.Models
{
    /// <summary>
    /// Defines the <see cref="UserGroup" />
    /// </summary>
    public class UserGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserGroup"/> class.
        /// </summary>
        public UserGroup()
        {
        }

        /// <summary>
        /// Defines the userGroupId
        /// </summary>
        private int userGroupId;

        /// <summary>
        /// Defines the userGroupPermissionSetId
        /// </summary>
        private int userGroupPermissionSetId;

        /// <summary>
        /// Gets or sets the UserGroupId
        /// </summary>
        public int UserGroupId { get => userGroupId; set => userGroupId = value; }

        /// <summary>
        /// Gets or sets the UserGroupPermissionSetId
        /// </summary>
        public int UserGroupPermissionSetId { get => userGroupPermissionSetId; set => userGroupPermissionSetId = value; }
    }
}
