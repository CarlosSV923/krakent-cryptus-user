using krakent_cryptus_user.domain.entities;
using krakent_cryptus_user.domain.interfaces.datasources;
using krakent_cryptus_user.domain.interfaces.repositories;

namespace krakent_cryptus_user.infrastructure.database.repositories
{
    public class UserRepository(IUserDatasource _userDatasource) : IUserRepository {
        public Task<UserEntity> CreateUser(UserEntity user)
        {
            return _userDatasource.CreateUser(user);
        }

        public Task<UserEntity?> DeleteUser(int id)
        {
            return _userDatasource.DeleteUser(id);
        }

        public Task<UserEntity?> GetUserById(int id)
        {
            return _userDatasource.GetUserById(id);
        }

        public Task<UserEntity?> GetUserByIdentification(string identification)
        {
            return _userDatasource.GetUserByIdentification(identification);
        }

        public Task<UserEntity?> GetUserByMail(string mail)
        {
            return _userDatasource.GetUserByMail(mail);
        }

        public Task<UserEntity?> GetUserByUsername(string username)
        {
            return _userDatasource.GetUserByUsername(username);
        }

        public Task<UserEntity> UpdateUser(UserEntity user)
        {
            return _userDatasource.UpdateUser(user);
        }
    }
}