using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    class JobDescription : BaseEntity
    {
        public int JobId { get; set; }
        public string Description { get; set; }
        public string[] SkillId { get; set; }
        public int Level { get; set; }
    }
}
