namespace MediatorDesign.Application.Contract.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<ServiceResult<UserDTO>> GetByUserId(int id);
        Task<ServiceResult<UserDTO>> GetByUserName(string userName);
        Task<ServiceResult<UserDTO>> CreateUser(string userName, string firstName, string lastName, string password);
        Task<ServiceResult<UserDTO>> UpdateUser(int id, string firstName, string lastName);
        Task<ServiceResult> ForgetPassword(string userName, string newPassword);
        Task<ServiceResult> DeleteUser(int id);
    }
}
