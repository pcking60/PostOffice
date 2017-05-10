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
        [Required]
       
        public int Quantity { get; set; }

        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
      
        public virtual IEnumerable<TransactionDetail> TransactionDetails { get; set; }

        [ForeignKey("UserId")]
        [Column(Order =1)]
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        
        
    }
}