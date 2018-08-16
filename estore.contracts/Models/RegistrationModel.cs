namespace estore.contracts.Models
{
    /// <summary>
    /// Defines model used while registration
    /// </summary>
    public class RegistrationModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
    }
}
