using System.Collections.Generic;

namespace OpenDCP.Framework.Security.Models
{
    public class UserQueryDTO
    {
        public List<int> UserId { get; set; } = new List<int>();
        public List<int> SiteId { get; set; } = new List<int>();
        public List<string> Email { get; set; } = new List<string>();
        public List<string> Permission { get; set; } = new List<string>();
    }
}
