using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ClassManegmentSystem.Models
{
    
    public class City
    {
            public int CityId { get; set; }
        [Display(Name = "City Name")]
        public string CityName { get; set; }
            public List<Student> students { get; set; }
        }
    }

