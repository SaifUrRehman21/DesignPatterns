namespace MediatorDesign.API.Model.Response
{
    public class LoginResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public LoginResponse(string userName)
        {
            UserName = userName;
        }
    }
}
