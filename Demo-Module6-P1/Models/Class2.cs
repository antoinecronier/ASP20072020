using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo_Module6_P1.Models
{
    [Table("Role")]
    public class Class2 : IDb
    {
        private long id;

        public String Name { get; set; }

        public long Id { get => this.id; set => this.id = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}