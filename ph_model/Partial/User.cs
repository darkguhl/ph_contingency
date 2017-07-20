using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ph_model
{
    [MetadataType(typeof(User.Metadata))]
    public partial class User
    {
        sealed class Metadata
        {
            [Key]
            [Required(ErrorMessage = "Name is required.")]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
            //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Key]
            [Required(ErrorMessage = "Email is required.")]
            [Display(Name = "Email address")]
            [EmailAddress]
            public string Email { get; set; }

            public string PasswordSalt { get; set; }
        }
    }
}
