﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRServer.MVCData.DataClasses
{
    public class GameWinrate
    {
        public string GameName { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }
        public int NumberOfGames { get; set; }
        public string ColorName { get; set; }
        public int AverageNumberOfTurns { get; set; }
        public int NumberOfTurnsOfTheLongestGame { get; set; }
        public int NumberOfTurnsOfTheShortestGame { get; set; }
    }
}