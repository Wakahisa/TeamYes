using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class FooModel
    {
        public FooModel()
        {
            BooBoo = new List<BooModel>();
            GooGoo = new List<GooModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public List<BooModel> BooBoo { get; set; }
        public virtual ICollection<GooModel> GooGoo { get; set; }
    }
}