using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo_Module6_P1.Models
{
    [Table("User")]
    public class Class1 : IDb
    {
        private long id;

        public String Firstname { get; set; }

        public String Lastname { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public double DistanceInSpace { get; set; }

        public decimal Money { get; set; }

        public uint Size { get; set; }

        public float Weight { get; set; }

        public virtual List<String> Hobbies { get; set; }

        public virtual List<Class2> Class2s { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DayOfBirth { get; set; }

        public long Id { get => this.id; set => this.id = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}