using MediatorDesign.Domain.Model.Entity;

namespace MediatorDesign.Application.Contract.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<AspNetUserEntity>> GetAllUsers();
        Task<AspNetUserEntity?> GetByUserId(int id);
        Task<AspNetUserEntity?> GetByUserName(string userName);
        Task<bool> UserNameExists(string userName);
        Task<AspNetUserEntity> CreateUser(string userName, string firstName, string lastName);
        Task<AspNetUserEntity?> UpdateUser(int id, string firstName, string lastName);
        Task DeleteUser(int id);
    }
}
