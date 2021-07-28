using System;
using Exiled.API.Features;
using HarmonyLib;
using MapEvents = Exiled.Events.Handlers.Map;
using PlayerEvents = Exiled.Events.Handlers.Player;
using Scp049Events = Exiled.Events.Handlers.Scp049;
using Scp079Events = Exiled.Events.Handlers.Scp079;
using Scp096Events = Exiled.Events.Handlers.Scp096;
using Scp106Events = Exiled.Events.Handlers.Scp106;
using Scp914Events = Exiled.Events.Handlers.Scp914;
using ServerEvents = Exiled.Events.Handlers.Server;
using WarheadEvents = Exiled.Events.Handlers.Warhead;
// ReSharper disable StringLiteralTypo

namespace GroupReservedSlots
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "0b10000";
        public override string Name => "GroupReservedSlots";
        public override string Prefix => "GroupReservedSlots";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 11, 1);

        public Harmony Harmony { get; private set; }

        public static Plugin Instance;

        private Plugin() {
        }

        public override void OnEnabled()
        {
            Instance = this;
            
            Patch();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            
            Unpatch();
            base.OnDisabled();
        }
        
        private void Patch()
        {
            try
            {
                Harmony = new Harmony("0b10000.groupreservedslots");

                var lastDebugStatus = Harmony.DEBUG;
                Harmony.DEBUG = true;
                
                Harmony.PatchAll();

                Harmony.DEBUG = lastDebugStatus;
                Log.Info("Patched successfully!");
            }
            catch (Exception e)
            {
                Log.Error($"Exception occured during patching: {e}");
            }
        }

        private void Unpatch()
        {
            Harmony.UnpatchAll();
            Log.Info("Unpatched patches!");
        }
    }
}