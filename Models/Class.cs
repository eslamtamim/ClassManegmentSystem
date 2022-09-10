using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClassManegmentSystem.Models
{
    public class Class
    {

        public int StudentId { get; set; }
        public Student student { get; set; }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }

        public string ClassSubject { get; set; }
        
        public string ClassNumber { get; set; }
        public string ClassName { get; set; }

        public List<Attendees>? Attendees { get; set; }

        

    }
    
}
