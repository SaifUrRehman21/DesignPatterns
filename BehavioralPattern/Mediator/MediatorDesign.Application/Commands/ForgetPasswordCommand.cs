namespace MediatorDesign.Application.Commands
{
    public class ForgetPasswordCommand : IRequest<ServiceResult>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public ForgetPasswordCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
