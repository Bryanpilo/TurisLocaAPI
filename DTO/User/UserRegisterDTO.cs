using System.ComponentModel.DataAnnotations;

namespace TurisLocAPI.API.DTO.User
{
    public class UserRegisterDTO
    {
        [Required]
        [StringLength(8, MinimumLength= 4, ErrorMessage="You must specify username between 4 and 10 characters")]
        public string username { get; set; }
        [Required]
        [StringLength(8, MinimumLength= 4, ErrorMessage="You must specify password between 4 and 8 characters")]
        public string password { get; set; }
    }
}