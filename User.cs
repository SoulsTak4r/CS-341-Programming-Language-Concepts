//
// One movie
//

namespace program.Models
{

  public class User
	{
	
		// data members with auto-generated getters and setters:
	  public int UserID { get; set; }
		public string UserName { get; set; }
		public string Occupation { get; set; }
		public int NumReviews { get; set; }
		public double AvgRating { get; set; }
		
		// default constructor:
		public User()
		{ }
		
		// constructor:
		public User(int id, string name, string occupation, int numReviews, double avgRating)
		{
			UserID = id;
			UserName = name;
			Occupation = occupation;
			NumReviews = numReviews;
			AvgRating = avgRating;
		}
	
	}//class

}//namespace