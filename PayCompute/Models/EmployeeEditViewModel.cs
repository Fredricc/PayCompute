using PayCompute.Entity;
using System.ComponentModel.DataAnnotations;

namespace PayCompute.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Number is Required"),
            RegularExpression(@"^[A-Z],[3,3][0-9] {3}$")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "Employee First is Required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z] [a-zA-Z""'\s-]*$"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50), Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Employee Last is Required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z] [a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ". ").ToUpper()) + LastName;
            }
        }

        public string Gender { get; set; }
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Job Role is Required"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50), Display(Name = "Ni No/Pin")]
        [RegularExpression(@"^[A-CEGHJ-PR-TW-Z] {1} [A-CEGHJ-PR-TW-Z] {1} [0-9] {6} [A-D\S]$")]
        public string NationalInsuranceNoOrPin { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }
        [Required, StringLength(150), Display(Name = "Address")]
        public string Address { get; set; }
        [Required, StringLength(50), Display(Name = "City")]
        public string City { get; set; }
        [Required, StringLength(50), Display(Name = "Post Code")]
        public string Postcode { get; set; }
    }
}
