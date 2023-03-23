namespace dartswebsite.models
{
    public class PlayerViewModel
    {
        public int id { get; set; }
        public string playername { get; set; }
        public int score { get; set; }

        public PlayerViewModel(logic.Models.PlayerModel playermodel)
        {
            id = playermodel.id;
            playername = playermodel.playername;
            score = playermodel.score;
        }
        public PlayerViewModel(){}
    }
}
