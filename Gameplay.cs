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

        public void DivideDeck()
        {
            Player = deck.GameDeck.GetRange(0, deck.GameDeck.Count / 2);
            //AIplayer = deck.GameDeck.GetRange(18, deck.GameDeck.Count / 2);

            Console.WriteLine("\nPlayer:\n");
            foreach (Card pCards in Player)
            {
                Console.WriteLine(pCards);
            }
            Console.WriteLine("\nAI:\n");
            AIplayer.ForEach(Console.WriteLine);
        }

    }
}
