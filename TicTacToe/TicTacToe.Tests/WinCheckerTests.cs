using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TicTacToe.Infrastructure.Controls;
using TicTacToe.Infrastructure.Structures;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class WinCheckerTests
    {
        [Test]
        public void CheckIfWon_WinningCombination_ReturnsTrue()
        {
            // Arrange
            var fields = new List<FieldButton>
            {
                new FieldButton(new Coordinates(1, 1), null, 'X'),
                new FieldButton(new Coordinates(2, 1), null, 'X'),
                new FieldButton(new Coordinates(3, 1), null, 'X')
            };

            var engine = new Mock<GameEngine>();
            engine.Setup(en => en.CurrentPlayer).Returns(new Player('X', 1));
            var winChecker = new WinChecker(fields, engine.Object);

            // Act 
            var result = winChecker.CheckIfWon();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfWon_AnyWinningCombination_ReturnsFalse()
        {
            // Arrange
            var fields = new List<FieldButton>
            {
                new FieldButton(new Coordinates(1, 1), null, 'X'),
                new FieldButton(new Coordinates(2, 1), null, 'Y'),
                new FieldButton(new Coordinates(3, 1), null, 'X')
            };

            var engine = new Mock<GameEngine>();
            engine.Setup(en => en.CurrentPlayer).Returns(new Player('X', 1));
            var winChecker = new WinChecker(fields, engine.Object);

            // Act 
            var result = winChecker.CheckIfWon();

            // Assert
            Assert.IsFalse(result);
        }
    }
}