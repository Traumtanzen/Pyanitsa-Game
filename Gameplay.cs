using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Pyanitsa_Card_Game.CardEnums;

namespace Pyanitsa_Card_Game
{
    public class Gameplay
    {
        public List<Card> GameDeck { get; set; }
        public List<Card> ShuffledDeck { get; set; }
        public List<Card> Player = new List<Card>();
        public List<Card> AIplayer = new List<Card>();
        public List<Card> Swap = new List<Card>();

        Card plCard = Player[0];
        Card aiCard = AIplayer[0];

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
        public void Play()
        {
            while ((Player.Count > 0) || (Player.Count <= 36))
            {
                if (plCard.Face != aiCard.Face)
                {
                    NonEquals();
                }
                else
                {
                    Equals();
                }
                Thread.Sleep(200);
                Console.WriteLine("Press any key for the next round");
                Console.ReadKey();
            }
            Console.WriteLine("Game is over");

        }
        public void Equals()
        {
            Console.WriteLine("You have equal values. One more round to find out the getter");
            Swap.Add(plCard);
            Swap.Add(aiCard);
            Player.RemoveAt(0);
            AIplayer.RemoveAt(0);
            NonEquals();
            if (plCard.Face > aiCard.Face)
            {
                Player.Add(aiCard);
                Player.AddRange(Swap);
            }
            else
            {
                AIplayer.Add(plCard);
                AIplayer.AddRange(Swap);
            }
        }
        public void NonEquals()
        {
            Console.WriteLine($"Your card is {plCard}, AI's card is {aiCard}");

            if ((plCard.Face > aiCard.Face) || (plCard.Face == Faces.Six && aiCard.Face == Faces.Ace))
            {
                Console.WriteLine("You take the card");
                Player.Add(aiCard);
                AIplayer.RemoveAt(0);
            }
            else if ((plCard.Face < aiCard.Face) || (aiCard.Face == Faces.Six && plCard.Face == Faces.Ace))
            {
                Console.WriteLine("You take the card");
                AIplayer.Add(plCard);
                Player.RemoveAt(0);
            }
            else
            {
                Equals();
            }
        }
    }
}
