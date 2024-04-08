namespace BMICalculator
{
    public class validateInput
    {
        public static bool validateHeight(string heightInput)
        {
            // Check if heightInput is not null and not empty
            if (!string.IsNullOrEmpty(heightInput))
            {
                // Try to parse heightInput to a double
                if (double.TryParse(heightInput, out _))
                {
                    // If parsing succeeds, return true (valid input)
                    return true;
                }
            }

            // If any of the conditions fail, return false (invalid input)
            return false;
        } 

        public static bool validateWeight(string weightInput)
        {
            // Check if weightInput is not null and not empty
            if (!string.IsNullOrEmpty(weightInput))
            {
                // Try to parse weightInput to a double
                if (double.TryParse(weightInput, out _))
                {
                    // If parsing succeeds, return true (valid input)
                return true;
                }
            }

            // If any of the conditions fail, return false (invalid input)
            return false;
        }


    }
}   