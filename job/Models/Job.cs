using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace job.Models
{
    public class Job
    {
        public int Id { get; set; }
        [DisplayName("اسم الوظيفة")]
        public string JobTitle { get; set; }
        [DisplayName("وصف الوظيفة ")]
        public string JobContent { get; set; }
        [DisplayName("صورة الوظيفة")]
        public string JobImage { get; set; }
        [DisplayName("نوع الوظيفة")]
        public int CategoryId { set; get; }
        public string UserId { set; get; }
        public virtual Category Category { set; get; }
        public virtual ApplicationUser User { set; get; }
       // public virtual ICollection<ApplyForJob> ApplyJobs { set; get; }
    }
}