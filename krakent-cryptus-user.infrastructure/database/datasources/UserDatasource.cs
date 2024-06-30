using krakent_cryptus_user.domain.entities;
using krakent_cryptus_user.domain.interfaces.infrastructure.datasources;
using krakent_cryptus_user.infrastructure.database.context;
using Microsoft.EntityFrameworkCore;

namespace krakent_cryptus_user.infrastructure.database.datasources
{
    public class UserDatasource(PostgreSqlContext _context) : IUserDatasource
    {

        public async Task<UserEntity> CreateUser(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<UserEntity?> GetUserById(int id)
        {
            return _context.Users.Include(x => x.UserRols!).ThenInclude(x => x.Rol).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<UserEntity?> GetUserByIdentification(string identification)
        {
            return _context.Users.Include(x => x.UserRols!).ThenInclude(x => x.Rol).FirstOrDefaultAsync(x => x.Identification == identification);
        }

        public Task<UserEntity?> GetUserByMail(string mail)
        {
            return _context.Users.Include(x => x.UserRols!).ThenInclude(x => x.Rol).FirstOrDefaultAsync(x => x.Email == mail);
        }

        public Task<UserEntity?> GetUserByUsername(string username)
        {
            return _context.Users.Include(x => x.UserRols!).ThenInclude(x => x.Rol).FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserEntity> UpdateUser(UserEntity user)
        {

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

    }
}