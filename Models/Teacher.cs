using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherNationalID { get; set; }
        public string TeacherPhoneNumber { get; set; }
        public string Age { get; set; }
        public string Subject { get; set; }
        public ICollection<Student>? students {get;set;}
        public List<Class>? Classes { get; set; }

    }
}

