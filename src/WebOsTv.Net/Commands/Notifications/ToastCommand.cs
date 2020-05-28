namespace WebOsTv.Net.Commands.Notifications
{
    public class ToastCommand : CommandBase
    {
        public override string Uri => "ssap://system.notifications/createToast";

        public string Message { get; set; }
    }
}
