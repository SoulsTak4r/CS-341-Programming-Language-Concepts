using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreaInfoForCrimeModel : PageModel  
    {  
				public List<Models.Crimes> CrimeList { get; set; }
				public Exception EX { get; set; }
				public string Input { get; set; }
				
			
  
        public void OnGet(string input)  
        {  
				  List<Models.Crimes> crimes = new List<Models.Crimes>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If so, we do a lookup:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							int id;
							string sql;

							if (System.Int32.TryParse(input, out id))
							{
								// lookup crime of area by crime id:
								sql = string.Format(@"SELECT TOP 10 Crimes.IUCR,count (Crimes.IUCR) as NumofCrimes, 
PrimaryDesc,SecondaryDesc,Areas.AreaName,
Round (count(Crimes.IUCR) *1.0 / sum(count(Crimes.IUCR)) over (),2 )as crimePercentage,
Round(sum (cast (Arrested as [int])) *100.0 / count(Crimes.IUCR) ,2) as arrestPercentage 
from Crimes
INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
INNER JOIN Areas ON Crimes.Area = Areas.Area
where Areas.Area = {0}
Group by Crimes.IUCR,PrimaryDesc,SecondaryDesc,AreaName
order by NumofCrimes desc;
	", id);
							
                            
                            }
                            
                            else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
	SELECT TOP 10 Crimes.IUCR,count (Crimes.IUCR) as NumofCrimes, 
PrimaryDesc,SecondaryDesc,Areas.AreaName,
Round (count(Crimes.IUCR) *1.0 / sum(count(Crimes.IUCR)) over (),2 )as crimePercentage,
Round(sum (cast (Arrested as [int])) *100.0 / count(Crimes.IUCR) ,2) as arrestPercentage 
from Crimes
INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
INNER JOIN Areas ON Crimes.Area = Areas.Area
where Areas.AreaName LIKE '%{0}%'
Group by Crimes.IUCR,PrimaryDesc,SecondaryDesc,AreaName
order by NumofCrimes desc;
	", input);
							}
                            
							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables["TABLE"].Rows)
							{
								Models.Crimes c1 = new Models.Crimes();

							
                                c1.crimeID = System.Convert.ToString( row["IUCR"] );
                                c1.numofCrimes = Convert.ToInt32(row["NumofCrimes"]);
                                c1.Primarydesc = Convert.ToString(row["PrimaryDesc"]);
                                c1.Secondarydesc = Convert.ToString(row["SecondaryDesc"]);
                                c1.CrimePercentage = Convert.ToDouble(row["crimePercentage"]);
                                c1.ArrestPercentage = Convert.ToDouble(row["arrestPercentage"]);
                            
                                crimes.Add(c1);
							}
						}//else
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