using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Student
    {
        
        [Key]
        [Display(Name = "ID")]
        public string StudentId { get; set; }
        public string? StudentNumber { get; set; }
        [Display(Name = "Full Name")]

        public string StudentName { get; set; }
        [Display(Name = "Grade year")]

        public string StudentGrade { get; set; }
        [Display(Name = "Natiotal ID")]

        public string StudentNationalID { get; set; }
        [Display(Name = "Phone Number")]

        public string StudentPhoneNumber { get; set; }
        [Display(Name = "Parent Phone Number")]
        public string StudentParentPhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime BithDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Creation")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? CreationDate { get; set; }

        public string CityId { get; set; }
        public City? city { get; set; }
        public ICollection<Teacher>? teachers { get; set; }
        public List<Class>? Classes { get; set; }

    }
}
