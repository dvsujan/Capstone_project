namespace CofeeStoreManagement.Interfaces
{
    public interface IKeyVaultService
    {
        public Task<string> GetSecretAsync(string secretName); 

    }
}
