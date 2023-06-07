using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {

        public int id { get; private set; }
        public string playername { get; private set; }
        public string playerpwd { get; private set; }
        public int score { get; private set; }

        public Player UpdateScore(Player player, int input)
        {
            player.score =  player.score - input;
            return player;
        }

        public Player SetScore(Player player, int input)
        {
            player.score = input;
            return player;
        }
    }

    
}
