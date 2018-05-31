using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Fan.Addins.Filters
{
    public class HangfireAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
            //var httpcontext = context.GetHttpContext();
            //return httpcontext.User.Identity.IsAuthenticated;
        }
    }
}
