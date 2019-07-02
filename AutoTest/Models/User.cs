using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AutoTest.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(256, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "Email")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximun {1} characters")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        [Display(Name = "UserName")]
        public string FullName { get{ return string.Format("{0} {1}", FirstName, LastName); } }


        public virtual ICollection<TestHeader> TestHeaders { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }


    }
}