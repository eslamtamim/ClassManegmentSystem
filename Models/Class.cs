namespace ClassManegmentSystem.Models
{
    public class Class
    {

        public string StudentId { get; set; }
        public Student student { get; set; }
        public string TeacherId { get; set; }
        public Teacher teacher { get; set; }


    }
}
