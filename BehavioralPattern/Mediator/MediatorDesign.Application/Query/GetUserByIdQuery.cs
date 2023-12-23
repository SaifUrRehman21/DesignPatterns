namespace MediatorDesign.Application.Query
{
    public class GetUserByIdQuery : IRequest<ServiceResult<UserDTO>>
    {
        public int Id { get; private set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
