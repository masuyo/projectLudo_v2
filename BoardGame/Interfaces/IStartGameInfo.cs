﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Interfaces
{
    interface IStartGameInfo
    {
        IPlayer WPFPlayer { get; }
        IPlayer[] otherWPFPlayers { get; }
        IGameInfo MsgFromServer { get; }
    }
}
