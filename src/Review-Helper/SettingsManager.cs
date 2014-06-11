using System;
using Windows.Storage;

namespace Review_Helper
{
    public static class SettingsManager
    {
        public static bool Set<T>(string key, T data)
        {
            try
            {
                ApplicationData.Current.RoamingSettings.Values[key] = data;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static T Get<T>(string key)
        {
            try
            {
                return (T) ApplicationData.Current.RoamingSettings.Values[key];
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static bool Delete(string key)
        {
            try
            {
                return ApplicationData.Current.RoamingSettings.Values.Remove(key);
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static bool HasKey(string key)
        {
            try
            {
                return ApplicationData.Current.RoamingSettings.Values.ContainsKey(key);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}