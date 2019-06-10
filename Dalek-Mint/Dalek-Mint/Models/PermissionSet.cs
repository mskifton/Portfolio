namespace Dalek_Mint.Models
{
    /// <summary>
    /// Defines the <see cref="PermissionSet" />
    /// </summary>
    public class PermissionSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionSet"/> class.
        /// </summary>
        public PermissionSet()
        {
        }

        /// <summary>
        /// Defines the permissionSetId
        /// </summary>
        private int permissionSetId;

        /// <summary>
        /// Defines the permissionSetName
        /// </summary>
        private string permissionSetName;

        /// <summary>
        /// Defines the canEdit
        /// </summary>
        private bool canEdit;

        /// <summary>
        /// Defines the canPublish
        /// </summary>
        private bool canPublish;

        /// <summary>
        /// Defines the canEditUsers
        /// </summary>
        private bool canEditUsers;

        /// <summary>
        /// Defines the requiresApprovalToPublish
        /// </summary>
        private bool requiresApprovalToPublish;

        /// <summary>
        /// Defines the requiresApprovalToEdit
        /// </summary>
        private bool requiresApprovalToEdit;

        /// <summary>
        /// Gets or sets the PermissionSetId
        /// </summary>
        public int PermissionSetId { get => permissionSetId; set => permissionSetId = value; }

        /// <summary>
        /// Gets or sets the PermissionSetName
        /// </summary>
        public string PermissionSetName { get => permissionSetName; set => permissionSetName = value; }

        /// <summary>
        /// Gets or sets a value indicating whether CanEdit
        /// </summary>
        public bool CanEdit { get => canEdit; set => canEdit = value; }

        /// <summary>
        /// Gets or sets a value indicating whether CanPublish
        /// </summary>
        public bool CanPublish { get => canPublish; set => canPublish = value; }

        /// <summary>
        /// Gets or sets a value indicating whether CanEditUsers
        /// </summary>
        public bool CanEditUsers { get => canEditUsers; set => canEditUsers = value; }

        /// <summary>
        /// Gets or sets a value indicating whether RequiresApprovalToPublish
        /// </summary>
        public bool RequiresApprovalToPublish { get => requiresApprovalToPublish; set => requiresApprovalToPublish = value; }

        /// <summary>
        /// Gets or sets a value indicating whether RequiresApprovalToEdit
        /// </summary>
        public bool RequiresApprovalToEdit { get => requiresApprovalToEdit; set => requiresApprovalToEdit = value; }
    }
}
