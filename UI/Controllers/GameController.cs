using AutoMapper;
using BLL.collection;
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
            IMapper mapper)
        {
            _PlayerCollection = playerCollection;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult PlayersToGame(List<PlayerViewModel> players)
        {
            var selectedPlayers = players.Where(p => p.IsSelected).ToList();


            return RedirectToAction("Gameselect", new {selectedPlayers});
        }

        public ActionResult GameSelect(List<PlayerViewModel> players)
        {
            List<Game> games = _GameCollection.GetAllGames().Result.ToList();
            List<GameViewModel> viewgames = games.Select(r => _mapper.Map<GameViewModel>(r)).ToList();


            var tupleModel = new Tuple<List<PlayerViewModel>, List<GameViewModel>>(players, viewgames);

            return View(tupleModel);
        }
    }
}