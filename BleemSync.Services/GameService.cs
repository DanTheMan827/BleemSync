﻿using BleemSync.Data.Models;
using System;
using SharpConfig;
using System.Linq;

namespace BleemSync.Services
{
    public class GameService
    {
        public GameInfo GetGameInfo(int gameId)
        {
            var gamesDirectory = Utilities.Filesystem.GetGamesDirectory();

            var config = Configuration.LoadFromFile($"{gamesDirectory}\\{gameId}\\Game.ini");
            var section = config["Game"];

            var game = new GameInfo()
            {
                Id = gameId,
                Title = section["Title"].StringValue,
                Publisher = section["Publisher"].StringValue,
                Year = section["Year"].IntValue,
                Players = section["Players"].IntValue,
                DiscIds = section["Discs"].StringValue.Split(',').ToList()
            };

            return game;
        }
    }
}
