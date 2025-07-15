namespace Shopee.Domain.Constants;

public static class ConfigKeys
{
    public const string AutoMigration = "AutoMigration";

    public struct Databases
    {
        public const string Connection = "ConnectionStrings:MyDatabase";

        public const string MaxRetryCount = "Database:MaxRetryCount";
        public const string MaxRetryDelaySec = "Database:MaxRetryDelaySec";
        public const string VersionMajor = "Database:Version:Major";
        public const string VersionMinor = "Database:Version:Minor";
    }
}
