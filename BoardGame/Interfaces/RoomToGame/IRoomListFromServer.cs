﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Interfaces.RoomToGame
{
    interface IRoomListFromServer
    {
        List<IRoom> RoomList { get;}

    }
}