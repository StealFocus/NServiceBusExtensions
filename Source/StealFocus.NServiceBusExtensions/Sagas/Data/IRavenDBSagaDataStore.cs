namespace StealFocus.NServiceBusExtensions.Sagas.Data
{
    using NServiceBus.Saga;

    public interface IRavenDBSagaDataStore<out T> where T : IContainSagaData
    {
        T[] GetSagaDatas(string connectionStringKey);

        T[] GetSagaDatas(string connectionStringKey, int index, int numberOfRecords);
    }
}
