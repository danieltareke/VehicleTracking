using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIGateway
{
    public class CustomMiddleware : OcelotPipelineConfiguration
    {
        public CustomMiddleware()
        {
            PreAuthorizationMiddleware = async (ctx, next) =>
            {
                await ProcessRequest(ctx, next);
            };
        }

        public async Task ProcessRequest(HttpContext context, System.Func<Task> next)
        {
            bool dd = context.User.Identity.IsAuthenticated;
          
        
            // Call the underline service
            await next.Invoke();
        }

        

       
    }
}