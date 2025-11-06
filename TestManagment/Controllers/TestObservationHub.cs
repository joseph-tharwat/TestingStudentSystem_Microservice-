using Azure.Core;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestManagment.PresentaionLayer
{
    public class TestObservationHub:Hub
    {
        static public string teacherConnectionId;
        public override async Task OnConnectedAsync()
        {
            var userRole = Context.GetHttpContext().Request.Headers["x-Role"].ToString();
            if (userRole == "Teacher")
            {
                teacherConnectionId = Context.ConnectionId;
            }

            await base.OnConnectedAsync();
        }
    }
}
