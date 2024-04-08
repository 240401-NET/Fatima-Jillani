using BMICalculator;
using FitnessLevelApp;

namespace FitnessLevelApp.Tests
{

    public class FitnessLevelAppTests
    {


        [Fact]
        public void ValidateHeight_NullInput_ReturnsFalse()
        {
            // Arrange
            string nullHeight = null;

            // Act
            bool result = validateInput.validateHeight(nullHeight); 
            // Assert
            Assert.False(result);
        }
            
        
            [Fact]
            public void ValidateHeight_EmptyString_ReturnsFalse()
            {
                // Arrange
                string emptyHeight = "";
        
                // Act
                bool result = validateInput.validateHeight(emptyHeight);
        
                // Assert
                Assert.False(result);
            }

            [Fact]
        public void GenerateUsername_ValidHeightAndWeight_ReturnsValidUsername()
        {
            // Arrange
            Health.heightInM = 1.8;
            Health.weightInKg = 70;
            var health = new Health();

            // Act
            string result = health.generateUsername();

            // Assert
            Assert.StartsWith("user_1_8_70", result);
        }

        }

    }
    




    //     [Theory]
    //     [InlineData(17, "Underweight")]
    //     [InlineData(20, "Normal")]
    //     [InlineData(27, "Overweight")]
    //     [InlineData(32, "Obese")]
    //     public void Health_evaluateHealth_ReturnsCorrectHealthStatus(double bmi, string fitnessLevel)
    //     {
    //         // Arrange   
    //         Health.bmi = bmi;       

    //         // Act
    //         var result = Health.evaluateHealth();

    //         // Assert
    //         Assert.Equal(fitnessLevel, result);


    //     // [Fact]
    //     // public void Health_GenerateUsername_ReturnsString()
    //     // {
    //     //     // Arrange

    //     //     Health health = new Health();
    //     //     var result = health.generateUsername();

    //     //     // Assert
    //     //     Assert.Equal(typeof(string), result.GetType());
    //     //     Assert.StartsWith("User_1_8_70_", result);
    //     //     Assert.Contains(".", result);
    //     // }
    
    //     }
    // }

// public class FitnessLevelAppTests
// {


//     [Theory]
//     [InlineData(17, "Underweight")]
//     [InlineData(20, "Normal")]
//     [InlineData(27, "Overweight")]
//     [InlineData(32, "Obese")]
//     public void Health_evaluateHealth_ReturnsCorrectHealthStatus( double bmi, string fitnessLevel)
//     {
//         // Arrange          

//         // Act
//         var result = Health.evaluateHealth(bmi, fitnessLevel);

//         // Assert
//         Assert.Equal(expected, result);

//     }

//     [Fact]
//     public void Health_GenerateUsername_ReturnsString()
//     {
//         // Arrange

//         Health.heightInM = 1.85;
//         Health.weightInKg = 70;
    
//         // Act

//         var result = Health.generateUsername();
    
//         // Assert

//         Assert.Equal(typeof(string), result.GetType());
//         Assert.True(result.StartsWith("User_1_8_70_"));
//         Assert.True(result.Contains("."));
//     }
 
// }