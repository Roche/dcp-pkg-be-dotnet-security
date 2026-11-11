using System.Collections.Generic;

namespace OpenDCP.Framework.Security.Models
{
    public class UserInfoDTO
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string PermissionsText { get; set; }
        public string TimeFormat { get; set; }
        public string DateFormat { get; set; }
        public List<string> Roles { get; set; }
    }
}
