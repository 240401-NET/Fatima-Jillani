// this layer will be responsible for the main method and the startup of the application

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a List to store the user information
            List<User> users = new();

            Console.WriteLine("Welcome to the BMI Calculator!");
            Console.WriteLine("Please enter your Gender only using 'F' for Female and 'M' for Male: ");

            string gender = Console.ReadLine().ToUpper();
            if (gender == "F" || gender == "M")
            {
                Console.WriteLine("Please enter your height in meters: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter your weight in kilograms: ");
                double weight = Convert.ToDouble(Console.ReadLine());
                User user = new User();
                // Rest of the code...
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter either 'F' or 'M'.");
            }
        }
    }

}