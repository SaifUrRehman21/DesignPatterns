namespace MediatorDesign.Application.Commands
{
    public class UpdateUserCommand : IRequest<ServiceResult<UserDTO>>
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public UpdateUserCommand(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
