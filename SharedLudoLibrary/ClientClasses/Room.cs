﻿using SharedLudoLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLudoLibrary.ClientClasses
{
    class Room : IRoom
    {
        private int availablePlaces;
        private int id;
        private string name;
        private string password;

        public int AvailablePlaces
        {
            get
            {
                return availablePlaces;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            //set
            //{
            //    password = value;
            //}
        }


        public Room(int places, int id, string name, string password)
        {
            this.availablePlaces = places;
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }
}