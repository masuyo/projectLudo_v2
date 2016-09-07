﻿using BoardGame.Interfaces;
using BoardGame.Views;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoardGame
{
    /// <summary>
    /// Interaction logic for LudoWindow.xaml
    /// </summary>
    public partial class LudoWindow : Window
    {
        LudoView VM;

        public String UserName { get; set; }

        //ezen keresztül fogod elérni a hubomat, amit a szerver oldalon osztályt csináltam, lásd lentebb
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        public HubConnection Connection { get; set; }


        public LudoWindow(string username)
        {
            InitializeComponent();
            UserName = username;
            VM = LudoView.GetVM;
            this.DataContext = VM;

            //connect to server with ConnectAsync(); display what's happening
            VM.ServerMsgs.Add(UserName + ":: Connecting to server...");
            ConnectAsync();
        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            Connection.StateChanged += (e) => { Console.WriteLine(e.NewState); };

            HubProxy = Connection.CreateHubProxy("MyHub");

            ///WPF client defines its method
            HubProxy.On<string>("addMessage", (msg) =>
               this.Dispatcher.Invoke(() =>
                   VM.ChatMsgs.Add(msg)
               )
           );

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                this.Dispatcher.Invoke(() =>
                VM.ServerMsgs.Add("Unable to connect to server.")
                );
                return;
            }
            this.Dispatcher.Invoke(() =>
           VM.ServerMsgs.Add("Connected to server.")
           );
        }


        void Connection_Closed()
        {
            this.Dispatcher.Invoke(() =>
           VM.ServerMsgs.Add("Disconnected from server.")
           );
        }

        private void WPFClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        private void TXB_Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ///WPF client defines method call on server side
                HubProxy.Invoke("Send", VM.ChatMsg);
                VM.ChatMsg = String.Empty;
            }
        }
    }
}
