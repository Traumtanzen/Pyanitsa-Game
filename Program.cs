using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pyanitsa_Card_Game.CardEnums;

namespace Pyanitsa_Card_Game
{
//колода 36 карт, делится пополам
//сначала тусуется
//потом по верхней карте открывается
//большая карта бьет(забирает тот кто побил и кладет вниз)
//шестерка бьет туза
//победил тот, у кого вся колода осела
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new Deck();
            var test2 = new Gameplay();

            Console.WriteLine("Got deck\n");
            test2.GetGameDeck();

            Console.WriteLine("\nShuffled deck\n");
            test2.Shuffle();

            Console.WriteLine("\nCards given\n");
            test2.DivideDeck();




            Console.ReadLine();
        }
    }

















    //Deck deck = new Deck();
    //Console.WriteLine(deck);
    //Console.ReadLine();
}


