using MediatorDesign.Application.Contract.Repository;
using MediatorDesign.Domain;
using MediatorDesign.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediatorDesign.Infrastructure.Repository
{
    internal class UserRepository(ApplicationDbContext _dbContext) : IUserRepository
    {
        public async Task<IEnumerable<AspNetUserEntity>> GetAllUsers()
        {
            return await _dbContext.Users.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<AspNetUserEntity?> GetByUserId(int id)
        {
            return await _dbContext.Users.Where(x => !x.IsDeleted && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UserNameExists(string userName)
        {
            return await _dbContext.Users.Where(x => !x.IsDeleted && x.UserName == userName).AnyAsync();
        }

        public async Task<AspNetUserEntity?> GetByUserName(string userName)
        {
            return await _dbContext.Users.Where(x => !x.IsDeleted && x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<AspNetUserEntity> CreateUser(string userName, string firstName, string lastName)
        {
            var userEntity = new AspNetUserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
            };
            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();

            return userEntity;
        }

        public async Task<AspNetUserEntity?> UpdateUser(int id, string firstName, string lastName)
        {
            var user = await GetByUserId(id);

            if (user is not null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetByUserId(id);

            if (user is not null)
            {
                user.IsDeleted = true;
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
