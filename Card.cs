using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pyanitsa_Card_Game.CardEnums;

namespace Pyanitsa_Card_Game
{
    public class Card
    {
        public Suits Suit { get; set; }
        public Faces Face { get; set; }

        public string ShowCard()
        {
            return $"{Face} of {Suit}";
        }
    }
}
