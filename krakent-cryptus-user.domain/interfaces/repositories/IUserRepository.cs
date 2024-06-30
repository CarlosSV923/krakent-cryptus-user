using krakent_cryptus_user.domain.entities;

namespace krakent_cryptus_user.domain.interfaces.repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> CreateUser(UserEntity user);
        Task<UserEntity?> GetUserById(int id);
        Task<UserEntity?> GetUserByIdentification(string identification);
        Task<UserEntity?> GetUserByMail(string mail);
        Task<UserEntity?> GetUserByUsername(string username);
        Task<UserEntity> UpdateUser(UserEntity user);
        Task<UserEntity?> DeleteUser(int id);
    }
}