using Microsoft.AspNetCore.Authorization;

namespace CourseStor.AAA.Infrastructure
{
    public class AgePolicyRequirementHandler: AuthorizationHandler<AgePolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgePolicyRequirement requirement)
        {
            var random = new Random();
            int userAge = random.Next(15,20);
            if (userAge >= requirement.Age)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public class AgePolicyRequirement: IAuthorizationRequirement
    {
        public int Age { get; set; }
        public AgePolicyRequirement(int age)
        {
            Age = age;
        }

    }
}
