using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class MovieInfoModel : PageModel  
    {  
				public List<Models.Movie> MovieList { get; set; }
				public string Input { get; set; }
				public int NumMovies { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.Movie> movies = new List<Models.Movie>();
					
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
								// lookup movie by movie id:
								sql = string.Format(@"
	SELECT Movies.MovieID, MovieName, MovieYear, Count(Rating) AS NumReviews, AVG(CONVERT(float,Rating)) AS AvgRating
	FROM Movies
	LEFT JOIN Reviews ON Movies.MovieID = Reviews.MovieID
	WHERE Movies.MovieID = {0}
	GROUP BY Movies.MovieID, MovieName, MovieYear
	ORDER BY MovieName ASC;
	", id);
							}
							else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
	SELECT Movies.MovieID, MovieName, MovieYear, Count(Rating) AS NumReviews, AVG(CONVERT(float,Rating)) AS AvgRating
	FROM Movies
	LEFT JOIN Reviews ON Movies.MovieID = Reviews.MovieID
	WHERE Movies.MovieName LIKE '%{0}%'
	GROUP BY Movies.MovieID, MovieName, MovieYear
	ORDER BY MovieName ASC;
	", input);
							}

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables["TABLE"].Rows)
							{
								Models.Movie m = new Models.Movie();

								m.MovieID = Convert.ToInt32(row["MovieID"]);
								m.MovieName = Convert.ToString(row["MovieName"]);
								m.MovieYear = Convert.ToInt32(row["MovieYear"]);
								m.NumReviews = Convert.ToInt32(row["NumReviews"]);

								// avg rating could be null if there are no reviews:
								if (row["AvgRating"] == System.DBNull.Value)
									m.AvgRating = 0.0;
								else
									m.AvgRating = Convert.ToDouble(row["AvgRating"]);

								movies.Add(m);
							}
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  MovieList = movies;
					  NumMovies = movies.Count;
				  }
				}
			
    }//class  
}//namespace