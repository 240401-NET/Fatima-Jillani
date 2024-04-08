//this layer will take user information and add them to a list

using System.Diagnostics;

namespace BMICalculator
{

 public class User
 {
    //  public string gender{get; set;}
     public double heightInM {get; set;}
     public double weightInKg {get; set;}

     public string username {get; set;}
 
     //no argument constructor
     public User()
     { }
     // argument constructor
    public User(string username, double heightInM, double weightInKg)
    {
        // this.gender =gender;
        this.heightInM = heightInM;
        this.weightInKg = weightInKg;
        this.username = username;
    }      

    //generate unique username

  

    //
        
        //ToString method
    public override string ToString()
    {
        // Create an instance of the Health class
        Health health = new Health(); 
        
        return "User Name: " + health.generateUsername() + "\nHeight: " + heightInM + "\nWeight: " + weightInKg;
    }

    
 }
 
 }
 