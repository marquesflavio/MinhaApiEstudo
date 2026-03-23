using MediatR;
using Microsoft.EntityFrameworkCore;
using MinhaApiEstudo.Data;
using MinhaApiEstudo.DTOs;

namespace MinhaApiEstudo.Features.Users.Queries.GetAllUsers;

// O Handler contém a lógica de negócio. Ele acessa o banco e retorna os dados.
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly AppDbContext _context;

    public GetAllUsersHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Select(u => new UserDto(u.Id, u.Nome, u.Email, u.Endereco))
            .ToListAsync(cancellationToken);
    }
}