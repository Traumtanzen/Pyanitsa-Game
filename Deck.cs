using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pyanitsa_Card_Game.CardEnums;

namespace Pyanitsa_Card_Game
{
    public class Deck
    {
        public List<Card> GameDeck;
        public List<Card> ShuffledDeck;


        public void GetGameDeck()
        {
            GameDeck = new List<Card>();
            for (int suit = 0; suit < 4; suit++)
            {
                for (int face = 0; face < 9; face++)
                {
                    GameDeck.Add(new Card() { Suit = (Suits)suit, Face = (Faces)face });
                    if (face <= 8) GameDeck[GameDeck.Count - 1].Value = face + 1;
                }
            }
            foreach (Card card in GameDeck)
            {
                Console.WriteLine(card.ShowCard());
            }
        }
        public void Shuffle()
        {
            Random range = new Random();
            int n = GameDeck.Count;
            while (n > 1)
            {
                n--;
                int k = range.Next(n + 1);
                Card card = GameDeck[k];
                GameDeck[k] = GameDeck[n];
                GameDeck[n] = card;
            }
            ShuffledDeck = new List<Card>();
            foreach (Card card in GameDeck)
            {
                ShuffledDeck.Add(card);
            }
            foreach (Card card in ShuffledDeck)
            {
                Console.WriteLine(card.ShowCard());
            }
        }
    }
}
