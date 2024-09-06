using Marcelina_Application.Dto;
using MediatR;

namespace Marcelina_Application.CQRS.Command.Uslugi.Delete
{
    public class DeleteUslugiCommand : UslugaDto, IRequest
    {
        public int Id { get; set; }

        public DeleteUslugiCommand(int id)
        {
            Id = id;
        }
    }
}