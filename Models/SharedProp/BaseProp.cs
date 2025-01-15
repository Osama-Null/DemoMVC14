using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC14.Models.SharedProp
{
    public class BaseProp
    {
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Deleted")]
        public bool IsDeleted { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; }

    }
}
