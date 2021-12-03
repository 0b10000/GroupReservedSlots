using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace GroupReservedSlots
{
    internal sealed class EventHandlers
    {
        public void OnPreAuthenticating(PreAuthenticatingEventArgs ev)
        {
            var group = Server.PermissionsHandler.GetUserGroup(ev.UserId);
            if (group == null) return;

            bool reserved = Plugin.Instance.Config.ReservedGroups.Contains(group.GetKey());
            if (reserved) ev.IsAllowed = true;
            Log.Debug($"{ev.UserId}: {group.GetKey()} | {reserved}", Plugin.Instance.Config.Debug);
        }
    }
}