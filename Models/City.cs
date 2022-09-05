namespace ClassManegmentSystem.Models
{
    
    public class City
        {
            public string CityId { get; set; }
            public string CityName { get; set; }
            public List<Student> students { get; set; }
        }
    }

