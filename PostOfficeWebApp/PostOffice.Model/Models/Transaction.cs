using PostOffice.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Abstract
{
    [Table("Transactions")]
    public class Transaction : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ServiceID { get; set; }

        [Required]
        public int StaffID { get; set; }

        public int TransactionTypeID { get; set; }

        [ForeignKey("TransactionTypeID")]
        public virtual TransactionType TransactionType { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }

        [ForeignKey("StaffID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}