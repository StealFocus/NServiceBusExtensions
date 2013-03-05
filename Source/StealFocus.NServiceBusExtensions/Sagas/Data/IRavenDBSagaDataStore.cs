namespace StealFocus.NServiceBusExtensions.Sagas.Data
{
    public interface IRavenDBSagaDataStore<T>
    {
        T[] GetSagaDatas(string connectionStringKey);

        T[] GetSagaDatas(string connectionStringKey, int index, int numberOfRecords);
    }
}
