using AutoMapper;
using UI.Models;
using IBLL.Collections;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace dartswebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        private readonly IPlayerCollection _PlayerCollection;
        private readonly IMapper _mapper;

        public HomeController(IPlayerCollection playerCollection,
            IMapper mapper)
        {
            _PlayerCollection = playerCollection;
            _mapper = mapper;
        }
        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(string playername, string playerpwd)
        {
            PlayerViewModel viewplayer = new PlayerViewModel();
            viewplayer.playername = playername;
            viewplayer.playerpwd = playerpwd;

            Player player = _mapper.Map<Player>(viewplayer);
            _PlayerCollection.InsertPlayer(player);
            return RedirectToAction("Playerlist");
        }

        public ActionResult Playerlist()
        {

            List<Player> players = _PlayerCollection.GetAllPlayers().Result.ToList();

            List<PlayerViewModel> viewlist = players.Select(r => _mapper.Map<PlayerViewModel>(r)).ToList();
            foreach (PlayerViewModel player in viewlist) 
            {
                player.IsSelected = false;           
            }
            return View(viewlist);
        }

        [HttpPost]
        public ActionResult PlayersToGame(List<PlayerViewModel> players)
        {
            var selectedPlayers = players.Where(p => p.IsSelected).ToList();


            return RedirectToAction("Players");
        }

        public ActionResult Login(PlayerViewModel? player)
        {
            //bool checkCredentials = Convert.ToBoolean(_userCollection.CheckCredentials(user.Email, user.UserPwd));

            if (_PlayerCollection.CheckCredentials(player.playername, player.playerpwd).Result == true)
            {
                // Save user ID in session
                string playername = _PlayerCollection.GetPlayerByName(player.playername).Result.playername;

                return View("GameSelect");
            }
            else
            {
                throw new Exception("foute gegevens");
            }
            throw new Exception("not yet implemented");
        }
    }
}