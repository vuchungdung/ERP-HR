using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Candidate
{
    [Table("Awards")]
    public class Award : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CandidateId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Description { get; set; }
        public int _From { get; set; }
        public int _To { get; set; }
    }
}
