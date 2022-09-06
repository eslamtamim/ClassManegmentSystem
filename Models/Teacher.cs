using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Teacher's ID")]
        public int TeacherId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Teacher's Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Teacher's National ID")]
        [MaxLength(14, ErrorMessage = "Not valied, ID must be 14 digits"), MinLength(14, ErrorMessage = "Not valied, ID must be 14 digits")]
        public string TeacherNationalID { get; set; }

        [Display(Name = "Teacher's Phone Number")]
        [MaxLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)"), MinLength(11, ErrorMessage = "Phone number must be 11 digits, don't put (+20)")]
        public string TeacherPhoneNumber { get; set; }

        [Range(21,70)]
        public string Age { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }

        public ICollection<Student>? students {get;set;}
        public List<Class>? Classes { get; set; }

    }
}

