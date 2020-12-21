using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    [Table("Applies")]
    public class Apply : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }

        [Column(TypeName="datetime")]
        public DateTime ApplyDate { get; set; }
    }
}
