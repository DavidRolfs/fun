using FRPG.Models;
using Xunit;

namespace FRPG.Tests
{
    public class PlayerTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var player = new Player();
            player.Bio = "Wash the dog";
            player.Name = "CRUD";

            //Act
            var result = player.Bio;
            var namez = player.Name;

            //Assert
            Assert.Equal("Wash the dog", result);
            Assert.Equal("CRUD", namez);
        }
    }
}
