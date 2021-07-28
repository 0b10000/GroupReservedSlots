using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace GroupReservedSlots
{
    public class Config : IConfig
    {
        [Description("Whether or not this plugin is enabled.")]
        public bool IsEnabled { get; set; }

        [Description("Group names that should get reserved slots")]
        public List<string> ReservedGroups { get; set; } = new List<string>()
        {
            "owner", "admin", "moderator", "donator"
        };

        public bool Debug { get; set; } = false;
    }
}