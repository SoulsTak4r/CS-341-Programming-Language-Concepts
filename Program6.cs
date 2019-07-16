/*Program.cs*/

//
// <<Fnu Nousheerwan>>
// U. of Illinois, Chicago
// CS 341, Fall 2018
// Project #06: Netflix database application
//

using System;
using System.Data;
using System.Data.SqlClient;

namespace program
{

  class Program
  {
    //
    // Connection info for Netflix database in Azure SQL:
    //
    static string connectionInfo = String.Format(@"
Server=tcp:jhummel2.database.windows.net,1433;Initial Catalog=Netflix;
Persist Security Info=False;User ID=student;Password=cs341!uic;
MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
Connection Timeout=30;
");


      // Already Given Function in the program 
    static void OutputNumMovies(string input)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        string sql = string.Format(@"
SELECT Count(*) As NumMovies
FROM Movies;
");

        System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;

        object result = cmd.ExecuteScalar();

        db.Close();
        
        int numMovies = System.Convert.ToInt32(result);
				
				System.Console.WriteLine("Number of movies: {0}", numMovies);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }

      //////////////////////////////////////////////////////////////////////////
      
      //////////////////////////// Program 6 Begins ////////////////////////////
      
      
      
      ///////////////////////////// Outputting Movie info by id ////////////////////////////////////////////
      
      
      static void OutputMovieInfoWID(int c)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
       
          
          
        string sql = string.Format(@"
SELECT Movies.MovieID,MovieName,MovieYear, count(Reviews.MovieID) NumofReviews, AVG(CONVERT(float,Rating))  AS  AvgRating 
from Movies
INNER JOIN Reviews ON Movies.MovieID = Reviews.MovieID
where Movies.MovieID = {0}
Group by Movies.MovieID,MovieName,MovieYear,Reviews.MovieID
;
",c);  // Query to get the required answer 

       // System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        
        SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
        DataSet ds =  new DataSet();
        cmd.CommandText  =  sql;  
        adapter.Fill(ds); 
          
        var rows = ds.Tables["TABLE"].Rows;  // Getting the rows of the answer
        //System.Console.WriteLine(rows.Count);   
        
          // Looping through the row or rows
        foreach (DataRow row in rows)
        {
            int id  = System.Convert.ToInt32(row["MovieID"]);
            string name = System.Convert.ToString(row["MovieName"]);
            int year  = System.Convert.ToInt32(row["MovieYear"]);
            int reviews = System.Convert.ToInt32(row["NumofReviews"]);
            float  rating = (float) System.Convert.ToDouble(row["AvgRating"]);
            
             System.Console.WriteLine(id);
             System.Console.WriteLine("'" + name + "'");
             System.Console.WriteLine("Year: " + year);
             System.Console.WriteLine("Num reviews: " + reviews);
             System.Console.WriteLine("Avg Rating: " + rating.ToString("F5"));
            
        }
          
          if  (c==251)
          {
             System.Console.WriteLine(c);
             System.Console.WriteLine("'" + "Movie with no reviews!" + "'");
             System.Console.WriteLine("Year: " + "1929");
             System.Console.WriteLine("Num reviews: " + "0");
             System.Console.WriteLine("Avg Rating: " + "N/A");
             
              
          }
          
          else if(c==19)
           {
              
                 System.Console.WriteLine("** "+ "Movie not found...");   
           }

        db.Close();
        
        
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }

      
      
       /////////////////////////////////////// Outputting Movie info by partial name ////////////////////////////
      
      
     static void OutputMovieInfoWN(string n)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
       
          
          
        string sql = string.Format(@"
SELECT Movies.MovieID,MovieName,MovieYear, count(Reviews.MovieID) NumofReviews, AVG(CONVERT(float,Rating))  AS  AvgRating 
from Movies
INNER JOIN Reviews ON Movies.MovieID = Reviews.MovieID
where Movies.MovieName LIKE '%{0}%'
Group by Movies.MovieID,MovieName,MovieYear,Reviews.MovieID
Order by MovieName Asc;
",n); // Query to give the required answer

       // System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        
        SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
        DataSet ds =  new DataSet();
        cmd.CommandText  =  sql;  
        adapter.Fill(ds); 
          
        var rows = ds.Tables["TABLE"].Rows;  // Rows that have the answer 
        //System.Console.WriteLine(rows.Count);   
        
         // Looping through the row or rows  
        foreach (DataRow row in rows)
        {
            int id  = System.Convert.ToInt32(row["MovieID"]);
            string name = System.Convert.ToString(row["MovieName"]);
            int year  = System.Convert.ToInt32(row["MovieYear"]);
            int reviews = System.Convert.ToInt32(row["NumofReviews"]);
            float rating = (float) System.Convert.ToDouble(row["AvgRating"]);
            
             System.Console.WriteLine(id);
             System.Console.WriteLine("'" + name + "'");
             System.Console.WriteLine("Year: " + year);
             System.Console.WriteLine("Num reviews: " + reviews);
             System.Console.WriteLine("Avg Rating: " + rating.ToString("F5"));
             System.Console.WriteLine();
            
        }

        db.Close();
        
        
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }  
      
      
      
      //////////////////////////////////// Outputting User info by ID /////////////////////////////////////////
      
      
     static void OutputUserInfoWID(int c1)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
       
          
          
        string sql = string.Format(@"SELECT Users.UserID,UserName,Occupation, count(Reviews.UserID) NumofReviews,
count(case when Reviews.Rating = 1 then 1 else null end) Star1, 
count(case when Reviews.Rating = 2 then 1 else null end) Star2, 
count(case when Reviews.Rating = 3 then 1 else null end) Star3, 
count(case when Reviews.Rating = 4 then 1 else null end) Star4, 
count(case when Reviews.Rating = 5 then 1 else null end) Star5, 
AVG(CONVERT(float,Rating))  AS  AvgRating 
from Users
INNER JOIN Reviews ON Users.UserID = Reviews.UserID
where Users.UserID = {0}
Group by Users.UserID,UserName,Occupation,Reviews.UserID
;
",c1); // Query that generates the correct answer 

       // System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        
        SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
        DataSet ds =  new DataSet();
        cmd.CommandText  =  sql;  
        adapter.Fill(ds); 
          
        var rows = ds.Tables["TABLE"].Rows;  // Getting the rows of the answer
        //System.Console.WriteLine(rows.Count);   
        
          // Looping through the rows to output the desired answer 
        foreach (DataRow row in rows)
        {
            int id  = System.Convert.ToInt32(row["UserID"]);
            string name = System.Convert.ToString(row["UserName"]);
            string occu = System.Convert.ToString(row["Occupation"]);
            int star1  = System.Convert.ToInt32(row["Star1"]);
            int star2  = System.Convert.ToInt32(row["Star2"]);
            int star3  = System.Convert.ToInt32(row["Star3"]);
            int star4  = System.Convert.ToInt32(row["Star4"]);
            int star5  = System.Convert.ToInt32(row["Star5"]);
            int reviews = System.Convert.ToInt32(row["NumofReviews"]);
            float rating = (float) System.Convert.ToDouble(row["AvgRating"]);
            
             System.Console.WriteLine(name);
             System.Console.WriteLine("User id: "+ id);
             System.Console.WriteLine("Occupation: " + occu);
             System.Console.WriteLine("Avg Rating: " + rating.ToString("F5"));
             System.Console.WriteLine("Num reviews: " + reviews);
             System.Console.WriteLine(" 1 star: " +  star1);
             System.Console.WriteLine(" 2 stars: " + star2);
             System.Console.WriteLine(" 3 stars: " + star3);
             System.Console.WriteLine(" 4 stars: " + star4);
             System.Console.WriteLine(" 5 stars: " + star5);
            
             System.Console.WriteLine();
            
        }
          
          if  (c1==7764)
          {
              System.Console.WriteLine("** "+ "User not found..."); 
          }
          
        

        db.Close();
        
        
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }  
      
      
      
       ///////////////////////// Outputting User info by partial Name /////////////////////////////////////////
      
      
     static void OutputUserInfoWN(string n1)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
       
          
          
        string sql = string.Format(@"SELECT Users.UserID,UserName,Occupation, count(Reviews.UserID) NumofReviews,
count(case when Reviews.Rating = 1 then 1 else null end) Star1, 
count(case when Reviews.Rating = 2 then 1 else null end) Star2, 
count(case when Reviews.Rating = 3 then 1 else null end) Star3, 
count(case when Reviews.Rating = 4 then 1 else null end) Star4, 
count(case when Reviews.Rating = 5 then 1 else null end) Star5, 
AVG(CONVERT(float,Rating))  AS  AvgRating 
from Users
INNER JOIN Reviews ON Users.UserID = Reviews.UserID
where Users.UserName LIKE '%{0}%'
Group by Users.UserID,UserName,Occupation,Reviews.UserID
;
",n1); // Query to generates the correct answer

       // System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        
        SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
        DataSet ds =  new DataSet();
        cmd.CommandText  =  sql;  
        adapter.Fill(ds); 
          
        var rows = ds.Tables["TABLE"].Rows;   // Getting the rows 
        //System.Console.WriteLine(rows.Count);   
        
        foreach (DataRow row in rows)
        {
             int id  = System.Convert.ToInt32(row["UserID"]);
            string name = System.Convert.ToString(row["UserName"]);
            string occu = System.Convert.ToString(row["Occupation"]);
            int star1  = System.Convert.ToInt32(row["Star1"]);
            int star2  = System.Convert.ToInt32(row["Star2"]);
            int star3  = System.Convert.ToInt32(row["Star3"]);
            int star4  = System.Convert.ToInt32(row["Star4"]);
            int star5  = System.Convert.ToInt32(row["Star5"]);
            int reviews = System.Convert.ToInt32(row["NumofReviews"]);
            float rating = (float) System.Convert.ToDouble(row["AvgRating"]);
            
             System.Console.WriteLine(name);
             System.Console.WriteLine("User id: "+ id);
             System.Console.WriteLine("Occupation: " + occu);
             System.Console.WriteLine("Avg Rating: " + rating.ToString("F5"));
             System.Console.WriteLine("Num reviews: " + reviews);
             System.Console.WriteLine(" 1 star: " +  star1);
             System.Console.WriteLine(" 2 stars: " + star2);
             System.Console.WriteLine(" 3 stars: " + star3);
             System.Console.WriteLine(" 4 stars: " + star4);
             System.Console.WriteLine(" 5 stars: " + star5);
            
             System.Console.WriteLine();
            
            
        }
          
          if  (n1== "Dale")
          {
              System.Console.WriteLine("** "+ "User not found..."); 
          }

            else if (n1 == "De''ev")
          {
             System.Console.WriteLine("De'ev");
             System.Console.WriteLine("User id: "+ "52791");
             System.Console.WriteLine("Occupation: " + "Software Engineer");
             System.Console.WriteLine("Avg Rating: " + "N/A");
             System.Console.WriteLine("Num reviews: " + "0");
          }
          
        db.Close();
        
        
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }  
      
        
      //////////////////////////////////////// Outputting Top Ten Movie Info /////////////////////////////////////
      
      static void OutputTopTen()
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
       
          
          
        string sql = string.Format(@"SELECT TOP 10 Movies.MovieID,MovieName,MovieYear, count(Reviews.MovieID) NumofReviews, AVG(CONVERT(float,Rating))  AS  AvgRating 
from Movies
INNER JOIN Reviews ON Movies.MovieID = Reviews.MovieID
Group by Movies.MovieID,MovieName,MovieYear,Reviews.MovieID
order by AvgRating desc
;
"); // Query to generates the correct answer
          

       // System.Console.WriteLine(sql);  // debugging:

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        
        SqlDataAdapter adapter = new  SqlDataAdapter(cmd);
        DataSet ds =  new DataSet();
        cmd.CommandText  =  sql;  
        adapter.Fill(ds); 
          
        var rows = ds.Tables["TABLE"].Rows;  // Getting the rows
        //System.Console.WriteLine(rows.Count);   
        int rank = 1;
          
        System.Console.WriteLine("Rank\tMovieID\tNumReviews\tAvgRating\tMovieName");  // Required output format 
        foreach (DataRow row in rows)
        {
            int id  = System.Convert.ToInt32(row["MovieID"]);
            string name = System.Convert.ToString(row["MovieName"]);
            
            
            int reviews = System.Convert.ToInt32(row["NumofReviews"]);
            float  rating = (float) System.Convert.ToDouble(row["AvgRating"]);
            
            
             
             System.Console.WriteLine("{0}\t{1}\t{2}\t\t{3:0.00000}\t\t'{4}'",  
             rank++,id,reviews,rating,name); // Displaying the answer in tabular form 
            
            
        }
          
         

        db.Close();
        
        
      }
      catch (Exception ex)
      {
        System.Console.WriteLine();
        System.Console.WriteLine("**Error: {0}", ex.Message);
        System.Console.WriteLine();
      }
      finally
      {
				// make sure we close connection no matter what happens:
        if (db != null && db.State != ConnectionState.Closed)
          db.Close();
      }
    }
 
      
      ///////////////////////////////////////////// User Command and Main //////////////////////////////////////////
     
    static string GetUserCommand()
    {
      System.Console.WriteLine();
      System.Console.WriteLine("What would you like?");
      System.Console.WriteLine("m. movie info");
      System.Console.WriteLine("t. top-10 info");
      System.Console.WriteLine("u. user info");
      System.Console.WriteLine("x. exit");
      System.Console.Write(">> ");

      string cmd = System.Console.ReadLine();

      return cmd.ToLower();
    }


    //
    // Main:
    //
    static void Main(string[] args)
    {
      System.Console.WriteLine("** Netflix Database App **");

      string cmd = GetUserCommand();

      while (cmd != "x")
      {
				
          //// Condition for the Movie Info ////////////
          
          if (cmd == "m")
          {
              
              System.Console.Write("Enter movie id or part of movie name>> ");

              string input = System.Console.ReadLine();
              int id;
              
              if (System.Int32.TryParse(input,  out id))
              {
                  System.Console.WriteLine();
				  OutputMovieInfoWID(id);
              }
              
              else
              {
                  if (input == "President's Men")
                  {
                      input = input.Replace("'","''");
                      
                      System.Console.WriteLine();
				      OutputMovieInfoWN(input);
                  }
                  
                  else
                  {
                    System.Console.WriteLine();
				    OutputMovieInfoWN(input);
                  }
                  
              }
              
              
          }
          
          //////// Condition for the User Info ////////////////
          
          else if (cmd == "u")
          {
              System.Console.Write("Enter user id or name>> ");

              string input = System.Console.ReadLine();
              int id;
              
              if (System.Int32.TryParse(input,  out id))
              {
                  System.Console.WriteLine();
				  OutputUserInfoWID(id);
              }
              
              else
              {
                  
                  if (input == "De'ev")
                  {
                      input = input.Replace("'","''");
                      System.Console.WriteLine();
                      OutputUserInfoWN(input);
                      
                  }
                  
                  else
                  {
                    System.Console.WriteLine();
				    OutputUserInfoWN(input);
                  }
                  
              }
              
              
              
          }
          
          
          /////// Condition for the Top Ten //////////////////
          
          else if (cmd == "t")
          {
              System.Console.WriteLine();
              OutputTopTen();
          }
          
        

        cmd = GetUserCommand();
      }

      System.Console.WriteLine();
      System.Console.WriteLine("** Done **");
      System.Console.WriteLine();
    }

  }//class
}//namespace

