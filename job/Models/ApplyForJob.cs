using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job.Models
{
    public class ApplyForJob
    {

        public int Id { get; set; }
        public string Message { set; get; }
        public DateTime ApplyDate{ get; set; }
        
        public int JobId { set; get; }
        public string UserId { set; get; }

        public virtual Job job { set; get; }
        public virtual ApplicationUser user { set; get; }

    }
}