using Microsoft.AspNetCore.Mvc;
using Moq;
using App.Controllers;
using App.Models;
using App.Data;
using App.Services;

namespace RecipeSharingApp.Tests
{
    public class RecipeServiceTest
    {
       
        [Theory]
        [InlineData("testtitle1", "Test Recipe1", "Test Ingredients1", 1)]
        [InlineData("testtitle2", "Test Recipe2", "Test Ingredients2", 2)]
        [InlineData("12333", "   Test 22%% Recipe3", "%$@@Test Ingredients3  !##", 3)]
    
        public void CreateRecipe_Should_Return_CreatedRecipe(string title, string directions, string ingredients, int postedBy)
        {
            // Arrange
            Mock<IRecipeRepository> repoMock = new Mock<IRecipeRepository>();

            Recipe fakeRecipe = new Recipe
            {
                Title = title,
                Directions = directions,
                Ingredients = ingredients,
                PostedBy = postedBy,
                CreatedAt = DateTime.Now
            };

            repoMock.Setup(r => r.CreateRecipe(It.IsAny<Recipe>())).Returns(fakeRecipe);
            RecipeServices service = new RecipeServices(repoMock.Object);

            // Act
            Recipe createdRecipe = service.CreateRecipe(fakeRecipe);

            // Assert
            Assert.NotNull(createdRecipe);
            Assert.Equal(fakeRecipe.PostedBy, createdRecipe.PostedBy);
            Assert.Equal(fakeRecipe.Title, createdRecipe.Title);
           

            // Verify that CreateRecipe of RecipeRepository was called exactly once
            repoMock.Verify(repo => repo.CreateRecipe(It.IsAny<Recipe>()), Times.Exactly(1));
        }

        
        [Theory]
        [InlineData("", "Test Recipe1", "Test Ingredients1", 1)]
        [InlineData("testtitle2", "", "Test Ingredients2", 2)]
        [InlineData("testtitle3", "Test Recipe3", "", 3)]
        [InlineData("", "   ", "", 4)]

        public  void  CreateRecipe_Should_Throw_ArgumentNullException_For_Empty_Recipe(string title, string directions, string ingredients, int postedBy)
        {
            // Arrange
            Mock<IRecipeRepository> repoMock = new Mock<IRecipeRepository>();

            Recipe fakeRecipe = new Recipe
            {
                Title = title,
                Directions = directions,
                Ingredients = ingredients,
                PostedBy = postedBy,
                CreatedAt = DateTime.Now
            };

            repoMock.Setup(r => r.CreateRecipe(It.IsAny<Recipe>())).Returns(fakeRecipe);
            RecipeServices service = new RecipeServices(repoMock.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => service.CreateRecipe(fakeRecipe));
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetUserByID_Should_Return_NotFound_For_Invalid_Id(int id)
        {
            // Arrange
            var mockService = new Mock<IUserServices>();
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object, mockService.Object);

            mockService.Setup(s => s.GetUserByID(id)).Returns((User)null);

            // Act
            var result = controller.GetUserByID(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetUsersByUsername_Should_Throw_FormatException_For_Invalid_Username(string username)
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserServices(mockRepository.Object);

            // Act and Assert
            Assert.Throws<FormatException>(() => service.GetUsersByUsername(username));
        }

        [Theory]
        [InlineData("testuser1")]
        [InlineData("testuser2")]
        [InlineData("   testuser3   ")]
        [InlineData("5TESTUSER")]
        public void GetUsersByUsername_Should_Return_Users_For_Valid_Username(string username)
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserServices(mockRepository.Object);

            var fakeUsers = new List<User>
            {
                new User { Username = username }
            };

            mockRepository.Setup(r => r.GetUsersByUsername(username.ToLower().Trim())).Returns(fakeUsers);

            // Act
            var users = service.GetUsersByUsername(username);

            // Assert
            Assert.Equal(fakeUsers, users);
        }



    
                
    }
}
