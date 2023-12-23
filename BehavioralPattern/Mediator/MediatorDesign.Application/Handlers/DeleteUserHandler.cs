namespace MediatorDesign.Application.Handlers
{
    public class DeleteUserHandler(IUserService _userService) : IRequestHandler<DeleteUserCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUser(command.Id);
        }
    }
}
