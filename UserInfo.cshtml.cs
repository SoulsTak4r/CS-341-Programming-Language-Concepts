using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class UserInfoModel : PageModel  
    {  
				public List<Models.User> UserList { get; set; }
				public string Input { get; set; }
				public int NumUsers { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.User> users = new List<Models.User>();
					
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
							// lookup user by user id:
						  sql = string.Format(@"
SELECT Users.UserID, UserName, Occupation, Count(Rating) As NumReviews, AVG(Convert(Float,Rating)) As AvgRating
FROM Users
LEFT JOIN Reviews ON Users.UserID = Reviews.UserID
WHERE Users.UserID = {0}
GROUP BY Users.UserID, UserName, Occupation;
", id);
						}
						else
						{
							// lookup movie(s) by partial name match:
							input = input.Replace("'", "''");
							
							sql = string.Format(@"
SELECT Users.UserID, UserName, Occupation, Count(Rating) As NumReviews, AVG(Convert(Float,Rating)) As AvgRating
FROM Users
LEFT JOIN Reviews ON Users.UserID = Reviews.UserID
WHERE UserName = '{0}'
GROUP BY Users.UserID, UserName, Occupation;
", input);
						}

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.User u = new Models.User();

							u.UserID = Convert.ToInt32(row["UserID"]);
							u.UserName = Convert.ToString(row["UserName"]);
							u.Occupation = Convert.ToString(row["Occupation"]);
							u.NumReviews = Convert.ToInt32(row["NumReviews"]);

							// avg rating could be null if there are no reviews:
							if (row["AvgRating"] == System.DBNull.Value)
								u.AvgRating = 0.0;
							else
								u.AvgRating = Convert.ToDouble(row["AvgRating"]);

							users.Add(u);
						}
 					}//else

// SELECT Rating, Count(*) As NumReviews
// FROM Reviews
// WHERE UserID = {0}
// GROUP BY Rating
// ORDER BY Rating ASC;

          }
					catch(Exception ex)
					{
					  EX = ex; 
					}
					finally
					{
						UserList = users;
						NumUsers = users.Count;
				  }
				}
			
    }//class  
}//namespace