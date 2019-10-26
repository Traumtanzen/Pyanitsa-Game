using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyanitsa_Card_Game
{
    class Gameplay
    {
        public List<Card> Player = new List<Card>();
        public List<Card> AIplayer = new List<Card>();
        public List<Card> Swap = new List<Card>();

        Deck deck = new Deck();
        Card card = new Card();

        public void DivideDeck()
        {
            deck.GetGameDeck();
            deck.Shuffle();
            List<Card> ShufDeck = deck.ShuffledDeck;
            Player = ShufDeck.GetRange(0, ShufDeck.Count / 2);
            AIplayer = ShufDeck.GetRange(18, ShufDeck.Count/2);

            Console.WriteLine("\nPlayer:\n");
            foreach (Card pCards in Player)
            {
                Console.WriteLine(card.ShowCard());
            }

            Console.WriteLine("\nAI:\n");
            AIplayer.ForEach(Console.WriteLine);
        }

    }
}
