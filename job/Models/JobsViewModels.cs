using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job.Models
{
    public class JobsViewModels
    {
        public string JobTitle { get; set; }
        public IEnumerable<ApplyForJob> Items { set; get; }
    }
}