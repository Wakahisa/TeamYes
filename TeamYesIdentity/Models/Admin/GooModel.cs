using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class GooModel
    {
        public GooModel()
        {
            BooBoo = new List<BooModel>();
            FooFoo = new List<GooModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public ICollection<BooModel> BooBoo { get; set; }
        public virtual ICollection<GooModel> FooFoo { get; set; }
    }
}