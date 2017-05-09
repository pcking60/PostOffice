using PostOffice.Model.Abstract;
using System;
using System.Collections.Generic;
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

        public int ServiceId { get; set; }

        public string UserId { get; set; }

        public int TransactionDetailId { get; set; }

        [ForeignKey("TransactionDetailId")]
        [Column(Order =1)]
        public virtual IEnumerable<TransactionDetail> TransactionDetails { get; set; }

        [ForeignKey("UserId")]
        [Column(Order = 2)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}