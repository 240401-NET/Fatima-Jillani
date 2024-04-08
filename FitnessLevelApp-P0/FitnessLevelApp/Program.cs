
// this layer will be responsible for the main method and the startup of the application

namespace BMICalculator
{
    class Program
    { 
        static void Main(string[] args)
        {

            Console.WriteLine("\nWelcome to FitnessLevel! Discover your fitness status and take control of your health journey.");

            //Create a List to store the user information
            List<User> users = new();


            //Load the existing users from the file
            Data.LoadUserData(ref users);


            //add to the list
            users.Add(new User("User1", 1.5, 50));
            users.Add(new User("User2", 1.6, 60));
            users.Add(new User("User3", 1.7, 70));
            users.Add(new User("User4", 1.8, 80));

            

            bool exit = false;
            int choice = 0;





            
            while (choice!=3)
            {
                //display menu
                Menu.Display();

                
                choice = Menu.getUserChoice();

                switch (choice)
                {
                    case 1:
                        string fitnessLevel = Health.evaluateHealth();
                        Console.WriteLine(fitnessLevel);
                        User newUser = new User(Health.username, Health.heightInM, Health.weightInKg);
                        users.Add(newUser);
                        break;

                    case 2:
                    Health.displayExistingUsersBmi(users); 
                        break;

                    case 3:
                     
                    // Environment.Exit(0);
                     
                    break;

                }

            }
            
            //Persist the user data to the file
            Data.PersistUserData(users);

            
            // Console.WriteLine("GoodBye...:)");

        }

        
        

    
    }    
}




            // Console.WriteLine("Please enter your Gender only using 'F' for Female and 'M' for Male: ");

            // string gender = Console.ReadLine().ToUpper();
            // if(gender == "F" || gender == "M")
            // {
            //     Console.WriteLine("Please enter your height in meters: ");
            //     double heightInM  = Convert.ToDouble(Console.ReadLine());



            //     Console.WriteLine("Please enter your weight in kilograms: "); 
            //     double weightInKg = Convert.ToDouble(Console.ReadLine());
                
            //     User user = new User();
            //     users.Add(user);

                
            //     Console.WriteLine($"Your BMI is: {Health.BMICalculator(heightInM, weightInKg)}");
            //     // break;
            //     // Console.WriteLine("Would you like to add another user? (Y/N)");
            // }
            // else
            // {
            //     Console.WriteLine("Invalid input. Please enter either 'F' or 'M'.");
            // }

            // //Display the BMI Categories


            // Console.WriteLine("Would you like to try again with another user? (Y/N)");
            // string answer = Console.ReadLine() ?? "".ToUpper();
            // if (answer == "N")
            // {
            //     break;
            // }
            
  