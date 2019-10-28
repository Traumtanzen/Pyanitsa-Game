using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pyanitsa_Card_Game.CardEnums;

namespace Pyanitsa_Card_Game
{
    class Gameplay
    {
        public List<Card> GameDeck { get; set; }
        public List<Card> ShuffledDeck { get; set; }
        public List<Card> Player = new List<Card>();
        public List<Card> AIplayer = new List<Card>();
        //public List<Card> Swap = new List<Card>();

        public void GetGameDeck()
        {
            GameDeck = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Faces face in Enum.GetValues(typeof(Faces)))
                {
                    GameDeck.Add(new Card { Suit = suit, Face = face });
                }
            }
            foreach (Card card in GameDeck)
            {
                Console.WriteLine(card.ShowCard());
            }
        }

        public void Shuffle()
        {
            ShuffledDeck = GameDeck.OrderBy(c => Guid.NewGuid()).ToList();
            foreach (Card card in ShuffledDeck)
            {
                Console.WriteLine(card.ShowCard());
            }
        }

        public void DivideDeck()
        {
            Player = ShuffledDeck.GetRange(0, ShuffledDeck.Count / 2);
            AIplayer = ShuffledDeck.GetRange(18, ShuffledDeck.Count / 2);

            Console.WriteLine("\nPlayer:\n");
            foreach (Card pCards in Player)
            {
                Console.WriteLine(pCards.ShowCard());
            }
            Console.WriteLine("\nAI:\n");
            foreach (Card aiCards in AIplayer)
            {
                Console.WriteLine(aiCards.ShowCard());
            }
        }

    }
}
