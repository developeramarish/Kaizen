using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaizen.Domain.Entities
{
    public class ActivityService
    {
        [Required]
        public int ActivityCode { get; set; }
        [Required, MaxLength(15)]
        public string ServiceCode { get; set; }

        [ForeignKey("ServiceCode")]
        public Service Service { get; set; }
        [ForeignKey("ActivityCode")]
        public Activity Activity { get; set; }
    }
}
