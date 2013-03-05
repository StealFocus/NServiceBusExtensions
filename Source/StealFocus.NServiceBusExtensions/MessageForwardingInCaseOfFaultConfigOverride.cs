namespace StealFocus.NServiceBusExtensions
{
    using System.Globalization;

    using NServiceBus.Config;
    using NServiceBus.Config.ConfigurationSource;

    public class MessageForwardingInCaseOfFaultConfigOverride : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
                {
                    ErrorQueue = string.Format(CultureInfo.CurrentCulture, "{0}.Error", NServiceBus.Configure.EndpointName)
                };
        }
    }
}
