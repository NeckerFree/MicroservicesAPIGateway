namespace Employment.API.DTOs
{
    public record JobPositionDTO(Guid Id, Guid ClientId, string? Title, string? Description, string? Requisites);

    public record ClientInfoDTO(Guid Id, string? Name, string? Description);
}
