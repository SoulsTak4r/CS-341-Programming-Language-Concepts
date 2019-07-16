using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AllCodesModel: PageModel  
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
SELECT  Crimes.IUCR,count (Crimes.IUCR) as NumofCrimes , 
PrimaryDesc,SecondaryDesc
from Crimes
RIGHT OUTER JOIN Codes ON  Crimes.IUCR = Codes.IUCR
Group by Crimes.IUCR,PrimaryDesc,SecondaryDesc
order by PrimaryDesc asc,SecondaryDesc asc
;");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        var rows = ds.Tables["TABLE"].Rows; 
                        //System.Console.WriteLine(rows.Count);  
                        
						foreach (DataRow row in rows)
						{
							Models.Crimes c2 = new Models.Crimes();
							
							c2.crimeID = System.Convert.ToString( row["IUCR"] );
                            c2.numofCrimes = Convert.ToInt32(row["NumofCrimes"]);
                            c2.Primarydesc = Convert.ToString(row["PrimaryDesc"]);
                            c2.Secondarydesc = Convert.ToString(row["SecondaryDesc"]);
                            c2.CrimePercentage = 0.0;
							c2.ArrestPercentage = 0.0;
                            
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