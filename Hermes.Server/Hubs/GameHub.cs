using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace Hermes.Server.Hubs
{
    public class GameHub : Hub
    {
        private static readonly ConcurrentDictionary<> _players =
        public async Task Join(string username)
        {
            int userId = 
        }
        public async Task MoveCharacter(string Username, int x, int y)
        {
            
            await Clients.All.SendAsync("MoveCharacter", Username, x, y);
        }
        
    }
}
