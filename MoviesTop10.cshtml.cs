using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class MoviesTop10Model : PageModel  
    {  
        public List<Models.Movie> MovieList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Movie> movies = new List<Models.Movie>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
	SELECT TOP 10 Reviews.MovieID, MovieName, MovieYear, Count(Rating) AS NumReviews, AVG(CONVERT(float,Rating)) AS AvgRating
	FROM Reviews
	INNER JOIN Movies ON Reviews.MovieID = Movies.MovieID
	GROUP BY Reviews.MovieID, MovieName, MovieYear
	ORDER BY AvgRating DESC, MovieName ASC;
	");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Movie m = new Models.Movie();

							m.MovieID = Convert.ToInt32(row["MovieID"]);
							m.MovieName = Convert.ToString(row["MovieName"]);
							m.MovieYear = Convert.ToInt32(row["MovieYear"]);
							m.NumReviews = Convert.ToInt32(row["NumReviews"]);
							m.AvgRating = Convert.ToDouble(row["AvgRating"]);

							movies.Add(m);
						}
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            MovieList = movies;  
				  }
        }  
				
    }//class
}//namespace