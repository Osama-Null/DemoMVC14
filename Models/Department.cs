using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DemoMVC14.Models.SharedProp;

namespace DemoMVC14.Models
{
    public class Department : BaseProp
    {
        [DisplayName("ID")]
        //     Global unique identifier
        public int DepartmentId { get; set; } //PK
        [DisplayName("Department Name")]
        [Required(ErrorMessage = "*Enter department name")]
        [MinLength(3, ErrorMessage = "*Min 3 char")]
        public string Name { get; set; }
    }
}
