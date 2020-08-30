using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Cadidate
{
    [Table("CadidateApplyHistories")]
    public class CadidateApplyHistory : BaseEntity
    {
        [Key]
        public int CadidateId { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Company { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Position { get; set; }
    }
}
