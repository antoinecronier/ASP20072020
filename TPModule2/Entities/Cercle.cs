using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2.Entities
{
    public class Cercle : Forme
    {
		private int rayon;
		private double? perimetre;

		public int Rayon
		{
			get { return rayon; }
			set 
			{ 
				rayon = value;
				this.perimetre = 2 * Math.PI * Rayon;
			}
		}

		public override double Aire => Math.PI * Math.Pow(Rayon,2);

		public override double? Perimetre
		{
			get { return this.perimetre; }
		}

		public override string ToString()
		{
			return "Cercle de rayon " + Rayon + "\n" + base.ToString();
		}
	}
}
