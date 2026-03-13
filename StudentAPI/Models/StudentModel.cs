using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
namespace StudentAPI.Models
{
    public class StudentModel
    {
       
        public int id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        public string email {
            get;
            set;
        }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(6,ErrorMessage = "Password must be at least 6 characters long")]
        [MaxLength(20,ErrorMessage = "Password cannot exceed 20 characters")]
        public string password {
            get;
            set;
        }

        public string? refreshToken { get; set; }

        public DateTime refreshTokenExpiry { get; set; }


    }
}
