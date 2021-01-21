using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionsCalculator.DTOs
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Please enter first name..")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter middle name..")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter last name..")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter you national ID")]
        [Display(Name = "National ID")]
        public string NationalId { get; set; }

        public string Governorate { get; set; }

        [Display(Name = "Home Mailing Address")]
        public string HomeMailingAddress { get; set; }

        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }

        [Display(Name = "Home Number")]
        public string HomeNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Landline { get; set; }

        public virtual EmployeePayment EmployeePayment { get; set; }
    }
}
