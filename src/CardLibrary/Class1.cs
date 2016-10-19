using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardLibrary
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
   
    /// <summary>
    /// A class for the definition and management of the basic concept of one Card. 
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Unique identifier of the card for internal topics.
        /// </summary>
        public int CardId { get; set; }
        /// <summary>
        /// Name of the set of cards to whom belong the card.
        /// </summary>
        public string Deck { get; set; }
        /// <summary>
        /// Name of the card (ONE, TWO, KING, etc)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The minimun value that represent the card in the game.
        /// </summary>
        public int MinValue { get; set; }
        /// <summary>
        /// The maximun value that represent the card in the game.
        /// </summary>
        public int MaxValue { get; set; }
        /// <summary>
        /// Status that say if the card was already played during a hand
        /// </summary>
        public bool Played { get; set; }

        /// <summary>
        /// The complete name of the card including number (in letters) and type (set), return a string.
        /// </summary>
        /// <returns>Return a string with the Name and Type (set) of the card</returns>
        public string Face()
        {
            return (Name + " of " + Deck);
        }

        private List<string> DeckSet = new List<string>();

        /// <summary>
        /// A List with the name of the sets (types) of cards.
        /// </summary>
        /// <returns> Return a List with all the types of Cards</returns>
        public List<string> DecksCards()
        {
            DeckSet.Add("Swords");
            DeckSet.Add("Hearts");
            DeckSet.Add("Diamonds");
            DeckSet.Add("Clubs");

            return DeckSet;
        }
    }
}
