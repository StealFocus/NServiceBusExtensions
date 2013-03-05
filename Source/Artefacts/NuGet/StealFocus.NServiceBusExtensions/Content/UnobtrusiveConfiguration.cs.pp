namespace $rootnamespace$
{
    using System.Diagnostics.CodeAnalysis;

    using $rootnamespace$.Configuration;

    using NServiceBus;

    [ExcludeFromCodeCoverage]
    public class UnobtrusiveConfiguration : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance
                .DefiningEventsAs(MessageType.IsEvent)
                .DefiningCommandsAs(MessageType.IsCommand)
                .DefiningMessagesAs(MessageType.IsMessage);
        }
    }
}
