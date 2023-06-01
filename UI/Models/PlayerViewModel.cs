using DAL;
namespace UI.Models
{
    public class PlayerViewModel
    {
        public int id { get; set; }
        public string playername { get; set; }

        public string playerpwd { get; set; }
        public int score { get; set; }

        public bool IsSelected { get; set; }

        public PlayerViewModel(PlayerModel playermodel)
        {
            id = playermodel.Player_id;
            playername = playermodel.Name;
            score = playermodel.Score;
        }
        public PlayerViewModel(){}
    }
}