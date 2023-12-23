namespace MediatorDesign.Application.Handlers
{
    public class UpdateUserHandler(IUserService _userService) : IRequestHandler<UpdateUserCommand, ServiceResult<UserDTO>>
    {
        public async Task<ServiceResult<UserDTO>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUser(command.Id, command.FirstName, command.LastName);
        }
    }
}
