using Flunt.Notifications;
using GTI.Shared.Commands.Interfaces;

namespace GTI.Shared.Commands
{
    public abstract class BaseCommand : Notifiable<Notification>, ICommand
    {
        public abstract void Validate();
    }
}
