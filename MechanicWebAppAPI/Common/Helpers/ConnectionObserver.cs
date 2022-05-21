using MechanicWebAppAPI.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MechanicWebAppAPI.Common.Helpers
{
    public static class ConnectionObserver
    {
        public static Dictionary<string, CallerEntry> ConnectionStates { get; } = new Dictionary<string, CallerEntry>();
        public static string GetCurrentGroupName(string connectionId)
        {
            return ConnectionStates
                .Where(entry => entry.Key == connectionId)
                .Select(entry => entry.Value.Group)
                .FirstOrDefault();
        }
        public static List<string> GetCallersList(string groupName)
        {
            return ConnectionStates
                .Where(entry => entry.Value.Group == groupName)
                .Select(entry => entry.Value.User_id)
                .ToList();
        }

    }
}
