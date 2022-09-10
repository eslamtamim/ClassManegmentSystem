using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManegmentSystem.Models
{
    
    public class Attendees
    {
        public int AttendeesId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public string ClassNumber { get; set; }

        [ForeignKey(" StudentId, TeacherId")]
        public Class Class { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Creation")]
        [DisplayFormat(DataFormatString = "{YYYY-MM-DD}")]
        public DateTime DateOfAttendeens { get; set; }

    }

}
