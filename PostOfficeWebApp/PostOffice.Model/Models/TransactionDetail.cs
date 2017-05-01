using PostOffice.Model.Abstract;
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

        [Required]
        public int Quantity { get; set; }

        public decimal? Money { get; set; }

        [ForeignKey("TransactionID")]
        public virtual Transaction Transaction { get; set; }
    }
}