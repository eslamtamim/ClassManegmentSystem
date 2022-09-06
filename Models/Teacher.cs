using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Teacher's ID")]
        public string TeacherId { get; set; }
        [Display(Name = "Teacher's Name")]
        public string TeacherName { get; set; }
        [Display(Name = "Teacher's National ID")]
        public string TeacherNationalID { get; set; }
        [Display(Name = "Teacher's Phone Number")]
        public string TeacherPhoneNumber { get; set; }
        public string Age { get; set; }
        public string Subject { get; set; }
        public ICollection<Student>? students {get;set;}
        public List<Class>? Classes { get; set; }

    }
}

