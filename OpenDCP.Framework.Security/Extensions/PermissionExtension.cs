using OpenDCP.Framework.Security.Models;
using System;

namespace OpenDCP.Framework.Security.Extensions
{
    public static class PermissionExtension
    {
        public static string ToDisplayString(this PermissionDTO info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            return $"{Capitalize(info.Permission)} permission in {info.Module} Module at Site {info.SiteName}";
        }

        private static string Capitalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            return char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
    }
}
