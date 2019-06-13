/*main.cpp*/

//
// Grade Analysis program in modern C++.
//
// << YOUR NAME >>
// U. of Illinois, Chicago
// CS 341: Fall 2018
// Project 01
//

#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;


class Course
{
  
public:
  
  string   dept;
  int      Number;
  string   titl;
  int      A;
  int      B;
  int      C;
  int      D;
  int      F;
  int      I;
  int      NR;
  int      S;
  int      U;
  int      W;
  string   instruct;
  




 Course (string dep, int num, string ti, int a, int b, int c, int d, int f, int i, int nr, int s, int u, int w, string ins )
 : dept(dep), Number(num), titl(ti), A(a), B(b), C(c), D(d), F(f), I(i), NR(nr), S(s), U(u), W(w), instruct(ins) { }
 
 
 
 
  bool comparison(string Main, string match )
  {
    if (Main.find(match)==0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
 
 
 
 
 
};


int main()
{
  string  filename;

  cin >> filename;
  cout<< filename<<endl;
  cout << endl;



  ifstream file(filename);
  
  string line,Dept,Number1,title,A1,B1,C1,D1,F1,I1,NR1,S1,U1,W1,Instructor;
  
  if (!file.good())
  {
    cout<<"File cannot be opened!"<<endl;
    return -1;
  }

  // Putting data from the file into the vector

  vector<Course> courses;
  
  getline(file,line);
  
  while (getline(file,line))
  {
    
    stringstream ss(line);
    
    // Parsing CSV file /////
    
      getline(ss,Dept,',');
      getline(ss,Number1,',');
      getline(ss,title,',');
      getline(ss,A1,',');
      getline(ss,B1,',');
      getline(ss,C1,',');
      getline(ss,D1,',');
      getline(ss,F1,',');
      getline(ss,I1,',');
      getline(ss,NR1,',');
      getline(ss,S1,','); 
      getline(ss,U1,',');
      getline(ss,W1,',');
      getline(ss,Instructor);
      
     
     Course C(Dept, stoi(Number1), title, stoi(A1), stoi(B1), stoi(C1), stoi(D1), stoi(F1), stoi(I1), stoi(NR1), stoi(S1), stoi(U1), stoi(W1), Instructor);
     
     // Inserting the values from file into vector 
     
     courses.push_back(C);
     
  }


  cout << std::fixed;
  cout << std::setprecision(2);
  
  int  num_courses=0,num_grades=0;
  float perc1 =0 ,perc2=0, perc3=0, perc4=0, perc5=0, num_A=0,num_B=0,num_C=0,num_D=0,num_F=0;
  
  for (Course& c : courses)
  {
    num_courses = num_courses + 1;
    num_A = num_A + c.A;
    num_B = num_B + c.B;
    num_C = num_C + c.C;
    num_D = num_D + c.D;
    num_F = num_F + c.F;
    
  }
  
  
  
  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  
  
  cout<<"College of Engineering:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;
  cout<<endl;
  
  
  
  
  ///////////////////////////////////////////////////// Part 2 ////////////////////////////////////////////////////////////////
  
  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
  for (Course& c : courses)
  {
    if (c.dept == "BIOE")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<" BIOE:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;

  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "CHE")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<" CHE:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;

  
  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "CME")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<" CME:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;


  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "CS")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"  CS:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;

 
  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "ECE")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<" ECE:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;


  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "ENER")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"ENER:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;

  
  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "ENGR")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"ENGR:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;



  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "IE")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"  IE:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;



   num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "IT")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"  IT:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;


  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "ME")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"  ME:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;


  num_courses=0;
  num_grades = 0;
  num_A = 0;
  num_B = 0;
  num_C = 0;
  num_D = 0;
  num_F = 0;
  
   for (Course& c : courses)
  {
    if (c.dept == "MENG")
    {
     num_courses = num_courses + 1;
     num_A = num_A + c.A;
     num_B = num_B + c.B;
     num_C = num_C + c.C;
     num_D = num_D + c.D;
     num_F = num_F + c.F;
    }
  }

  num_grades = num_A + num_B + num_C + num_D + num_F;
  
  perc1 = ((num_A / num_grades))*100;
  perc2 = ((num_B / num_grades))*100;
  perc3 = ((num_C / num_grades))*100;
  perc4 = ((num_D / num_grades))*100;
  perc5 = ((num_F / num_grades))*100;
  
  cout<<"MENG:"<<endl;
  cout<<"   Num courses:  "<<num_courses<<endl;
  cout<<"   Num grades:   "<<num_grades<<endl;
  cout<<"   Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;
  cout<<endl;

 //////////////////////////////////////////////// Part 2 /////////////////////////////////////////////////////////////////
 
 /////////////////////////////////////////////// Part 3 and 4 ////////////////////////////////////////////////////////////
 
  
  
  string input,dep;
  int n,n1,dfw;
  float num,perc6,total;

  
  while (input !="#")
  {
    cout<<"Please enter instructor's name (or prefix or #)> ";
    cin>>input;
    
     for(Course&c : courses)
     {
  
       if(c.comparison(c.instruct,input) == true && c.instruct !="#VALUE!")
       {
         
          n = c.A + c.B + c.C + c.D + c.F;
          num = n;
          perc1 = ((c.A / num))*100;
          perc2 = ((c.B / num))*100;
          perc3 = ((c.C / num))*100;
          perc4 = ((c.D / num))*100;
          perc5 = ((c.F / num))*100;
          
          n1 = n + c.I + c.NR + c.S + c.U + c.W;
          dfw = c.A + c.B + c.C + c.D + c.F + c.W;
          total = dfw;
          perc6 = (((c.D + c.F + c.W) / total))*100;
          
          if (c.S !=0 || c.U!=0 || c.NR!=0)
          {
            cout<<c.dept<<" "<<c.Number<<" "<<"("<<c.instruct<<"):"<<endl;
            cout<<" Num students: "<<n1<<endl;
            cout<<" Distribution: no report"<<endl;
            if (c.NR!=0)
            {
            cout<<" DFW rate: 100.00%"<<endl;
            }
            else
            {
             cout<<" DFW rate: 0.00%"<<endl;
            }
            cout<<endl;
          }
          else
          {
            cout<<c.dept<<" "<<c.Number<<" "<<"("<<c.instruct<<"):"<<endl;
            cout<<" Num students: "<<n1<<endl;
            cout<<" Distribution: "<<perc1<<"%"<<", "<<perc2<<"%"<<", "<<perc3<<"%"<<", "<<perc4<<"%"<<", "<<perc5<<"%"<<", "<<endl;
            cout<<" DFW rate: "<<perc6<<"%"<<endl;
            cout<<endl;
          }
         
       }
       
      
     }
  
     
    
   
    
  
    
    
  }
  
  
  //
  // done:
  //
  cout << endl;
  return 0;
}
