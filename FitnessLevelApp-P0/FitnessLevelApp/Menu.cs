namespace BMICalculator
{
    class Menu
    {
        public static void Display()
        {
            Console.WriteLine("\n1. Calculate Health Level");
            Console.WriteLine("2. Display other users bmi");
            Console.WriteLine("3. Exit");
    
        }


         public static int getUserChoice()
        {
            Console.WriteLine("Enter your choice: ");
            try{
                return Convert.ToInt32(Console.ReadLine());
            } catch (Exception)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return -1;
            }
        }

    }

    
}