namespace MediatorDesign.Application.Handlers
{
    public class GetUserByIdHandler(IUserService _userService) : IRequestHandler<GetUserByIdQuery, ServiceResult<UserDTO>>
    {
        public async Task<ServiceResult<UserDTO>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            return await _userService.GetByUserId(query.Id);
        }
    }
}
