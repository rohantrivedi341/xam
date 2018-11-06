using System;
using Foundation;
using iOS.DependencyServices;
using PCL.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_iOS_PersistentStorage))]

namespace iOS.DependencyServices
{
    public class DependencyPlatform_iOS_PersistentStorage : IDependencyPlatformPersistentStorage
    {
        private readonly object _locker = new object();

        public int GetValueOrDefaultInt32(String key, Int32 defaultValue)
        {
            lock (this._locker)
            {
                if (NSUserDefaults.StandardUserDefaults[key] == null)
                {
                    return defaultValue;
                }

                return (Int32) NSUserDefaults.StandardUserDefaults.IntForKey(key);
            }
        }

        public Boolean AddOrUpdateValueInt32(String key, Int32 value)
        {
            lock (this._locker)
            {
                NSUserDefaults.StandardUserDefaults.SetInt(value, key);

                return true;
            }
        }

        public Boolean GetValueOrDefaultBoolean(String key, Boolean defaultValue)
        {
            lock (this._locker)
            {
                if (NSUserDefaults.StandardUserDefaults[key] == null)
                {
                    return defaultValue;
                }

                return (Boolean) NSUserDefaults.StandardUserDefaults.BoolForKey(key);
            }
        }

        public Boolean AddOrUpdateValueBoolean(String key, Boolean value)
        {
            lock (this._locker)
            {
                NSUserDefaults.StandardUserDefaults.SetBool(value, key);

                return true;
            }
        }

        public DateTime GetValueOrDefaultDateTime(String key, DateTime defaultValue)
        {
            lock (this._locker)
            {
                if (NSUserDefaults.StandardUserDefaults[key] == null)
                {
                    return defaultValue;
                }

                String savedTime = NSUserDefaults.StandardUserDefaults.StringForKey(key);
                Int64 ticks = String.IsNullOrWhiteSpace(savedTime) ? -1 : Convert.ToInt64(savedTime);

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
                NSUserDefaults.StandardUserDefaults.SetString(Convert.ToString(value.Ticks), key);

                return true;
            }
        }

        //public T GetValueOrDefault<T>(String key, T defaultValue = default(T))
        //{
        //    lock (_locker)
        //    {
        //        if (NSUserDefaults.StandardUserDefaults[key] == null)
        //            return defaultValue;

        //        var typeOf = typeof(T);
        //        if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            typeOf = Nullable.GetUnderlyingType(typeOf);
        //        }
        //        object value = null;
        //        var typeCode = Type.GetTypeCode(typeOf);
        //        var defaults = NSUserDefaults.StandardUserDefaults;
        //        switch (typeCode)
        //        {
        //            case TypeCode.Boolean:
        //                value = defaults.BoolForKey(key);
        //                break;
        //            case TypeCode.Int64:
        //                var savedval = defaults.StringForKey(key);
        //                value = Convert.ToInt64(savedval);
        //                break;
        //            case TypeCode.Double:
        //                value = defaults.DoubleForKey(key);
        //                break;
        //            case TypeCode.String:
        //                value = defaults.StringForKey(key);
        //                break;
        //            case TypeCode.Int32:
        //                value = defaults.IntForKey(key);
        //                break;
        //            case TypeCode.Single:
        //                value = defaults.FloatForKey(key);
        //                break;

        //            case TypeCode.DateTime:
        //                var savedTime = defaults.StringForKey(key);
        //                var ticks = string.IsNullOrWhiteSpace(savedTime) ? -1 : Convert.ToInt64(savedTime);
        //                if (ticks == -1)
        //                    value = defaultValue;
        //                else
        //                    value = new DateTime(ticks);
        //                break;
        //        }

        //        return null != value ? (T)value : defaultValue;
        //    }
        //}

        //public Boolean AddOrUpdateValue(String key, object value)
        //{
        //    lock (_locker)
        //    {
        //        var typeOf = value.GetType();
        //        if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            typeOf = Nullable.GetUnderlyingType(typeOf);
        //        }
        //        var typeCode = Type.GetTypeCode(typeOf);
        //        var defaults = NSUserDefaults.StandardUserDefaults;
        //        switch (typeCode)
        //        {
        //            case TypeCode.Boolean:
        //                defaults.SetBool(Convert.ToBoolean(value), key);
        //                break;
        //            case TypeCode.Int64:
        //                defaults.SetString(Convert.ToString(value), key);
        //                break;
        //            case TypeCode.Double:
        //                defaults.SetDouble(Convert.ToDouble(value), key);
        //                break;
        //            case TypeCode.String:
        //                defaults.SetString(Convert.ToString(value), key);
        //                break;
        //            case TypeCode.Int32:
        //                defaults.SetInt(Convert.ToInt32(value), key);
        //                break;
        //            case TypeCode.Single:
        //                defaults.SetFloat(Convert.ToSingle(value), key);
        //                break;
        //            case TypeCode.DateTime:
        //                defaults.SetString(Convert.ToString(((DateTime)value).Ticks), key);
        //                break;
        //        }
        //    }

        //    return true;
        //}

        public void Save()
        {
            lock (this._locker)
            {
                var defaults = NSUserDefaults.StandardUserDefaults;
                defaults.Synchronize();
            }
        }
    }
}