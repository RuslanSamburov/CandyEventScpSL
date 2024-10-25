﻿using CandyEvent.Commands;
using CandyEvent.Events;
using Exiled.API.Features;
using MEC;
using System;

namespace CandyEvent
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "CandyEvent";
        public override string Author => "Руслан0308c";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

        public static Plugin Singleton;
        public CoroutineHandle _candyCoroutine;
        public Management _management;

        private ServerHandlers _serverHandlers;

        public override void OnEnabled()
        {
            _management = new Management();
            _serverHandlers = new ServerHandlers();

            Singleton = this;
            Exiled.Events.Handlers.Server.RoundEnded += _serverHandlers.OnRoundEnded;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= _serverHandlers.OnRoundEnded;
            Timing.KillCoroutines(_candyCoroutine);
            Singleton = null;

            base.OnDisabled();
        }
    }
}