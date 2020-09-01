using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace Kata.PokerHands.Infrastructure
{
    public static class PlayerHandParser
    {
        public static List<string> Parse(string hand)
        {
            hand = hand.Trim();
            var handList = hand.Split(' ').ToList();
            handList.FormatCards();           
            return hand.Length == 14 ? handList : throw new ArgumentException("Bad hand input", "hand");
        }

        private static void FormatCards(this List<string> handList)
        {
            for (int i = 0; i < handList.Count; i++)
            {
                if (handList[i].Substring(0, 1) == "T")
                    handList[i] = handList[i].Replace("T", "10");

                if (handList[i].Substring(0, 1) == "J")
                    handList[i] = handList[i].Replace("J", "11");

                if (handList[i].Substring(0, 1) == "Q")
                    handList[i] = handList[i].Replace("Q", "12");

                if (handList[i].Substring(0, 1) == "K")
                    handList[i] = handList[i].Replace("K", "13");

                if (handList[i].Substring(0, 1) == "A")
                    handList[i] = handList[i].Replace("A", "14");
            }
        }


    }
}
