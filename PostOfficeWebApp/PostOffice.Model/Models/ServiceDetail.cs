using PostOffice.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Models
{
    [Table("ServiceDetails")]
    public class ServiceDetail : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ServiceId { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("ServiceId")]
        [Column(Order = 1)]
        public virtual Service Service { get; set; }

        [ForeignKey("PropertyId")]
        [Column(Order = 2)]
        public virtual Property Property { get; set; }
    }
}