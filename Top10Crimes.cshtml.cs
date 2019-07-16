using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class Top10CrimesModel : PageModel  
    {  
        public List<Models.Crimes> CrimeList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"SELECT TOP 10 Crimes.IUCR,count (Crimes.IUCR) as NumofCrimes, 
PrimaryDesc,SecondaryDesc,
Round (count(Crimes.IUCR) *100.0 / sum(count(Crimes.IUCR)) over (),2 )as crimePercentage,
Round(sum (cast (Arrested as [int])) *100.0 / count(Crimes.IUCR) ,2) as arrestPercentage 
from Crimes
INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
Group by Crimes.IUCR,PrimaryDesc,SecondaryDesc
order by NumofCrimes desc;");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crimes c = new Models.Crimes();

							
							c.crimeID = System.Convert.ToString( row["IUCR"] );
                            c.numofCrimes = Convert.ToInt32(row["NumofCrimes"]);
                            c.Primarydesc = Convert.ToString(row["PrimaryDesc"]);
                            c.Secondarydesc = Convert.ToString(row["SecondaryDesc"]);
                            c.CrimePercentage = Convert.ToDouble(row["crimePercentage"]);
							c.ArrestPercentage = Convert.ToDouble(row["arrestPercentage"]);
                            
							crimes.Add(c);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
                       CrimeList = crimes;  
				    }
        }  
				
    }//class
}//namespace