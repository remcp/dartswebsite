using logic.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Data;
namespace logic.Models
{
    public class PlayerModel
    {
        IPlayerdata _playerdata;
        public int id { get; set; }
        public string playername { get; set; }
        public int score { get; set; }


        /// <summary>
        /// CTOR for getting Player
        /// </summary>
        /// <param name="DTOPlayer"></param>
        public PlayerModel(Api.PlayerModel DTOPlayer)
        {
            id = DTOPlayer.id;
            playername = DTOPlayer.playername;
            score = DTOPlayer.score;
        }

        /// <summary>
        /// CTOR for inserting Player
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public PlayerModel(string name, int points)
        {
            playername = name;
            score = points;
        }

        /// <summary>
        /// CTOR for updating Player
        /// </summary>
        public PlayerModel(int identify, string name, int points)
        {
            id = identify;
            playername = name;
            score = points;
        }



        public async Task UpdatePlayer()
        {
            PlayerCollection playercontroller = new();
            await playercontroller.Updateplayer(this);
        }
    }
}