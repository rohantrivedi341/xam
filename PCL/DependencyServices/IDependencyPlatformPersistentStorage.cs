using System;

namespace PCL.DependencyServices
{
    public interface IDependencyPlatformPersistentStorage
    {
        Int32 GetValueOrDefaultInt32(String key, Int32 defaultValue);
        Boolean AddOrUpdateValueInt32(String key, Int32 value);

        Boolean GetValueOrDefaultBoolean(String key, Boolean defaultValue);
        Boolean AddOrUpdateValueBoolean(String key, Boolean value);

        DateTime GetValueOrDefaultDateTime(String key, DateTime defaultValue);
        Boolean AddOrUpdateValueDateTime(String key, DateTime value);

        //T GetValueOrDefault<T>(String key, T defaultValue = default(T));
        //Boolean AddOrUpdateValue(String key, Object value);
        
        void Save();
    }

    public class DependencyPlatformPersistentStorageConstants
    {
        public const String ApplicationVersion = "application_version";
        public const String UpdateAvailableApplication = "update_available_application";
        public const String UpdateAvailableApplicationDateTime = "update_available_application_date_time";
        
        public const String ContentVersion = "content_version";
        public const String UpdateAvailableContent = "update_available_content";
        public const String UpdateAvailableContentDateTime = "update_available_content_date_time";
    }
}