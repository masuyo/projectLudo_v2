﻿using pageLudo.FakeData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pageLudo.FakeData.MethodClasses
{
    public class GameStatistics : IGameStatistics
    {
        public List<Something> ColorPieChartData(string gametype)
        {
            throw new NotImplementedException();
        }

        public List<GameNumber> GamePopularity()
        {
            throw new NotImplementedException();
        }

        public int NumberOfOnlineWPFUsers()
        {
            int onlinePlayers = 15;
            return onlinePlayers;
        }
    }
}