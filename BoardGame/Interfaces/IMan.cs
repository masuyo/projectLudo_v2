﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Interfaces
{
    interface IMan
    {
        int ID { get; set; }
        int Poz { get; set; }
        Player Player { get; set; }
    }
}
