namespace Consumer.API.DTOs
{
    public record ClientDTO(Guid Id, string? Name, string? Description, string? Address, string? Phone);
}
