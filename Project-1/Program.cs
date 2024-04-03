// this layer will be responsible for the main method and the startup of the application

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the BMI Calculator!");

            // Ask user for height and weight

            Console.WriteLine("Please enter your height in meters: ");
            double height = Convert.ToDouble(Console.ReadLine());
            // create an instance of the BMICalculator class
            BMICalculator bmiCalculator = new BMICalculator();

            // call the CalculateBMI method
            bmiCalculator.CalculateBMI();
        }
    }