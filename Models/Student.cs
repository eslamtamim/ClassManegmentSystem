using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Student
    {
        
        [Key]
        [Display(Name = "ID")]
        public int StudentId { get; set; }

        public string? StudentNumber { get; set; }
        
        [Display(Name = "Full Name")]
        [MaxLength(50)]
        public string StudentName { get; set; }
        [Display(Name = "Grade year")]
        [Range(10,12)]
        public string StudentGrade { get; set; }
        
        [Display(Name = "National ID")]
        [MaxLength(14, ErrorMessage = "Not valied, ID must be 14 digits"), MinLength(14 , ErrorMessage = "Not valied, ID must be 14 digits")]
        public string StudentNationalID { get; set; }


        [Display(Name = "Phone Number")]
        [MaxLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)"), MinLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)")]
        public string StudentPhoneNumber { get; set; }
       
        [Display(Name = "Parent Phone Number")]
        [MaxLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)"), MinLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)")]
        public string StudentParentPhoneNumber { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime BithDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Creation")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? CreationDate { get; set; }

        public int CityId { get; set; }

        public City? city { get; set; }
        public ICollection<Teacher>? teachers { get; set; }
        public List<Class>? Classes { get; set; }
      

    }
}
