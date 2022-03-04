using System;
using System.ComponentModel.DataAnnotations;

namespace SmallProject.Domain
{
    /// <summary>
    /// Domain class for the users
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Username which is used to log in
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

    }
}
