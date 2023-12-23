namespace MediatorDesign.Application.Commands
{
    public class InsertUserCommand : IRequest<ServiceResult<UserDTO>>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public InsertUserCommand(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
    }
}
