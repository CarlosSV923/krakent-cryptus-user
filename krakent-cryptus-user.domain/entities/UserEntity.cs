namespace krakent_cryptus_user.infrastructure.database.entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string? Names { get; set; }

        public string? Lastnames { get; set; }
        public string? Username { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }

        public string? Identification { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? CreationDate { get; set; }

        public ICollection<UserRolEntity>? UserRols { get; set; }
    }
}