namespace krakent_cryptus_user.infrastructure.database.entities
{
    public class RolEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }

        public ICollection<UserRolEntity>? UserRols { get; set; }
    }
}