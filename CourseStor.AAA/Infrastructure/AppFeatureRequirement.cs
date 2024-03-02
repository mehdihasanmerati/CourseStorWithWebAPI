using Microsoft.AspNetCore.Authorization;

namespace CourseStor.AAA.Infrastructure
{
    public class ApplicationFeature
    {
        public List<string> FeaturesList { get; set; } = new List<string>();  
    }
    public class AppFeatureRequirement : IAuthorizationRequirement
    {
    }

    public class AppFeatureRequirementHandler : AuthorizationHandler<AppFeatureRequirement>
    {
        private readonly ApplicationFeature _applicationFeature;

        public AppFeatureRequirementHandler(ApplicationFeature applicationFeature)
        {
            _applicationFeature = applicationFeature;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AppFeatureRequirement requirement)
        {
            context.User.Claims.Any(c => c.Type == "AppFeature" &&
            _applicationFeature.FeaturesList.Any(d => d == c.Value));

            return Task.CompletedTask;
        }
    }
}
