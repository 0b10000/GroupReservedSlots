using System;
using Exiled.API.Features;
using HarmonyLib;
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

        // ReSharper disable once EmptyConstructor
        public Plugin() {
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

                Harmony.PatchAll();

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
