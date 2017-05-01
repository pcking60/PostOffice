using PostOffice.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Models
{
    [Table("Transactions")]
    public class Transaction : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ServiceID { get; set; }
        

        public int TransactionTypeID { get; set; }

        [ForeignKey("TransactionTypeID")]
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }
       

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}