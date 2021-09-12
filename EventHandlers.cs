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
            if (Plugin.Instance.Config.ReservedGroups.Contains(group
                .GetKey())) ev.IsAllowed = true;
            Log.Debug($"{ev.UserId}: ${group} | {ev.IsAllowed}");
        }
    }
}