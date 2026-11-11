namespace OpenDCP.Framework.Security.Models
{
    public class PermissionDTO
    {
        public string Permission { get; set; }
        public int SiteId { get; set; } = 0;
        public string SiteName { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
    }
}
