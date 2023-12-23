namespace MediatorDesign.Application.Commands
{
    public class DeleteUserCommand : IRequest<ServiceResult>
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
