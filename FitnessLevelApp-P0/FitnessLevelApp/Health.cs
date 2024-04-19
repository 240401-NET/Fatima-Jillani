

using System;

namespace BMICalculator
{
    public class Health
    {
        public static double bmi;
        public static double heightInM;
        public static double weightInKg;

        public static string username;

        public static void handleUserInput()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Please enter your height in meters: ");
                string heightInput = Console.ReadLine();

                if (heightInput != null && validateInput.validateHeight(heightInput))
                {
                    heightInM = double.Parse(heightInput);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid height.");
                }
            }

            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Please enter your weight in kilograms: ");
                string weightInput = Console.ReadLine();

                if (weightInput != null && validateInput.validateWeight(weightInput))
                {
                    weightInKg = double.Parse(weightInput);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid weight.");
                }
            }
        }

        public static string evaluateHealth()
        {
            handleUserInput();

            Console.WriteLine("Calculating your Fitness Level...");
            Thread.Sleep(1000);

            string fitnessLevel = "";

            if (bmi < 18.5)
            {
                fitnessLevel = "\nUnderweight: You are underweight.";
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                fitnessLevel = "\nNormal: You are at a normal weight.";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                fitnessLevel = "\nOverweight: You are overweight.";
            }
            else if (bmi >= 30)
            {
                fitnessLevel = "Obese: You are obese.";
            }

            return fitnessLevel;
        }

        public static void displayExistingUsersBmi(List<User> users)
        {
            Console.WriteLine("Existing users BMI: ");

            foreach (User user in users)
             
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(user.ToString());
            }
        }

        public string generateUsername()
        {
            // Combine the user's height and weight with the current timestamp to generate a unique username
            string username = "user_" + heightInM.ToString() + "_" + weightInKg.ToString() + "_" + DateTime.Now.Ticks.ToString();

            // Replace any decimal points with underscores to ensure a valid username
            username = username.Replace('.', '_');

            return username;
        }
    

        
    }
}
