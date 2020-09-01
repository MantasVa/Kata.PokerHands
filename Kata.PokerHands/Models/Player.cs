using Kata.PokerHands.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.PokerHands.Models
{
    public class Player
    {
        public IList<string> Hand { get; }
        public PokerHand PokerHand { get; private set; }
        public ushort HighCard { get; private set; }

        public Player(string hand)
        {
            Hand = PlayerHandParser.Parse(hand);
        }
        public void CalculateHandRank()
        {
            if (CheckForStraight() && CheckForFlush())
            {
                PokerHand = PokerHand.StraightFlush;
                return;
            }

            if (CheckForPairs(4))
            {
                PokerHand = PokerHand.FourOfAKind;
                return;
            }

            if (CheckForPairs(2) && CheckForPairs(3))
            {
                PokerHand = PokerHand.FullHouse;
                return;
            }

            if (CheckForFlush())
            {
                PokerHand = PokerHand.Flush;
                return;
            }

            if (CheckForStraight())
            {
                PokerHand = PokerHand.Straight;
                return;
            }

            if (CheckForPairs(3))
            {
                PokerHand = PokerHand.ThreeOfAKind;
                return;
            }

            if (CheckForTwoPairs())
            {
                PokerHand = PokerHand.TwoPairs;
                return;
            }

            if (CheckForPairs(2))
            {
                PokerHand = PokerHand.Pair;
                return;
            }

            CheckHighCard();
            PokerHand = PokerHand.HighCard;
        }
        public void CheckHighCard()
        {
            switch (PokerHand)
            {
                case PokerHand.Pair:
                    HighCard = CalculateHighCardValue(2);
                    break;
                case PokerHand.TwoPairs:
                    var pairs = Hand.GroupBy(n => n.Remove(n.Length - 1)).Where(x => x.Count() == 2).ToList();
                    HighCard = (ushort)pairs.Max(t => Int16.Parse(t.Key));
                    break;
                case PokerHand.ThreeOfAKind:
                case PokerHand.FullHouse:
                    HighCard = CalculateHighCardValue(3);
                    break;
                case PokerHand.FourOfAKind:
                    HighCard = CalculateHighCardValue(4);
                    break;
                default:
                    HighCard = CalculateHighestCard();
                    break;
            }
        }

        private ushort CalculateHighCardValue(int count)
        {
            return (ushort)Int16.Parse(Hand.GroupBy(n => n.Remove(n.Length - 1)).Where(c => c.Count() == count).First().Key);
        }

        private ushort CalculateHighestCard()
        {
            return (ushort)Hand.Select(item => Int16.Parse(item.Remove(item.Length - 1))).OrderByDescending(n => n).First();
        }

        private bool CheckForTwoPairs()
        {
            return Hand.GroupBy(n => n.Remove(n.Length - 1)).Where(x => x.Count() == 2).Count() == 2;
        }

        private bool CheckForPairs(int count)
        {
            return Hand.GroupBy(n => n.Remove(n.Length - 1)).Any(c => c.Count() == count);
        }

        private bool CheckForStraight()
        {
            var orderedHandValues = Hand.Select(item => Int32.Parse(item.Remove(item.Length - 1))).OrderBy(n=> n).ToList();

            for (short i = 0; i < orderedHandValues.Count - 1; i++)
            {
                if (orderedHandValues[i] + 1 != orderedHandValues[i + 1])
                    return false;
            }
            return true;
        }
        private bool CheckForFlush()
        {
            var suitType = Hand.Select(card => card.Substring(card.Length - 1)).ToList();
            return suitType.GroupBy(type => type).Any(x => x.Count() == 5);
        }



    }
}
