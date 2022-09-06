namespace ClassManegmentSystem.Models
{
    public class Class
    {

        public int StudentId { get; set; }
        public Student student { get; set; }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }


    }
}
