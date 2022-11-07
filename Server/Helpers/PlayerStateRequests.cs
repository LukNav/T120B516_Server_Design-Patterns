﻿using Microsoft.Net.Http.Headers;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.Helpers
{
    public class PlayerStateRequests
    {
        private string endpoint;

        Player _player { get; set; }

        public PlayerStateRequests(Player player)
        {
            _player = player;
            endpoint = "/GetGameState/";
        }

        public HttpResponseMessage GetState()
        {
            string getEndpoint = endpoint;
            return HttpRequests.GetRequest(_player.IpAddress + getEndpoint);
        }
    }

    interface IPlayerStateRequestsAdapter
    {
        GameState GetState();
    }

    public class PlayerStateRequestsAdapter : IPlayerStateRequestsAdapter
    {
        PlayerStateRequests _playerStateRequests;

        public PlayerStateRequestsAdapter(Player player)
        {
            _playerStateRequests = new PlayerStateRequests(player);
        }

        public GameState GetState()
        {
            return _playerStateRequests.GetState().Deserialize<GameState>(;
        }
    }
}