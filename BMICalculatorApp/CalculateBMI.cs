//this layer will be responsible for BMI calculation
//
using System.Reflection.Metadata.Ecma335;

namespace BMICalculator
{
    class CalculateBMI
    {
        public static double BMICalculator(double h, double w)
        {
            double height = h;
            double weight = w;
            double bmiExactValue = weight / (height * height);
            double bmi = Math.Round(bmiExactValue, 1);

            return bmi;

        }
        // {
        //     // Console.WriteLine("Please enter your weight in kilograms: ");
        //     // double weight = Convert.ToDouble(Console.ReadLine());
        //     // double bmi = weight / (height * height);
        //     // Console.WriteLine("Your BMI is: " + bmi);
        // }

       

   } 
}
