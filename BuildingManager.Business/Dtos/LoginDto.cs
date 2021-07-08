using System.ComponentModel.DataAnnotations;

namespace BuildingManager.Business.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}