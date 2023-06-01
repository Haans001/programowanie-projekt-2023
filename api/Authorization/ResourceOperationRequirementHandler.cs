using System.Security.Claims;
using api.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace api.Authorization;

public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement,Quiz>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ResourceOperationRequirement requirement,
        Quiz quiz)
    {
        if (requirement.ResourceOperation is ResourceOperation.Read or ResourceOperation.Create)
        {
            context.Succeed(requirement);
        }

        if (requirement.ResourceOperation is ResourceOperation.Delete or ResourceOperation.Update)
        {
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (quiz.UserId == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}
