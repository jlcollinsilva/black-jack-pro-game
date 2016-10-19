using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardLibrary;

namespace PlayerLibrary
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".

    /// <summary>
    /// A class for the definition and management of the player (card player) object
    /// </summary>
    public class CardPlayer
    {
        /// <summary>
        /// A string with the name of the Player.
        /// </summary>
        public string Name { get; set; }

        private List<Card> _handPlayer = new List<Card>();

        /// <summary>
        /// A List with all the cards for a player in one specific hand
        /// </summary>
        public List<Card> HandPlayer
        {
            get
            {
                return _handPlayer;
            }
        }

        /// <summary>
        /// A function that indirectly represent the set action for the HandPlayer property, also update the property Played for the object Deck (set of cards).
        /// </summary>
        /// <param name="deck">The complete set of cards that are used in a game</param>
        /// <returns>Bool indicator if was possible to provide the card</returns>
        public bool RequestCard(Dictionary<int, Card> deck)
        {
            Random rnd = new Random();
            int idcard = 0;
            bool cardGiven = false;
            Card currentCard = new Card();

            do
            {
                // This random sequence is equivalent to a give a card after to mixed the cards
                idcard = rnd.Next(1, deck.Count()+1);

                currentCard = deck[idcard]; //extrac the object (card) to be played

                if (!currentCard.Played) //Discard the card if was previously played
                {
                    HandPlayer.Add(currentCard);
                    deck[idcard].Played = true;
                    cardGiven = true;
                }
                else
                {
                    idcard = 0;
                }

            } while (idcard == 0);

            return cardGiven;
        }

        /// <summary>
        /// Sum the total value of the card using their lowest value in the game.
        /// </summary>
        /// <returns>A integer with the total sum of value</returns>
        public int MinTotalHand()
        {
            var totalhand = 0;

            foreach (var hand in HandPlayer)
            {
                totalhand += hand.MinValue;
            }

            return totalhand;
        }

        /// <summary>
        /// Sum the total value of the card using their Highst value in the game.
        /// </summary>
        /// <returns>A integer with the total sum of value</returns>
        public int MaxTotalHand()
        {
            var totalhand = 0;

            foreach (var hand in HandPlayer)
            {
                totalhand += hand.MaxValue;
            }

            return totalhand;
        }

        /// <summary>
        /// Create a list of all the Face content (Number/Name and Type/Set/Deck) for all the cards of a hand of player in a game. 
        /// </summary>
        /// <returns>Return a string with the list of tha Face of the cards</returns>
        public string showCards()
        {
            string faceCards = "\r\n";

            foreach (var hand in HandPlayer)
            {
                faceCards += hand.Face() + "\r\n";
            }

            return faceCards;
        }
    }
}
