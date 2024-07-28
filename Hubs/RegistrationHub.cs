using Microsoft.AspNetCore.SignalR;

namespace Registrar.Hubs
{
    public class RegistrationHub : Hub
    {
        public async Task RegisterStudent(int studentId, int courseId)
        {
            await Clients.All.SendAsync("ReceiveRegistration", studentId, courseId);
        }

        public async Task UnregisterStudent(int studentId, int courseId)
        {
            await Clients.All.SendAsync("ReceiveUnregistration", studentId, courseId);
        }
    }
}
