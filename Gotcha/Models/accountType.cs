namespace Gotcha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("accountType")]
    public partial class accountType
    {
        [Key]
        [Column("accountType")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int accountType1 { get; set; }

        [StringLength(50)]
        public string accountname { get; set; }
    }
}
