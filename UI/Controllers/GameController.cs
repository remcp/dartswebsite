
using AutoMapper;
using BLL.collection;
using DAL;
using IBLL.Collections;
using Microsoft.AspNetCore.Mvc;
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

        public ActionResult UpdateScore(List<string> players, int turn, int input)
        {
            List<PlayerViewModel> playerlist = new List<PlayerViewModel>();
            try
            {
                foreach (var player in players)
                {

                    Player playermodel = _PlayerCollection.GetPlayerByName(player).Result;
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