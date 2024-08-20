using Catalog.Core.Application.Notifications;
using Catalog.Infrastructure.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Olivitec.InfoProduct.Core.Application.Features.Users.GetUsers;

namespace Catalog.Core.Application.Features.Users.GetUsers
{
    public class GetUsersQueryHandler : Response, IRequestHandler<GetUsersQuery, Response>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetUsersQueryHandler(IIdentityRepository identityRepository, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _identityRepository = identityRepository;
        }

        public async Task<Response> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            Validate(new GetUsersValidator(), request);

            if (IsInvalid) return Failure();

            var users = await _identityRepository.GetUsersAsync();

            var result = users.ToResponse();

            return Success(result);
        }
    }
}
