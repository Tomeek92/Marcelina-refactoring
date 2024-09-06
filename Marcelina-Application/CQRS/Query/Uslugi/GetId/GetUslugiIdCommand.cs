using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Query.Uslugi.GetId
{
    public class GetUslugiIdCommand : IRequest<UslugaDto>
    {
        public int Id { get; set; }

        public GetUslugiIdCommand(int id)
        {
            Id = id;
        }
    }
}