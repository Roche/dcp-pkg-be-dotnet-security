namespace OpenDCP.Framework.Security.Models
{
    /// <summary>
    /// Represents a user entry in a list, including identification and contact information.
    /// </summary>
    public class UserListItemDTO
    {
        /// <summary>
        /// Gets or sets the unique numeric identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique Unix identifier (username) of the user.
        /// </summary>
        public string UnixId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the user, typically used in UI listings.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// May be <c>null</c> if the user does not have an email configured.
        /// </summary>
        public string Email { get; set; }
    }
}
