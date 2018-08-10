namespace estore.domain.Models
{
    /// <summary>
    /// Defines a model that comes as response while success login
    /// </summary>
    public class LoginResponseModel
    {
        public LoginResponseModel(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
