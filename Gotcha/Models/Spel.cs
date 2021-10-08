namespace Gotcha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Spel")]
    public partial class Spel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spel()
        {
            Spelers = new HashSet<Speler>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int gameID { get; set; }

        [StringLength(50)]
        public string gameName { get; set; }

        [StringLength(50)]
        public string safeZone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? beginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? endDate { get; set; }

        public TimeSpan? beginTime { get; set; }

        public TimeSpan? endTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Speler> Spelers { get; set; }
    }
}
