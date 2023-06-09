using DAL;
namespace UI.Models
{
    public class PlayerViewModel
    {
        public int id { get; private set; }
        public string playername { get; private set; }

        public string playerpwd { get; private set; }
        public int score { get; private set; }

        public bool IsSelected { get;  set; }

        public string outtext { get; set; }
        public PlayerViewModel(string name, string pwd)
        {
            playername = name;
            playerpwd = pwd;
        }
        public PlayerViewModel() { }
    }
}