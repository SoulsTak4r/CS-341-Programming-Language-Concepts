/*main.cpp*/

//
// Netflix movie review analysis.
//
// << Fnu Nousheerwan >>
// U. of Illinois, Chicago
// CS 341: Fall 2018
// Project 02
//

#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <map>
#include <algorithm>
#include <string>
#include <chrono>
#include<iomanip>
#include<numeric>
#include<functional>

using namespace std;



class Movie{
	
private:	
	
	int 	    Movie_id;
	string      Movie_name;
	int		    Pub_year;
    vector<int> review_d; 
    int         r_size; 
public:
	
	Movie(int m_id, string m_name, int p)
	{
		Movie_id 	= m_id;
		Movie_name  = m_name;
		Pub_year 	= p;
	}
	
	int get_mid() const
	{
		return Movie_id;
	}
	
	void add_reviews(int v)
	{
		
		review_d.push_back(v);
	}
	
	string get_mname() const
	{
		return Movie_name;
	}
	
	int get_pyear() const
	{
		return Pub_year;	
	}
	
	int get_rsize()
	{
		r_size = review_d.size();
		
		return r_size; 
		
	}
	
	vector<int> getv()
	{
		return review_d;
	}
	
	double getAvgRating ()
	{
		double avg=-1.0,a;
		int sum;
		a = review_d.size();
		
		
		sum = accumulate(review_d.begin(),review_d.end(),0);
		
		
		avg = (sum/a); 
		
		return avg;
		
	}
	
	
};


class Review{
	
private:	
	
	int 	ReviewId;
	int 	MovieId;
	int     UserId;
	int     Rating;
	string  ReviewDate;
	
	
	
public:

	Review(int r_id, int mo_id, int u_id, int r, string r_d)
	{
		ReviewId   = r_id;
		MovieId    = mo_id;
		UserId     = u_id;
		Rating 	   = r;
		ReviewDate = r_d;	
	}
	
	int get_reviewId()const
	{
		return ReviewId;
	}
	
	int get_movieId() const
	{
		return MovieId;
	}
	
	int get_userId() const
	{
		return UserId;
	}
	
	int get_rating() const
	{
		return Rating;
	}
	
	string get_reviewD() const
	{
		return ReviewDate;
	}
	
	
	
};


void SortbyAvgRating(vector<Movie> & V)
{
	std::sort(V.begin(),V.end(), [](Movie V1, Movie V2){
    
    if (V1.getAvgRating()==V2.getAvgRating())
    {
       return V1.get_mname() < V2.get_mname();
    }
    else
    {
       return V1.getAvgRating() > V2.getAvgRating();  
    }
    
    
  });
  
}

/////////////////////////////////////////////////////////////////
// Vector2MovieidMap:Takes the input vector of Movie and builds 
// a map of movies ordered by movieId, and returns the map.


map<int, Movie> Vector2MovieIdMap(const vector<Movie>& movies)
{
	
   map<int, Movie> M;
  
  for (auto &x: movies)
  {
    auto keyvpair = pair<int,Movie>(x.get_mid(),x);
    M.insert(keyvpair);
  }
 
  return M;
}

/////////////////////////////////////////////////////////////////




vector<int> ret_stars( map<int, Movie>& M, int m_id)
{
	auto iter = M.find(m_id);
	vector<int> s;
	int s1=0,s2=0,s3=0,s4=0,s5=0;
	
  if(iter == M.end())
    cout << "review not found..." << endl;
  else 
  {
    
    auto val = iter->second.getv();
	
	
	for (auto &i: val)
	{
		if (i==1)
		{
			s1++;
		}
		else if (i==2)
		{
			s2++;
		}
		else if (i==3)
		{
			s3++;
		}
		else if (i==4)
		{
			s4++;
		}
		else if (i==5)
		{
			s5++;
		}
	}
	s.push_back(s1);
	s.push_back(s2);
	s.push_back(s3);
	s.push_back(s4);
	s.push_back(s5);
	
	return s;

  }
	
	
	
}



//////////////////////////////////////////////////////////////////
// LookupMovieid: looks up the given movieid in the given map, and
// outputs the movie data

void LookupMovieid(map<int, Movie>& M, int movieid)
{
  auto iter = M.find(movieid);
  if(iter == M.end())
    cout << "movie not found..." << endl;
  else 
  {
    
	auto key  = iter->first;
	auto val  = iter->second.get_mname();
	auto val1 = iter->second.get_pyear();
	auto val2 = iter->second.getAvgRating();
	auto val3 = iter->second.get_rsize();
	
	auto st = ret_stars(M,movieid);
	
	if (val == "Movie with no reviews!")
	{
		cout<<"Movie:	    "<<"'"<<val<<"'"<<endl;
		cout<<"Year:	     "<<val1<<endl;
		cout<<"Avg rating:  "<<0<<endl;
		cout<<"Num reviews: "<<val3<<endl; 
		cout<<" 1 star:     "<<0<<endl;
		cout<<" 2 star:     "<<0<<endl;
		cout<<" 3 star:     "<<0<<endl;
		cout<<" 4 star:     "<<0<<endl;
		cout<<" 5 star:     "<<0<<endl;
	}
	
	else
	{
		cout<<"Movie:	    "<<"'"<<val<<"'"<<endl;
		cout<<"Year:	     "<<val1<<endl;
		cout<<"Avg rating:  "<<val2<<endl;
		cout<<"Num reviews: "<<val3<<endl; 
		cout<<" 1 star:     "<<st[0]<<endl;
		cout<<" 2 star:     "<<st[1]<<endl;
		cout<<" 3 star:     "<<st[2]<<endl;
		cout<<" 4 star:     "<<st[3]<<endl;
		cout<<" 5 star:     "<<st[4]<<endl;
    }
  }
} 

//////////////////////////////////////////////////////////////////





////////////////////////////////////////////////////////////////////
// Vector2ReviewidMap:Takes the input vector of Review and builds 
// a map of reviews ordered by ReviewId, and returns the map.



map<int, Review> Vector2ReviewIdMap(const vector<Review>& reviews)
{
	
   map<int, Review> R;
  
  for (auto &x: reviews)
  {
    auto keyvpair1 = pair<int,Review>(x.get_reviewId(),x);
    R.insert(keyvpair1);
  }
 
  return R;
}
////////////////////////////////////////////////////////////////////////

string LookupMovieName(const map<int, Movie>& M, int m_id)
{
	auto iter = M.find(m_id);
  if(iter == M.end())
    cout << "review not found..." << endl;
  else 
  {
    
    auto val = iter->second.get_mname();
	
	return val;

  }
	
}


//////////////////////////////////////////////////////////////////
// LookupReviewid: looks up the given reviewid in the given map, and
// outputs the review data

void LookupReviewid( const map<int, Review>& R, const map<int, Movie>& M, int reviewid)
{
  auto iter = R.find(reviewid);
  if(iter == R.end())
    cout << "review not found..." << endl;
  else 
  {
    
    auto val = iter->second.get_movieId();
	
	string n = LookupMovieName(M,val);
	
	
	cout<<"Movie: "<<val<<" ("<<n<<")"<<endl;
	cout<<"Num stars: "<<iter->second.get_rating()<<endl;
	cout<<"User id:   "<<iter->second.get_userId()<<endl;
	cout<<"Date:      "<<iter->second.get_reviewD()<<endl; 
	
	
  }
} 

//////////////////////////////////////////////////////////////////






int main()
{
  cout << "** Netflix Movie Review Analysis **" << endl;
  cout << endl;

  //
  // input the filenames to process:
  //
  string moviesFN, reviewsFN;

  cin >> moviesFN;
  cin >> reviewsFN;

  cout<<endl;
  

  //
  // TODO:
  //

  ////////////////////////////////// Movie Data ////////////////////////////////////////////
  
  
   
  
  ifstream file(moviesFN);
  
  string line,movie_id,movie_name,pub_y;
  
  if (!file.good())
  {
    cout<<"File cannot be opened!"<<endl;
    return -1;
  }
  
  vector<Movie>  movie;
 
  
  getline(file,line);
  
  while (getline(file,line))
  {
    
    stringstream ss(line);
    
    // Parsing CSV file /////
    
      getline(ss,movie_id,',');
      getline(ss,movie_name,',');
      getline(ss,pub_y);
     
      
     
     Movie M(stoi(movie_id),movie_name,stoi(pub_y));
     
     // Inserting the values from file into vector 
     
     movie.push_back(M);
     
  }
  
  
  
  /////////////////////////////////////////////////////////////////////////////////////////
  
  
  
  ////////////////////////////////// Review Data /////////////////////////////////////////
  
  
  ifstream file1(reviewsFN);
  
  string line1,review_id,mov_id,user_id,rating,review_date;
  
  if (!file1.good())
  {
    cout<<"File cannot be opened!"<<endl;
    return -1;
  }
  
  vector<Review>  review;
  int i=0;
  
  getline(file1,line1);
   //auto  beginTime  =  std::chrono::steady_clock::now();
  
  
  while (getline(file1,line1))
  {
    
    stringstream ss(line1);
    
    // Parsing CSV file /////
    
      getline(ss,review_id,',');
      getline(ss,mov_id,',');
      getline(ss,user_id,',');
	  getline(ss,rating,',');
      getline(ss,review_date);
      
     
     Review R(stoi(review_id), stoi(mov_id), stoi(user_id), stoi(rating), review_date );
    
	 
	 
     // Inserting the values from file into vector 
     
     review.push_back(R);
	
	
     
  }
  
  // auto  endTime  =  std::chrono::steady_clock::now();
	// auto diff  =  endTime-beginTime;
	// cout  <<  "  [  time:  "
		  // <<  std::chrono::duration<double,  std::milli>(diff).count()
		  // <<  "  ms  ]"  <<  endl;
  
  
  for (auto &x: movie)
	 {
		 for (auto &y: review)
		 {	 
		  if (x.get_mid() == y.get_movieId())
		  {
			 x.add_reviews(y.get_rating());
		  }
		 }
	 }
  
 
  
     SortbyAvgRating(movie);
     int count=1;
	 
	
	 cout<<">> "<<"Top-10 Movies"<<" <<"<<endl;
	 cout<<endl;
  
    cout<<"Rank"<<"	ID"<<"	Reviews"<<"	Avg"<<"	Name"<<endl;
    for(auto &m : movie)
	 {
		 if (count!=11)
		 {
			 
			 cout<<count<<"."<<"	"<<m.get_mid()<<"	"<<m.get_rsize()<<"	"<<m.getAvgRating()<<"	"<<"'"<<m.get_mname()<<"'"<<endl;
			 count++;
		 }
	 }
	 
	 cout<<endl<<endl;
  
    // auto  endTime  =  std::chrono::steady_clock::now();
	// auto diff  =  endTime-beginTime;
	// cout  <<  "  [  time:  "
		  // <<  std::chrono::duration<double,  std::milli>(diff).count()
		  // <<  "  ms  ]"  <<  endl;
    
  //////////////////////////////////////// Building the Maps and Searching for the ID's /////////////////////////////////////////////////////////

  
  auto M = Vector2MovieIdMap(movie);
  auto R = Vector2ReviewIdMap(review);
  int v;
  string n;
  
  cout<<">> "<<"Movie and Review Information"<<" <<"<<endl;
  cout<<endl;
  int input;
  
  cout<<"Please enter a movie ID (<100,000), a review ID (>=100,000), 0 to stop > ";
  cin>>input;
  cout<<endl;
  
  while (input!=0)
  {
		
  
		if (((input < 100000) || (input >= 100000)) && (input!=0))
			{
				if (input < 0)
				{
					cout<<"**invalid id..."<<endl;
					cout<<endl;
				}
				else
				{
					if (input < 100000)
					{
						LookupMovieid(M,input);
						 cout<<endl;
					}
					else if (input >= 100000)
					{
						LookupReviewid(R,M,input);
						 cout<<endl;
					}
				}
			}
	    cout<<"Please enter a movie ID (<100,000), a review ID (>=100,000), 0 to stop > ";
		cin>>input;
        cout<<endl;
  }
  
  
  
  
  
  
  //
  // done:
  //
  cout << "** DONE! **" << endl << endl;

  return 0;
}
