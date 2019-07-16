
namespace crimes.Models
{

  public class Crimes
	{
	
		// data members with auto-generated getters and setters:
      
       
	   public string crimeID { get; set; }
         public string AreaName { get; set; }
        public int Area { get; set; }
        public int numofCrimes {get; set;}
		public string Primarydesc { get; set; }
        public string Secondarydesc { get; set; }
		public double  CrimePercentage { get; set; }
		public double ArrestPercentage { get; set; }
        public int Year { get; set; }
	
		// default constructor:
		public Crimes()
		{ }
		
		// constructor:
		public Crimes(string ci, int n, string p, string s , double cp, double ap)
		{
			
            crimeID = ci;
            numofCrimes = n;
            Primarydesc = p;
            Secondarydesc = s;
            CrimePercentage = cp;
            ArrestPercentage = ap;
		}
		
	}//class

}//namespace