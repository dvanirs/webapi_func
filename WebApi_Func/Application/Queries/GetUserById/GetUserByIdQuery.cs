using MediatR;
using WebApi_Func.Application.DTOs;

namespace WebApi_Func.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
