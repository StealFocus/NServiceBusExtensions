namespace StealFocus.NServiceBusExtensions.Sagas.Data
{
    using System.Linq;

    using NServiceBus.Persistence.Raven;
    using NServiceBus.Saga;

    using Raven.Client;
    using Raven.Client.Document;
    using Raven.Client.Linq;

    using StealFocus.NServiceBusExtensions.Configuration.RavenDB;

    public class RavenDBSagaDataStore<T> : IRavenDBSagaDataStore<T> where T : IContainSagaData
    {
        public T[] GetSagaDatas(string connectionStringKey)
        {
            using (DocumentStore documentStore = new DocumentStore())
            {
                documentStore.ConnectionStringName = connectionStringKey;
                documentStore.ResourceManagerId = ResourceManagerId.SagaStore;
                documentStore.Conventions = new DocumentConvention { FindTypeTagName = new RavenConventions().FindTypeTagName };
                documentStore.Initialize();
                using (IDocumentSession documentSession = documentStore.OpenSession())
                {
                    T[] sagaDataResults =
                        (from policySearchSagaData
                         in documentSession.Query<T>()
                         select policySearchSagaData).ToArray();
                    return sagaDataResults;
                }
            }
        }

        public T[] GetSagaDatas(string connectionStringKey, int index, int numberOfRecords)
        {
            using (DocumentStore documentStore = new DocumentStore())
            {
                documentStore.ConnectionStringName = connectionStringKey;
                documentStore.ResourceManagerId = ResourceManagerId.SagaStore;
                documentStore.Conventions = new DocumentConvention { FindTypeTagName = new RavenConventions().FindTypeTagName };
                documentStore.Initialize();
                using (IDocumentSession documentSession = documentStore.OpenSession())
                {
                    T[] sagaDataResults = documentSession.Query<T>()
                        .Skip(index)
                        .Take(numberOfRecords)
                        .ToArray();
                    return sagaDataResults;
                }
            }
        }
    }
}
