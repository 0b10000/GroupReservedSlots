using Exiled.API.Extensions;
using Exiled.API.Features;
using HarmonyLib;

namespace GroupReservedSlots
{
    [HarmonyPatch(typeof(ReservedSlot))]
    [HarmonyPatch(nameof(ReservedSlot.HasReservedSlot))]
    [HarmonyPriority(Priority.Last)]
    // ReSharper disable once UnusedType.Global
    internal static class ReservedSlotPatch
    {
        // ReSharper disable once RedundantAssignment
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Local
        static bool Prefix(ref bool __result, string userId)
        {
            if (Server.PermissionsHandler.GetUserGroup(userId) == null)
            {
                __result = ReservedSlot.Users.Contains(userId.Trim());
                Log.Debug($"{userId}: No group | {__result}", Plugin.Instance.Config.Debug);
            }
            else
            {
                __result = Plugin.Instance.Config.ReservedGroups.Contains(Server.PermissionsHandler.GetUserGroup(userId.Trim()).GetKey()) 
                           || ReservedSlot.Users.Contains(userId.Trim());
                Log.Debug($"{userId}: {Server.PermissionsHandler.GetUserGroup(userId).GetKey()} | {__result}", Plugin.Instance.Config.Debug);
            }

            return false;
        }
    }
}