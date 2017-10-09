using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace startAppA1.Models.Admin
{
    public class AdminTableModel
    {
        [Key]
        public int TableID { get; set; }
    }
}