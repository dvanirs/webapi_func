using MediatR;
using WebApi_Func.Application.DTOs;

namespace WebApi_Func.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {

        public string SortOrder { get; set; } = string.Empty;
    }
}
