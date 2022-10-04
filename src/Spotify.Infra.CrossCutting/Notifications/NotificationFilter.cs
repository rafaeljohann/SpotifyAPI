using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Spotify.Infra.CrossCutting.Notifications
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;

        public NotificationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                context.HttpContext.Response.ContentType = "application/json";

                var notificationResponse = new NotificationResponse(
                    "Houve um erro ao processar sua requisição.",
                    _notificationContext.Notifications
                );
                
                var notifications = JsonConvert.SerializeObject(notificationResponse);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}