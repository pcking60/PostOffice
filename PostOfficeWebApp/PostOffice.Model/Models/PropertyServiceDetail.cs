using PostOffice.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Models
{
    [Table("PropertyServiceDetails")]
    public class PropertyServiceDetail : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal? Money { get; set; }
        
        public int TransactionDetailId { get; set; }
        public int PropertyServiceId { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("TransactionDetailId")]
        [Column(Order =1)]
        public virtual TransactionDetail TransactionDetail { get; set; }

        [ForeignKey("PropertyServiceId")]
        [Column(Order = 2)]
        public virtual PropertyService PropertyService { get; set; }

        [ForeignKey("PropertyServiceId")]
        [Column(Order = 3)]
        public virtual Service Service { get; set; }


    }
}