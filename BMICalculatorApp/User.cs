//this layer will take user information and add them to a list

using System.Diagnostics;

namespace BMICalculator
{

 class User
 {
     public string gender{get; set;}
     public double heightInM {get; set;}
     public double weightInKg {get; set;}
 
     //no argument constructor
     public User()
     { }
     // argument constructor
    public User(string gender, double heightInM, double weightInKg)
    {
        this.gender =gender;
        this.heightInM = heightInM;
        this.weightInKg = weightInKg;
    }       
        
        //ToString method
    public override string ToString()
    {
     return "Gender: " + gender + "\nHeight: " + heightInM + "\nWeight: " + weightInKg;
    }

    
}
 
}
 
