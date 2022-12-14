namespace Restaurant.API.Model
{
    public class AzureAdSettings
    {
        public string Instance { get; set; }

        public string Domain { get; set; }  

        public string TenantId { get; set; }

        public string ClientId { get; set; }    

        public string CallbackPath { get; set; }    

        public string Scopes { get; set; }

        public AzureAdSettings()
        {
            Instance= string.Empty;
            Domain= string.Empty;
            TenantId= string.Empty;
            ClientId= string.Empty;
            CallbackPath= string.Empty;
            Scopes= string.Empty;
        }
    }
}
