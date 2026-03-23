using MediatR;
using Microsoft.EntityFrameworkCore;
using MinhaApiEstudo.Data;
using MinhaApiEstudo.DTOs;
using MinhaApiEstudo.Features.Users.Queries.GetAllUsers;

namespace MinhaApiEstudo.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly AppDbContext _context;

        public GetUserByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);
            
            if (user is null) return null;
            
            return new UserDto(user.Id, user.Nome, user.Email, user.Endereco);
        }
    }
}