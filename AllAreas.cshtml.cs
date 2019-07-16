using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AllAreasModel: PageModel  
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
Areas.Area,Areas.AreaName,
Round (count(Crimes.IUCR) *100.0 / sum(count(Crimes.IUCR)) over (),2 )as crimePercentage
from Crimes
INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
INNER JOIN Areas ON Crimes.Area = Areas.Area
Group by Areas.Area , AreaName
order by AreaName asc
;");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        var rows = ds.Tables["TABLE"].Rows; 
                        //System.Console.WriteLine(rows.Count);  
                        
						foreach (DataRow row in rows)
						{
							Models.Crimes c2 = new Models.Crimes();
							
							
                            c2.numofCrimes = Convert.ToInt32(row["NumofCrimes"]);
                            c2.Area = Convert.ToInt32(row["Area"]);
                            c2.AreaName = Convert.ToString(row["AreaName"]);
                           
                            c2.CrimePercentage = Convert.ToDouble(row["crimePercentage"]);
                            
							crimes.Add(c2);
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