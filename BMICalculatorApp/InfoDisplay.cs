//This layer will be responsible for displaying the information to the user

namespace BMICalculator
{
    class InfoDisplay
    {
        public void DisplayInfo()
        {
            Console.WriteLine("\nBMI Categories:");
            Console.WriteLine("Underweight: less than 18.5");
            Console.WriteLine("Normal weight: 18.5–24.9");
            Console.WriteLine("Overweight: 25–29.9");
            Console.WriteLine("Obesity: 30 or greater");
        }
    }
}