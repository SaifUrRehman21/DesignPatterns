namespace MediatorDesign.Application.Handlers
{
    public class InsertUserHandler(IUserService _userService) : IRequestHandler<InsertUserCommand, ServiceResult<UserDTO>>
    {
        public async Task<ServiceResult<UserDTO>> Handle(InsertUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(command.FirstName, command.LastName, command.UserName, command.Password);
        }
    }
}
