using DAL;
using Models;
namespace dartwebsite.models
{
    public class PlayerViewModel
    {
        public int id { get; set; }
        public string playername { get; set; }

        public string playerpwd { get; set; }
        public int score { get; set; }

        public PlayerViewModel(PlayerModel playermodel)
        {
            id = playermodel.id;
            playername = playermodel.playername;
            score = playermodel.score;
        }
        public PlayerViewModel(){}
    }
}
