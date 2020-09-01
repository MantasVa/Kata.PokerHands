using System;
using System.Collections.Generic;
using Kata.PokerHands.Infrastructure;
using Xunit;

namespace Kata.PokerHands.Tests
{
    public class PlayerHandParserTests
    {
        [Fact]
        public void Parse_CorrectHandInput_HandIsParsedCorrectly()
        {
            //Expected
            List<string> expectedHand = new List<string> { "2H", "3D", "10S", "9C", "13D" };
            string input = "2H 3D TS 9C KD";

            //Actual
            var actualHand = PlayerHandParser.Parse(input);

            //Assert  
            for (short i = 0; i < expectedHand.Count; i++)
            {
                Assert.Equal(expectedHand[i], actualHand[i]);
            }
            Assert.NotNull(actualHand);
            Assert.Equal(expectedHand.Count, actualHand.Count);
        }

        [Fact]
        public void Parse_CorrectHandInputWithSpacesBeforeAndAfterString_HandIsParsedCorrectly()
        {
            //Expected
            List<string> expectedHand = new List<string> { "2H", "3D", "10S", "9C", "13D" };
            string input = " 2H 3D TS 9C KD ";

            //Actual
            var actualHand = PlayerHandParser.Parse(input);

            //Assert  
            for (short i = 0; i < expectedHand.Count; i++)
            {
                Assert.Equal(expectedHand[i], actualHand[i]);
            }
            Assert.NotNull(actualHand);
            Assert.Equal(expectedHand.Count, actualHand.Count);
        }

        [Theory]
        [InlineData("2H 3D 5S 9C KD 3H")]
        [InlineData("2H 3D 5S 9C")]
        public void Parse_BadHandInput_ThrowsException(string input)
        {
           Assert.Throws<ArgumentException>(() => PlayerHandParser.Parse(input));
        }
    }


}
