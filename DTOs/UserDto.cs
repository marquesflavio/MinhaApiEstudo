namespace MinhaApiEstudo.DTOs;

// record é perfeito para DTOs: imutável, conciso e com suporte a desconstrução
public record UserDto(int Id, string Nome, string Email, string? Endereco);