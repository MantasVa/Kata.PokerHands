using Kata.PokerHands.Infrastructure;
using Kata.PokerHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.PokerHands
{
    public class Game
    {
        private IList<String> _deck = new List<string>()
        {
            "2S", "2H", "2C", "2D",
            "3S", "3H", "3C", "3D",
            "4S", "4H", "4C", "4D",
            "5S", "5H", "5C", "5D",
            "6S", "6H", "6C", "6D",
            "7S", "7H", "7C", "7D",
            "8S", "8H", "8C", "8D",
            "9S", "9H", "9C", "9D",
            "TS", "TH", "TC", "TD",
            "JS", "JH", "JC", "JD",
            "QS", "QH", "QC", "QD",
            "KS", "KH", "KC", "KD",
            "AS", "AH", "AC", "AD",
        };
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }
        public Game()
        {
            PlayerOne = new Player(DealCards());
            PlayerTwo = new Player(DealCards());
        }
        private string DealCards()
        {
            StringBuilder pokerHand = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                pokerHand.Append(GetCardFromDeck());
            }
            return pokerHand.ToString();
        }

        private string GetCardFromDeck()
        {
            var random = new Random();
            var firstCard = _deck.OrderBy(x => random.Next()).Take(1).First();
            _deck.Remove(firstCard);
            return firstCard + " ";
        }

        public string CheckWinner(Player playerOne, Player playerTwo)
        {
            playerOne.CalculateHandRank();
            playerTwo.CalculateHandRank();
            if(playerOne.PokerHand > playerTwo.PokerHand)
            {
                return "Player one won";
            }
            else if(playerOne.PokerHand < playerTwo.PokerHand)
            {
                return "Player two won";
            }
            else
            {
                playerOne.CheckHighCard();
                playerTwo.CheckHighCard();
                if (playerOne.HighCard > playerTwo.HighCard)
                {
                    return "Player one won";
                }
                else if (playerOne.HighCard < playerTwo.HighCard)
                {
                    return "Player two won";
                }
                else
                {
                    return "Tie";
                }
            }
        }

    }
}
