using MediatR;
using MinhaApiEstudo.DTOs;

namespace MinhaApiEstudo.Features.Users.Queries.GetAllUsers
{
    // A Query define O QUE você quer buscar. Ela retorna uma lista de UserDto.
    public record GetAllUsersQuery() : IRequest<List<UserDto>>;
}
