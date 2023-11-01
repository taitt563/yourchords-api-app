using Microsoft.AspNetCore.Authorization;

namespace YourChordsAPIApp.WebAPI.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
