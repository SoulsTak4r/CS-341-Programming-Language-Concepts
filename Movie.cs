//
// One movie
//

namespace program.Models
{

  public class Movie
	{
	
		// data members with auto-generated getters and setters:
	  public int MovieID { get; set; }
		public string MovieName { get; set; }
		public int MovieYear { get; set; }
		public int NumReviews { get; set; }
		public double AvgRating { get; set; }
	
		// default constructor:
		public Movie()
		{ }
		
		// constructor:
		public Movie(int id, string name, int year, int numReviews, double avgRating)
		{
			MovieID = id;
			MovieName = name;
			MovieYear = year;
			NumReviews = numReviews;
			AvgRating = avgRating;
		}
		
	}//class

}//namespace