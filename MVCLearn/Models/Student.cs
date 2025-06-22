using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLearn.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentNo { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public string Institution { get; set; }
        public int? SerialNumberId { get; set; }
        [ForeignKey("SerialNumberId")]
        public SerialNumber? SerialNumber { get; set; }
    }
}
