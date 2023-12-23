using MediatorDesign.Application.Contract.Repository;
using MediatorDesign.Application.Contract.Service;
using MediatorDesign.Domain.ErrorManagement;
using MediatorDesign.Domain.Model.DTO;
using MediatorDesign.Domain.Model.Entity;
using Microsoft.AspNetCore.Identity;

namespace MediatorDesign.Infrastructure.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<AspNetUserEntity> _userManager;

        public UserService(IUserRepository repository, UserManager<AspNetUserEntity> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            return users.Select(x => new UserDTO(x));
        }

        public async Task<ServiceResult<UserDTO>> GetByUserId(int id)
        {
            var user = await _repository.GetByUserId(id);
            return validateUser(user);
        }

        public async Task<ServiceResult<UserDTO>> GetByUserName(string userName)
        {
            var user = await _repository.GetByUserName(userName);
            return validateUser(user);
        }

        public async Task<ServiceResult<UserDTO>> CreateUser(string userName, string firstName, string lastName, string password)
        {
            bool userExist = await _repository.UserNameExists(userName);

            ServiceResult<UserDTO> result = default!;
            if (!userExist)
            {
                var user = await _repository.CreateUser(userName, firstName, lastName);
                var identityResult = await _userManager.AddPasswordAsync(user, password);

                if (identityResult.Succeeded)
                {
                    result = new ServiceResult<UserDTO>(new UserDTO(user));
                }
                else
                {
                    result = ServiceResult<UserDTO>.Failed(setIdentityErrors(identityResult.Errors));
                }
            }
            else
            {
                result = ServiceResult<UserDTO>.Failed(new ServiceErrors(ServiceErrorCode.BadRequest, "UserName already taken"));
            }
            return result;
        }

        public async Task<ServiceResult<UserDTO>> UpdateUser(int id, string firstName, string lastName)
        {
            var user = await _repository.UpdateUser(id, firstName, lastName);
            return validateUser(user);
        }

        public async Task<ServiceResult> ForgetPassword(string userName, string newPassword)
        {
            ServiceResult result = default!;
            var user = await _repository.GetByUserName(userName);
            result = validateUser(user);

            if (result.Succeeded && user is not null)
            {
                //Change Password
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var identityResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (!identityResult.Succeeded)
                {
                    result = ServiceResult.Failed(setIdentityErrors(identityResult.Errors));
                }
            }
            return result;
        }

        public async Task<ServiceResult> DeleteUser(int id)
        {
            var result = await GetByUserId(id);
            if (result.Succeeded)
            {
                await _repository.DeleteUser(id);
            }
            return result;
        }

        private ServiceResult<UserDTO> validateUser(AspNetUserEntity? user)
        {
            ServiceResult<UserDTO> result = default!;
            if (user is null)
            {
                result = ServiceResult<UserDTO>.Failed(new ServiceErrors(ServiceErrorCode.BadRequest, "User not exist"));
            }
            else
            {
                result = new ServiceResult<UserDTO>(new UserDTO(user));
            }
            return result;
        }

        private List<ServiceErrors> setIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            List<ServiceErrors> errors = new List<ServiceErrors>();
            foreach (var identityError in identityErrors)
            {
                errors.Add(new ServiceErrors(identityError.Code, identityError.Description));
            }
            return errors;
        }
    }
}
