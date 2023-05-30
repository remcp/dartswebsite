using AutoMapper;
using dartwebsite.models;
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
        public ActionResult ShowData()
        {
            PlayerViewModel player = new PlayerViewModel() { id = 2, playername = "bert", score=501 };

            return View(player);
        }
        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult GameSelect()
        {

            return View();
        }

        public ActionResult Playerlist()
        {
            List<Player> players = _PlayerCollection.GetAllPlayers().Result.ToList();

            List<PlayerViewModel> viewlist = (List<PlayerViewModel>)players.Select(r => _mapper.Map<Player>(r));

            return View();
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
