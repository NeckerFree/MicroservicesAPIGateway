namespace Parser.Contracts
{
    public class Contracts
    {
        public record ClientCreated(Guid Id, string? Name, string? Description, string? Address, string ? Phone);

        public record ClientUpdated(Guid Id, string? Name, string? Description, string? Address, string? Phone);

        public record ClientDeleted(Guid Id);
    }
}
