using logic.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic.Models
{
    internal class PlayerModel
    {
        IPlayerData _Playerdata;


        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Reservation> Reservations { get; set; }



        /// <summary>
        /// CTOR for getting Player
        /// </summary>
        /// <param name="DTOPlayer"></param>
        public PlayerModel(seathub_data.Entities.Player DTOPlayer)
        {
            Id = DTOPlayer.id;
            FirstName = DTOPlayer.name_first;
            LastName = DTOPlayer.name_last;
            Email = DTOPlayer.email;
            Password = DTOPlayer.Playerpwd;
            //Reservations = ; need to get reservation methods first
        }

        /// <summary>
        /// CTOR for inserting Player
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public PlayerModel(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// CTOR for updating Player
        /// </summary>
        public PlayerModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }


        /// <summary>
        /// CTOR for updating Player PWD
        /// </summary>
        public PlayerModel(int id, string password)
        {
            Id = id;
            Password = password;
        }


        public async Task UpdatePlayer()
        {
            PlayerController PlayerApi = new();
            await PlayerApi.UpdatePlayer(_Playerdata, this);
        }

        public async Task UpdatePassword()
        {
            PlayerApi PlayerApi = new();
            await PlayerApi.UpdatePassword(_Playerdata, this);
        }
    }
}
