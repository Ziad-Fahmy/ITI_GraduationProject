using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ITI_GraduationProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(8, MinimumLength = 3, ErrorMessage = "Name Must be between 2 and 8 character.")]
        [Required(ErrorMessage = "FirstName is Required.")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }


        [StringLength(8, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 8 character.")]
        [Required(ErrorMessage = "LastName is Required.")]
        [DisplayName("LastName")]

        public string LastName { get; set; }



        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName(" Email")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
