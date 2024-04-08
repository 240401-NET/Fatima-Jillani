//handle data here

using System.Linq.Expressions;
using System.Text.Json;

namespace BMICalculator;

class Data
{
 //Read data from the user
    public static void LoadUserData( ref List <User> users)
    {
        try
        {
            
        string filePath = "userData.json";
        string jsonString = File.ReadAllText(filePath);
        users = JsonSerializer.Deserialize<List<User>>(jsonString);
        }

        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        } 
    }

    public static void PersistUserData(List<User> users)
    {

        try

        {
            

            string filePath = "userData.json";

            //Serialize the list of users to JSON
            string jsonString = JsonSerializer.Serialize(users);

            //Write the JSON string to a file
            File.WriteAllText(filePath, jsonString);
            

        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while writing to the file: " + e.Message);
        }




    }
}
