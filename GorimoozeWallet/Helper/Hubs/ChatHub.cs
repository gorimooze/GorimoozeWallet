using GorimoozeWallet.Data;
using GorimoozeWallet.Helper.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GorimoozeWallet.Helper.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IConfiguration _configuration;
        private readonly GorimoozeWalletDbContext _context;

        public ChatHub(IConfiguration configuration, GorimoozeWalletDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var accessToken = httpContext.Request.Query["access_token"];

            var userId = _configuration.GetUserIdFromToken(accessToken);
            if (userId != null)
            {
                // Подписываем соединение на канал, специфичный для пользователя
                await Groups.AddToGroupAsync(Context.ConnectionId, userId.Value.ToString());
            }

            await base.OnConnectedAsync();
        }

        //public async Task SendMessage(string targetUserId, string message)
        //{
        //    // Отправляем сообщение обратно вызывающему клиенту
        //    await Clients.Caller.SendAsync("ReceiveMessage", Context.UserIdentifier, message);
        //}

        //public async Task SendMessage(string targetUserId, string message, string token)
        //{
        //    var userId = _configuration.GetUserIdFromToken(token);

        //    var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        //    var userReturn = findUser.FirstName + " " + findUser.LastName;

        //    // Отправляем сообщение пользователю с указанным UserId
        //    await Clients.User(targetUserId).SendAsync("ReceiveMessage", userReturn, message);
        //}

        public async Task SendMessage(string userId, string message)
        {
            var httpContext = Context.GetHttpContext();
            var accessToken = httpContext.Request.Query["access_token"];

            var userId2 = _configuration.GetUserIdFromToken(accessToken);

                var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId2);
                var userReturn = findUser.FirstName + " " + findUser.LastName;

            // Отправка сообщения всем пользователям
            //await Clients.All.SendAsync("ReceiveMessage", userReturn, message);

            // Или, если нужно отправить сообщение конкретному пользователю:
            await Clients.Group(userId).SendAsync("ReceiveMessage", userReturn, message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            var accessToken = httpContext.Request.Query["access_token"];

            var userId = _configuration.GetUserIdFromToken(accessToken);
            if (userId != null)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId.Value.ToString());
            }

            await base.OnDisconnectedAsync(exception);
        }
    }

}
