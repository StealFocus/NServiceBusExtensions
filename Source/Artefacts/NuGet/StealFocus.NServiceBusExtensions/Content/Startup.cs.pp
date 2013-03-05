namespace $rootnamespace$
{
    using System.Diagnostics.CodeAnalysis;

    using NServiceBus;

    [ExcludeFromCodeCoverage]
    public class Startup : IWantToRunAtStartup
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            // It is preferred to set the subscriptions in configuration (rather than in code here) so that:
            // - Endpoint behaviour can be identified at run time by looking at the config (subscriptions in compiled code can't be looked at).
            // - An Endpoint can be scaled out (different instances of the same endpoint dealing with different message types).
        }

        public void Stop()
        {
            // It is preferred not to unsubscribe from subscriptions (here, in code) so when 
			// the service is stopped, it continues to receive messages from the publisher.
        }
    }
}
