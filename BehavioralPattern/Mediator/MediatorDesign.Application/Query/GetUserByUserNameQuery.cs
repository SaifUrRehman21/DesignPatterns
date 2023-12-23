namespace MediatorDesign.Application.Query
{
    public class GetUserByUserNameQuery : IRequest<ServiceResult<UserDTO>>
    {
        public string UserName { get; private set; }

        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
