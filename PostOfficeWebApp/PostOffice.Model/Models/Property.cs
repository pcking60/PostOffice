using PostOffice.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostOffice.Model.Models
{
    [Table("Properties")]
    public class Property : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("nvarchar")]
        [StringLength(128)]
        public string Name { get; set; }

        public int PercentId { get; set; }

        [ForeignKey("PercentId")]
        public virtual Percent Percent { get; set; }
    }
}