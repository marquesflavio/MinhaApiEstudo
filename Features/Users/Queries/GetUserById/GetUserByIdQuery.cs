using MediatR;
using MinhaApiEstudo.DTOs;

namespace MinhaApiEstudo.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto?>;
}
