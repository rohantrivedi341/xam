using System;
using Android.Content;
using Android.Preferences;
using Droid.DependencyServices;
using PCL.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_Droid_PersistentStorage))]

namespace Droid.DependencyServices
{
    public class DependencyPlatform_Droid_PersistentStorage : IDependencyPlatformPersistentStorage
    {
        private readonly object _locker = new object();

        public DependencyPlatform_Droid_PersistentStorage()
        {
            DependencyPlatform_Droid_PersistentStorage.SharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Forms.Context);
            DependencyPlatform_Droid_PersistentStorage.SharedPreferencesEditor = DependencyPlatform_Droid_PersistentStorage.SharedPreferences.Edit();
        }

        private static ISharedPreferences SharedPreferences { get; set; }

        private static ISharedPreferencesEditor SharedPreferencesEditor { get; set; }

        public Int32 GetValueOrDefaultInt32(String key, Int32 defaultValue)
        {
            lock (this._locker)
            {
                return DependencyPlatform_Droid_PersistentStorage.SharedPreferences.GetInt(key, Convert.ToInt32(defaultValue));
            }
        }

        public Boolean AddOrUpdateValueInt32(String key, Int32 value)
        {
            lock (this._locker)
            {
                DependencyPlatform_Droid_PersistentStorage.SharedPreferencesEditor.PutInt(key, value);

                return true;
            }
        }

        public Boolean GetValueOrDefaultBoolean(String key, Boolean defaultValue)
        {
            lock (this._locker)
            {
                return DependencyPlatform_Droid_PersistentStorage.SharedPreferences.GetBoolean(key, Convert.ToBoolean(defaultValue));
            }
        }

        public Boolean AddOrUpdateValueBoolean(String key, Boolean value)
        {
            lock (this._locker)
            {
                DependencyPlatform_Droid_PersistentStorage.SharedPreferencesEditor.PutBoolean(key, value);

                return true;
            }
        }

        public DateTime GetValueOrDefaultDateTime(String key, DateTime defaultValue)
        {
            lock (this._locker)
            {
                Int64 ticks = DependencyPlatform_Droid_PersistentStorage.SharedPreferences.GetLong(key, -1);

                if (ticks == -1)
                {
                    return defaultValue;
                }

                return new DateTime(ticks);
            }
        }

        public Boolean AddOrUpdateValueDateTime(String key, DateTime value)
        {
            lock (this._locker)
            {
                DependencyPlatform_Droid_PersistentStorage.SharedPreferencesEditor.PutLong(key, value.Ticks);

                return true;
            }
        }

        //public T GetValueOrDefault<T>(string key, T defaultValue = default(T))
        //{
        //    lock (_locker)
        //    {
        //        var typeOf = typeof(T);
        //        if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            typeOf = Nullable.GetUnderlyingType(typeOf);
        //        }
        //        object value = null;
        //        var typeCode = Type.GetTypeCode(typeOf);
        //        switch (typeCode)
        //        {
        //            case TypeCode.Boolean:
        //                value = SharedPreferences.GetBoolean(key, Convert.ToBoolean(defaultValue));
        //                break;
        //            case TypeCode.Int64:
        //                value = SharedPreferences.GetLong(key, Convert.ToInt64(defaultValue));
        //                break;
        //            case TypeCode.String:
        //                value = SharedPreferences.GetString(key, Convert.ToString(defaultValue));
        //                break;
        //            case TypeCode.Int32:
        //                value = SharedPreferences.GetInt(key, Convert.ToInt32(defaultValue));
        //                break;
        //            case TypeCode.Single:
        //                value = SharedPreferences.GetFloat(key, Convert.ToSingle(defaultValue));
        //                break;
        //            case TypeCode.DateTime:
        //                var ticks = SharedPreferences.GetLong(key, -1);
        //                if (ticks == -1)
        //                    value = defaultValue;
        //                else
        //                    value = new DateTime(ticks);
        //                break;
        //        }

        //        return null != value ? (T)value : defaultValue;
        //    }
        //}

        //public bool AddOrUpdateValue(string key, object value)
        //{
        //    lock (_locker)
        //    {
        //        var typeOf = value.GetType();
        //        if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            typeOf = Nullable.GetUnderlyingType(typeOf);
        //        }
        //        var typeCode = Type.GetTypeCode(typeOf);
        //        switch (typeCode)
        //        {
        //            case TypeCode.Boolean:
        //                SharedPreferencesEditor.PutBoolean(key, Convert.ToBoolean(value));
        //                break;
        //            case TypeCode.Int64:
        //                SharedPreferencesEditor.PutLong(key, Convert.ToInt64(value));
        //                break;
        //            case TypeCode.String:
        //                SharedPreferencesEditor.PutString(key, Convert.ToString(value));
        //                break;
        //            case TypeCode.Int32:
        //                SharedPreferencesEditor.PutInt(key, Convert.ToInt32(value));
        //                break;
        //            case TypeCode.Single:
        //                SharedPreferencesEditor.PutFloat(key, Convert.ToSingle(value));
        //                break;
        //            case TypeCode.DateTime:
        //                SharedPreferencesEditor.PutLong(key, ((DateTime)value).Ticks);
        //                break;
        //        }
        //    }

        //    return true;
        //}

        public void Save()
        {
            lock (this._locker)
            {
                DependencyPlatform_Droid_PersistentStorage.SharedPreferencesEditor.Commit();
            }
        }
    }
}