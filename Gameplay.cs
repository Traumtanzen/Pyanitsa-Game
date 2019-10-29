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
            //foreach (Card card in GameDeck)
            //{
            //    Console.WriteLine(card.ShowCard());
            //}
        }

        public void Shuffle()
        {
            ShuffledDeck = GameDeck.OrderBy(c => Guid.NewGuid()).ToList();
            //foreach (Card card in ShuffledDeck)
            //{
            //    Console.WriteLine(card.ShowCard());
            //}
        }

        public void DivideDeck()
        {
            Player = ShuffledDeck.GetRange(0, ShuffledDeck.Count / 2);
            AIplayer = ShuffledDeck.GetRange(18, ShuffledDeck.Count / 2);
        }
        public void Play()
        {
            Card plCard = Player[0];
            Card aiCard = AIplayer[0];
            while ((Player.Count > 0) || (Player.Count <= 36))
            {
                if (plCard.Face != aiCard.Face)
                {
                    NonEquals();
                    ShowDeck();
                }
                else
                {
                    Equals();
                    ShowDeck();
                }
                Thread.Sleep(200);
                Console.WriteLine("\nPress any key for the next round");
                Console.ReadKey();
            }
            Console.WriteLine("\nGame is over");

        }
        public void Equals()
        {
            Card plCard = Player[0];
            Card aiCard = AIplayer[0];
            Console.WriteLine($"\nYour card is {plCard.ShowCard()}, AI's card is {aiCard.ShowCard()}");
            Console.WriteLine("\nYou have equal values. One more round to find out the getter");
            Swap.Add(plCard);
            Swap.Add(aiCard);
            Player.RemoveAt(0);
            AIplayer.RemoveAt(0);
            NonEquals();
            if (plCard.Face > aiCard.Face)
            {
                Player.AddRange(Swap);
                Swap.Clear();
            }
            else
            {
                AIplayer.AddRange(Swap);
                Swap.Clear();
            }


        }
        public void NonEquals()
        {
            Card plCard = Player[0];
            Card aiCard = AIplayer[0];
            Console.WriteLine($"\nYour card is {plCard.ShowCard()}, AI's card is {aiCard.ShowCard()}");

            if ((plCard.Face > aiCard.Face) || (plCard.Face == Faces.Six && aiCard.Face == Faces.Ace))
            {
                Console.WriteLine("\nYou take the card");
                Swap.Add(plCard);
                Swap.Add(aiCard);
                Player.RemoveAt(0);
                AIplayer.RemoveAt(0);
                Player.AddRange(Swap);
                Swap.Clear();


            }
            else if ((plCard.Face < aiCard.Face) || (aiCard.Face == Faces.Six && plCard.Face == Faces.Ace))
            {
                Console.WriteLine("\nAI takes the card");
                Swap.Add(plCard);
                Swap.Add(aiCard);
                Player.RemoveAt(0);
                AIplayer.RemoveAt(0);
                AIplayer.AddRange(Swap);
                Swap.Clear();

            }
            else
            {
                Equals();
            }
        }
        public void ShowDeck()
        {
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
