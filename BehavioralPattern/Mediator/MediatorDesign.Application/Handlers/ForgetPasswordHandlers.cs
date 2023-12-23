namespace MediatorDesign.Application.Handlers
{
    public class ForgetPasswordHandlers(IUserService _userService) : IRequestHandler<ForgetPasswordCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            return await _userService.ForgetPassword(command.UserName, command.Password);
        }
    }
}
