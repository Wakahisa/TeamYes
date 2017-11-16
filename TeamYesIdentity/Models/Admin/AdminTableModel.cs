using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models.Admin
{
    public class AdminTableModel
    {
        [Key]
        [Required]
        public int TableID { get; set; }

        public List<string> TableNames { get; set; }
    }
}