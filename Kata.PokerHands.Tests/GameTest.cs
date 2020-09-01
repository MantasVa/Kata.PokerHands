using Kata.PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kata.PokerHands.Tests
{
    public class GameTest
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2H 9H AH 4H 8H", "Player two won")]
        [InlineData("2H 3D 5S 9C KD", "2H 3D 5S 9C QD", "Player one won")]
        [InlineData("2H 3D 5S TC AD", "2H 3D 5S 9C KD", "Player one won")]
        [InlineData("2H 3D 5S 9C KD", "2D 3H 5D 9S KH", "Tie")]
        [InlineData("2H 2D 2S 9C KD", "6D 6H 6S 9S KH", "Player two won")]
        [InlineData("2H 2D 4S 4C KD", "6D 6H 3S 3C KH", "Player two won")]
        [InlineData("3H 3D 3S 3C KD", "2H 2D 2S 2C KD", "Player one won")]
        [InlineData("3H 3D 3S 5C 5D", "2H 2D 2S 4C 4D", "Player one won")]
        [InlineData("2H 3H 4H 5H 6H", "3C 4C 5C 6C 7C", "Player two won")]
        [InlineData("2H 3H 4H 5H 6H", "2C 3C 4C 5C 6C", "Tie")]
        public void CheckWinner_ValidInput_CorrectWinnerIsChosen(string playerOneHand, string playerTwoHand, string expectedWinner)
        {
            //Arrange
            Player playerOne = new Player(playerOneHand);
            Player playerTwo = new Player(playerTwoHand);

            //Actual
            Game game = new Game();
            string actualWinner = game.CheckWinner(playerOne, playerTwo);

            //Assert
            Assert.Equal(expectedWinner, actualWinner);
        }

        [Fact]
        public void dealcards()
        {
            Game g = new Game();

            g.
        }
    }
}
