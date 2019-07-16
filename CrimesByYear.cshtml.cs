using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesByYearModel : PageModel  
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
						string sql = string.Format(@"
SELECT count (Crimes.IUCR) as NumofCrimes, 
Crimes.Year 
from Crimes
Group by Crimes.Year
order by Crimes.Year asc;");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crimes c = new Models.Crimes();
                            c.numofCrimes = Convert.ToInt32(row["NumofCrimes"]);
							c.Year = Convert.ToInt32(row["Year"]);
							
                            
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