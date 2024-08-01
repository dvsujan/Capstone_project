using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CofeeStoreManagement.Interfaces;

namespace CofeeStoreManagement.services
{
    public class KeyVaultService : IKeyVaultService
    {
        private readonly SecretClient _secretClient;
        private readonly string _valutUrl;

        public KeyVaultService(IConfiguration configuration)
        {
            _valutUrl = configuration["AzureKeyVault:KeyUrl"];
            _secretClient = new SecretClient(new Uri(_valutUrl), new DefaultAzureCredential());
        }

        /// <summary>
        ///  used to retrive the secret value from the key valut
        /// </summary>
        /// <param name="secretName"></param>
        /// <returns></returns>

        public async Task<string> GetSecretAsync(string secretName)
        {
            KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value;
        }
    }
}
