using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace TestApplication.Models
{
    public static class IdentityExtensions
    {
        public static T GetUserName<T>(this IIdentity identity) where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                var name = ci.FindFirst(ClaimTypes.NameIdentifier);
                if (name != null)
                {
                    return (T)Convert.ChangeType(name.Value, typeof(T), CultureInfo.InvariantCulture);
                }
            }
            return default(T);
        }
    }
}