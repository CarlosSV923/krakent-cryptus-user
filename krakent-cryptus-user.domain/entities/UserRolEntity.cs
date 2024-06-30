namespace krakent_cryptus_user.domain.entities
{
    public class UserRolEntity
    {
        public int UserId { get; set; }
        public int RolId { get; set; }

        public UserEntity? User { get; set; }

        public RolEntity? Rol { get; set; }
    }
}