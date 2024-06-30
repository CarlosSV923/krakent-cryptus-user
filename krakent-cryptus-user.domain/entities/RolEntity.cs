namespace krakent_cryptus_user.domain.entities
{
    public class RolEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }

        public ICollection<UserRolEntity>? UserRols { get; set; }
    }
}