using Kata.PokerHands.Infrastructure;
using Kata.PokerHands.Models;
using Xunit;

namespace Kata.PokerHands.Tests
{

    public class PlayerTests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", PokerHand.HighCard)]
        [InlineData("2H 9H AH 4H 8H", PokerHand.Flush)]
        [InlineData("2H 2D 2S 2C 6C", PokerHand.FourOfAKind)]
        [InlineData("2H 2D 2S 6H 6C", PokerHand.FullHouse)]
        [InlineData("4H 5H 6H 7H 8H", PokerHand.StraightFlush)]
        [InlineData("4H 5D 6S 7S 8H", PokerHand.Straight)]
        [InlineData("2H 2D 5S 9C KD", PokerHand.Pair)]
        [InlineData("AH AD 5S AC KD", PokerHand.ThreeOfAKind)]
        [InlineData("AH AD 5S 7C 5D", PokerHand.TwoPairs)]        
        public void CalculateHandRank_CorrectlyCalculatedHandRank(string input, PokerHand expectedPokerHand)
        {
            Player player = new Player(input);      

            //Actual
            player.CalculateHandRank();

            //Assert
            Assert.Equal(expectedPokerHand, player.PokerHand);
        }

        [Theory]
        [InlineData("2H 3D 5S 9C KD", 13)]
        [InlineData("2H 3D 5S 9C 8D", 9)]
        public void CalculateHandRank_CorrectlyCalculatedHighCard(string input, ushort expectedHighCard)
        {
            Player player = new Player(input);

            //Actual
            player.CalculateHandRank();

            //Assert
            Assert.Equal(expectedHighCard, player.HighCard);
        }
    }
}
