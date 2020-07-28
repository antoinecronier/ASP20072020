using Demo_Module6_P2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module6_P2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new DemoDbContext())
            {
                foreach (var item in db.Voitures)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
