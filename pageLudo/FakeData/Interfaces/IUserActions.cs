﻿using pageLudo.FakeData.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pageLudo.FakeData.Interfaces
{
    public interface IUserActions
    {
        //reg
        //itt kéne akkor kapnia még egy guIDot is gondolom
        bool Register(string Username, string Password, string EmailID);

        //Login - azért kérem vissza a full usert, mert a nevét a későbbiekben felhasználom az oldalon 
        //meg az id-jét sessionhöz, de ha van jobb ötleted, szólj
        UserData UserCheck(string EmailID, string Password);

        //Friending - ehhez mondjuk kell az oldalra még egy kereső is (userek közt), 
        //és nem tudom, hogy nyerem vissza a keresett user azonosítóját még, ill hogy kérdezem le tőled, 
        //valszeg email alapján lesz majd az is
        bool Friend(string BeMyFriendEmailID, string IMightBecomeYourFriendEmailID);

        //Friend accept - oda-vissza meglegyen, tessék, mókás változónevek : D
        bool FriendAccept(string IWillBeYourFriendEmailID, string ThanksForAcceptingMeAsYourFriendEmailID);

        //Unfriend - egyik fél dönti el, mint a válásnál, és megtörténik xD
        bool Unfriend(string YouAreNotMyFriendAnymoreEmailID, string IDidntWantYouAnywayEmailID);

        /*search - user kikeresése email vagy név alapján; vissza kéne kapnom mindenképp usert: név, email, 
         * friendek vagyunk-e (velem, aki kerestem, ehhez gondolom, kell majd még egy lekérdezés?), 
        utóbbinak az emailjét fogom beadni; gondolom, ha nem talál semmit, akkor dobjon nekem egy nullt?, 
        nem tudom, egyelőre eszerint írtam meg nálam*/
        List<UserData> UsernameSearch(string username, string searcherEmailID);

        //ugyanazt csinálja, mint az előző, csak emailben keres
        UserData EmaildIDSearch(string emailID, string searcherEmailID);
    }
}