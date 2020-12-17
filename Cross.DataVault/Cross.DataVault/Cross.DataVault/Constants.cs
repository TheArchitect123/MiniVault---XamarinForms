namespace Cross.DataVault
{
    public static class Constants
    {
        /* Replace these values on the build server using a special task */

        //Data Urls
        public const string Data_SecureUrl = "https://www.soliddevs.com/DataVault.Mobile.DataManagement/DataVaultService_WCF.svc";
        public const string Data_InSecureUrl = "http://198.168.0.3/DataVaultService/DataVaultService_WCF.svc";

        //Accounts Urls
        public const string Accounts_SecureUrl = "https://www.soliddevs.com/DataVault.Mobile.AccountManagement/AccountManagement.svc";
        public const string AccountsInSecureUrl = "http://198.168.0.3/DataVaultService.AccountManagement/AccountManagement.svc";


        public const string AppVersion = "1.0.1";
        public const string Author = "Dan Gerchcovich";
        public static string Date = System.DateTime.Now.ToString("dd MM");

        public static string InMemory_ContactID { get; set; } //Reference To the currently logged in site User -- Will be used for querying name, data, etc


        //Content IDs -- Used to query data when editing
        public static string Note_ID { get; set; }
        public static string Photos_ID { get; set; }
        public static string Passwords_ID { get; set; }
        public static string Contact_ID { get; set; }

    }
}
