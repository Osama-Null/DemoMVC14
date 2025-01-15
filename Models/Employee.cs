using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DemoMVC14.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC14.Models
{
    public class Employee : BaseProp
    {
        [DisplayName("ID")]
        //     Global unique identifier
        public Guid EmployeeId { get; set; } //PK
        [DisplayName("Name")]
        [Required(ErrorMessage = "*Enter employee name")]
        [MinLength(3, ErrorMessage = "*Min 3 char")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "*Enter employee email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Enter salary")]
        [Range(0, 100000, ErrorMessage = "*Out of range [0-100000]")]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage = "*Select gender")]
        public Genders Gender { get; set; }
        // It's better that it has it own class in Module in a folder named "Enums" and class name is "EnumCollections"
        public enum Genders
        {
            Male, Female
        }
        // ------------------- Join Employee & Department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
