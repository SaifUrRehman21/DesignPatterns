namespace MediatorDesign.Application.Handlers
{
    public class GetUserByUserNameHandler(IUserService _userService) : IRequestHandler<GetUserByUserNameQuery, ServiceResult<UserDTO>>
    {
        public async Task<ServiceResult<UserDTO>> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
        {
            return await _userService.GetByUserName(query.UserName);
        }
    }
}
