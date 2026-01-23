using MediatR;
using WebApi_Func.Application.DTOs;

namespace WebApi_Func.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortOrder { get; set; } = string.Empty;
    }
}
