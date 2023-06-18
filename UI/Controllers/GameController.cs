using AutoMapper;
using BLL.collection;
using DAL;
using IBLL.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using UI.Models;

namespace UI.Controllers
{
    public class GameController : Controller
    {

        private readonly IPlayerCollection _PlayerCollection;
        private readonly IGameCollection _GameCollection;
        private readonly IMapper _mapper;

        public GameController(IPlayerCollection playerCollection,
            IMapper mapper, IGameCollection gamecollection)
        {
            _PlayerCollection = playerCollection;
            _mapper = mapper;
            _GameCollection = gamecollection;
        }

        [HttpPost]
        public ActionResult PlayersToGame(List<string> players)
        {
            return RedirectToAction("GameSelect", new {players = players});
        }

        public ActionResult GameSelect(List<string> players)
        {
            //List<PlayerViewModel> playerlist = new List<PlayerViewModel>();
            //foreach (var player in players)
            //{
            //    playerlist.Add(_mapper.Map<PlayerViewModel>(_PlayerCollection.GetPlayerByName(player).Result));
            //}

            List<Game> games = _GameCollection.GetAllGames().Result.ToList();
            List<GameViewModel> viewgames = games.Select(r => _mapper.Map<GameViewModel>(r)).ToList();


            var tupleModel = new Tuple<List<string>, List<GameViewModel>>(players, viewgames);

            return View(tupleModel);
        }

        public ActionResult ActiveGames()
        {
            List<string> playernamelist1 = new List<string>();
            List<string> playernamelist2 = new List<string>();
            Player playermodel = new Player();
            List<Player> playermodellist1 = _GameCollection.GetPlayersActiveGame(1).Result.ToList();
            List<Player> playermodellist2 = _GameCollection.GetPlayersActiveGame(2).Result.ToList();

            foreach (Player player in playermodellist1)
            {
                playermodel = _PlayerCollection.GetPlayer(player.id).Result;
                playernamelist1.Add(playermodel.playername);
            }
            foreach (Player player in playermodellist2)
            {
				playermodel = _PlayerCollection.GetPlayer(player.id).Result;
				playernamelist2.Add(playermodel.playername);
            }

            List<Game> games = _GameCollection.GetAllGames().Result.ToList();
            List<GameViewModel> viewgames = games.Select(r => _mapper.Map<GameViewModel>(r)).ToList();


            var tupleModel = new Tuple<List<string>, List<string>, List<GameViewModel>>(playernamelist1, playernamelist2, viewgames);

            return View(tupleModel);
        }
        public ActionResult MakeGame(List<string> players, int beginscore)
        {
            int gameid = 0;
            List<PlayerViewModel> playerlist = new List<PlayerViewModel>();

            if (beginscore == 501)
            {
                gameid = 1;
            }
            else if (beginscore == 301)
            {
                gameid = 2;
            }
            _GameCollection.DeleteActiveGame(gameid);
            foreach (var player in players)
            {
                Player playermodel = _PlayerCollection.GetPlayerByName(player).Result;
                _GameCollection.InsertPlayer(gameid, playermodel);
                _PlayerCollection.SetScore(playermodel, beginscore);
                playerlist.Add(_mapper.Map<PlayerViewModel>(playermodel));
            }
            

            var tupleModel = new Tuple<List<PlayerViewModel>, int>(playerlist, 0);
            return View("Game", tupleModel);
        }


        public ActionResult Game(List<string> players, int beginscore)
        {
            List<PlayerViewModel> playerlist = new List<PlayerViewModel>();
            foreach (var player in players)
            {
                Player playermodel = _PlayerCollection.GetPlayerByName(player).Result;
                _PlayerCollection.SetScore(playermodel, beginscore);
                playerlist.Add(_mapper.Map<PlayerViewModel>(playermodel));
            }
            var tupleModel = new Tuple<List<PlayerViewModel>, int>(playerlist, 0);
            return View(tupleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateScore(List<string> players, int turn, int input)
        {
            List<PlayerViewModel> playerlist = new List<PlayerViewModel>();
            try
            {
                foreach (var player in players)
                {
                    Player playermodel = new();
                    try
                    {
                        playermodel = _PlayerCollection.GetPlayerByName(player).Result;
                    }
                    catch
                    {
                        ViewBag.ErrorMessage = "connection to database could not be made, contact the admin";
                    }
                    if (playerlist.Count == turn)
                    {
                        playermodel = _PlayerCollection.UpdateScore(playermodel, input).Result;
                    }
                    string outtext = _PlayerCollection.GetOutText(playermodel).Result;
                    PlayerViewModel viewplayer = _mapper.Map<PlayerViewModel>(playermodel);
                    viewplayer.outtext = outtext;
                    playerlist.Add(viewplayer);
                    
                }
            }
            catch
            {
                playerlist = new List<PlayerViewModel>();
                foreach (var player in players)
                {
                    
                    Player playermodel = _PlayerCollection.GetPlayerByName(player).Result;
                    string outtext = _PlayerCollection.GetOutText(playermodel).Result;
                    PlayerViewModel viewplayer = _mapper.Map<PlayerViewModel>(playermodel);
                    viewplayer.outtext = outtext;
                    playerlist.Add(viewplayer);
                }
                var wronginput = new Tuple<List<PlayerViewModel>, int>(playerlist, turn);
                ViewBag.ErrorMessage = "impossible score";
                return View("Game", wronginput);
            }
            turn++;
                if (turn > players.Count - 1)
                {
                    turn = 0;
                }
            
            var tupleModel = new Tuple<List<PlayerViewModel>, int>(playerlist, turn);

            return View("Game", tupleModel);
        }
    }
}