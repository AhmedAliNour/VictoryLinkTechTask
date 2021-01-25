using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VictoryLinkTechTask.Domain.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int MobileNumber { get; set; }
        [MaxLength(50)]
        public string Action { get; set; }
        public bool Handled { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? HandlingDate { get; set; }
    }
}