using PostOffice.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Models
{
    [Table("TransactionDetails")]
    public class TransactionDetail : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int TransactionID { get; set; }

        public int ServiceDetailId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal? Money { get; set; }

        [ForeignKey("TransactionID")]
        public virtual Transaction Transaction { get; set; }

        [ForeignKey("ServiceDetailId")]
        public virtual IEnumerable<ServiceDetail> ServiceDetails { get; set; }
    }
}