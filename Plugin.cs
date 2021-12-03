using System;
using Exiled.API.Features;

namespace GroupReservedSlots
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "0b10000";
        public override string Name => "GroupReservedSlots";
        public override string Prefix => "GroupReservedSlots";
        public override Version Version { get; } = new Version(3, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 1, 2);
        
        public static Plugin Instance;

        private EventHandlers _handler;

        // ReSharper disable once EmptyConstructor
        public Plugin() {
        }

        public override void OnEnabled()
        {
            Instance = this;
            _handler = new EventHandlers();

            Exiled.Events.Handlers.Player.PreAuthenticating += _handler.OnPreAuthenticating;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            
            Exiled.Events.Handlers.Player.PreAuthenticating -= _handler.OnPreAuthenticating;
            
            base.OnDisabled();
        }
    }
}
