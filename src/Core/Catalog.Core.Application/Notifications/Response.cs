using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Catalog.Core.Application.Notifications
{
    public class Response
    {
        protected string email;

        public Response()
        {
            Notifications = [];
        }

        public Response(object data)
        {
            Notifications = [];
            Data = data;
        }

        public Response(IList<Notification> notifications)
        {
            Notifications = notifications;
        }

        public Response(IHttpContextAccessor httpContextAccessor)
        {
            Notifications = [];

            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            }
        }

        public IList<Notification> Notifications { get; private set; }
        public object Data { get; private set; }
        public bool IsInvalid { get; private set; }

        protected void AddNotification(string message)
        {
            Notifications.Add(new Notification(message));
        }

        protected Response Success()
        {
            return new Response();
        }

        protected Response Success(object data)
        {
            return new Response(data);
        }

        protected Response Failure()
        {
            return new Response(Notifications);
        }

        protected void Validate<TValidator, TRequest>(TValidator validator, TRequest request)
            where TValidator : AbstractValidator<TRequest>
        {
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddNotification(error.ErrorMessage);
                }

                IsInvalid = true;
            }
        }
    }
}
