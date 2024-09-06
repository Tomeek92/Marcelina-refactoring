using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Users.GetId
{
    public class GetUserIdCommand : IRequest<UserDto>
    {
        public string Id { get; set; }

        public GetUserIdCommand(string id)
        {
            Id = id;
        }
    }
}