using System.ComponentModel.DataAnnotations;

namespace neosoftCrudApis.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Department { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
