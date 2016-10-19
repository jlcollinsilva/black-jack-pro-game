using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardLibrary;
using PlayerLibrary;

namespace BlackJackLib
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
   
    /// <summary>
    /// A class for the definition of all components of a Back Jack Game including the set of Cards, the names of each card and their values. Also implement the initial groupier that give to each player his first 2 cards.
    /// </summary>
    public class BlackJackGame
    {
        /// <summary>
        /// Content the set of cards available for the game, 52 cards in the for of objects
        /// </summary>
        public Dictionary<int, Card> DeckBlackJack = new Dictionary<int, Card>();
        /// <summary>
        /// Content the generic names of each card (13 cards).
        /// </summary>
        public Dictionary<int, string> CardsName = new Dictionary<int, string>();
        /// <summary>
        /// Content the value of each card in this game.
        /// </summary>
        public Dictionary<string, int> CardsValue = new Dictionary<string, int>();

        /// <summary>
        /// Find the generic alphabetic name of a given card from a Dictionary and return a string. 
        /// </summary>
        /// <param name="CardNumber">the identificaation number of the Card in his face</param>
        /// <returns>a string with the generic name of the card</returns>
        public string LookupCard(int CardNumber)
        {

            return (CardsName[CardNumber]);
        }
        /// <summary>
        /// Constructor of BlackJackGame Class
        /// </summary>
        public BlackJackGame()
        {
            CardsName.Add(1, "ACE");
            CardsName.Add(2, "TWO");
            CardsName.Add(3, "THREE");
            CardsName.Add(4, "FOUR");
            CardsName.Add(5, "FIVE");
            CardsName.Add(6, "SIX");
            CardsName.Add(7, "SEVEN");
            CardsName.Add(8, "EIGHT");
            CardsName.Add(9, "NINE");
            CardsName.Add(10, "TEN");
            CardsName.Add(11, "JACK");
            CardsName.Add(12, "QUEEN");
            CardsName.Add(13, "KING");

            CardsValue.Add("ACE", 1);
            CardsValue.Add("TWO", 2);
            CardsValue.Add("THREE", 3);
            CardsValue.Add("FOUR", 4);
            CardsValue.Add("FIVE", 5);
            CardsValue.Add("SIX", 6);
            CardsValue.Add("SEVEN", 7);
            CardsValue.Add("EIGHT", 8);
            CardsValue.Add("NINE", 9);
            CardsValue.Add("TEN", 10);
            CardsValue.Add("JACK", 10);
            CardsValue.Add("QUEEN", 10);
            CardsValue.Add("KING", 10);

            var Game = new Card();
            var IdCard = 0;
            var name = "";

            foreach (var deck in Game.DecksCards())
            {
                for (int i = 1; i < 14; i++)
                {
                    IdCard += 1;
                    name = LookupCard(i);

                    DeckBlackJack.Add(IdCard, new Card
                    {
                        CardId = IdCard,
                        Deck = deck,
                        Name = name,
                        MinValue = CardsValue[name],
                        //Special case of Ace and his double value, 1 and 11
                        MaxValue = (name == "ACE") ? CardsValue[name] + 10 : CardsValue[name],
                        Played = false
                    });
                }
            }
        }

        /// <summary>
        /// Provide to the player given with his two first cards for start the game.
        /// </summary>
        /// <param name="player">an object with the instance of a player (CardPlayer)</param>
        public void InitPlayer(CardPlayer player)
        {
            player.RequestCard(DeckBlackJack);
            player.RequestCard(DeckBlackJack);
        }

        /// <summary>
        /// Comparission of the values of each player during the process of the game, return a string with the result of the comparision.
        /// </summary>
        /// <param name="player1">Represent the Computer, an instance of CardPlayer object</param>
        /// <param name="player2">Represent the User, an instance of CardPlayer object</param>
        /// <returns></returns>
        public string CheckWinner(CardPlayer player1, CardPlayer player2)
        {
            var winneris = "NoWinner";

            if (player1.MaxTotalHand() == 21 && player2.MaxTotalHand() == 21)
            {
                winneris = String.Format("Have been a Tie to {0} ", 21);
            }
            else if (player1.MaxTotalHand() == 21 || (player2.MaxTotalHand() > 21 && player2.MinTotalHand() > 21))
            {
                winneris = string.Format("The Computer is the winner {0} to {1} ", player1.MaxTotalHand(), player2.MaxTotalHand());
            }
            else if (player2.MaxTotalHand() == 21 || player2.MinTotalHand() == 21)
            { winneris = string.Format("You Win!  {0} to {1} ", 21, player1.MaxTotalHand()); }

            return winneris;
        }

        /// <summary>
        /// Comparission of the values of each player at the end of the game, return a string with the result of the comparision.
        /// </summary>
        /// <param name="player1">Represent the Computer, an instance of CardPlayer object</param>
        /// <param name="player2">Represent the User, an instance of CardPlayer object</param>
        /// <returns></returns>
        public string CheckWinnerFinal(CardPlayer player1, CardPlayer player2)
        {
            var winneris = "NoWinner";

            var who = player1.MaxTotalHand().CompareTo((player2.MaxTotalHand() > 21) ? player2.MinTotalHand() :
                                                                                        player2.MaxTotalHand());

            if (who == 0)
            {
                winneris = string.Format("Have been a Tie to {0} ", player1.MaxTotalHand());
            }
            else if (who < 0)
            {
                winneris = string.Format("You Win!  {0} to {1} ",
                                                          (player2.MaxTotalHand() > 21) ? player2.MinTotalHand() :
                                                                                          player2.MaxTotalHand(),
                                                          player1.MaxTotalHand());
            }
            else
            {
                winneris = string.Format("The Computer is the winner {0} to {1} ", player1.MaxTotalHand(),
                                                              (player2.MaxTotalHand() > 21) ? player2.MinTotalHand() :
                                                                                            player2.MaxTotalHand());
            }

            return winneris;
        }

    }

}
