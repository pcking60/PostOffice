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
        
        //public int ServiceId { get; set; }       

        //[ForeignKey("ServiceId")]
        //public virtual Service Service { get; set; }
    }
}