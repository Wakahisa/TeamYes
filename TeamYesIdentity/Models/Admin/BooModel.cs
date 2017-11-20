using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class BooModel
    {
        public BooModel()
        {
            FooFoo = new List<FooModel>();
            GooGoo = new List<GooModel>();
        }

        [Key]
        [Required]
        public int ID { get; set; }
        public List<FooModel> FooFoo { get; set; }
        public ICollection<GooModel> GooGoo { get; set; }

    }
    
}