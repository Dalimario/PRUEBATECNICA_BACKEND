using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boz.RestService.Model.Uitilities
{
    public static class ModelUtilities
    {
        public static int? GetInt(object obj)
        {
            return (obj == null || obj is DBNull) ? (int?)null : Convert.ToInt32(obj);
        }
        
        public static int? GetInt(object obj, int defaultValue)
        {
            return (obj == null || obj is DBNull) ? defaultValue : Convert.ToInt32(obj);
        }

        public static int GetNotNullInt(object obj)
        {
            return (obj == null || obj is DBNull) ? (int)0: Convert.ToInt32(obj);
        }

        public static decimal? GetDecimal(object obj)
        {
            return (obj == null || obj is DBNull) ? (decimal?)null : Convert.ToDecimal(obj);
        }

        public static decimal? GetDecimal(object obj, decimal defaultValue)
        {
            return (obj == null || obj is DBNull) ? defaultValue : Convert.ToDecimal(obj);
        }

        public static double? GetDouble(object obj)
        {
            return (obj == null || obj is DBNull) ? (double?)null : Convert.ToDouble(obj);
        }

        public static double? GetDouble(object obj, double defaultValue)
        {
            return (obj == null || obj is DBNull) ? defaultValue : Convert.ToDouble(obj);
        }

        public static string GetString(object obj)
        {
            return (obj == null || obj is DBNull) ? string.Empty : obj.ToString();
        }

        public static DateTime? GetDateTime(object obj)
        {
            return (obj == null || obj is DBNull) ? (DateTime?)null : Convert.ToDateTime(obj);
        }

        public static DateTime? GetDateTime(object obj, DateTime defaultValue)
        {
            return (obj == null || obj is DBNull) ? defaultValue : Convert.ToDateTime(obj);
        }

        public static bool? GetBool(object obj)
        {
            return (obj == null || obj is DBNull) ? (bool?)null : Convert.ToBoolean(obj);
        }

        public static bool? GetBool(object obj, bool defaultValue)
        {
            return (obj == null || obj is DBNull) ? defaultValue : Convert.ToBoolean(obj);
        }

        public static bool GetNotNullBool(object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static long? GetLong(object obj)
        {
            return (obj == null || obj is DBNull) ? (long?)null : Convert.ToInt64(obj);
        }

        public static Dictionary<string,string> GetTableValueDictionary(object obj)
        {
            var dic = new Dictionary<string, string>();
            var stop = (obj == null || obj is DBNull);
            stop = !stop && string.IsNullOrEmpty(obj.ToString());
            if (stop)
                return dic;

            var items = obj.ToString().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            if(items.Length == 0)
                return dic;

            foreach (var item in items)
            {
                var values = item.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length <= 1)
                    continue;

                dic.Add(values[0], values[1]);
            }

            return dic;
        }

        public static object SetStringDbNull(string obj)
        {
            return string.IsNullOrEmpty(obj) || obj == " " ? (object)DBNull.Value : obj;
        }
        
        public static object SetStringEmpty(string obj)
        {
            return obj == null ? string.Empty : obj;
        }

        public static object SetDoubleEmpty(Double obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }


        public static object SetLongDbNull(long? obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }

        public static object SetIntDbNull(int? obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }

        public static object SetDateTimeDbNull(DateTime? obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }

        public static object SetDecimalDbNull(decimal? obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }

        public static object SetBoolDbNull(bool? obj)
        {
            return obj == null ? (object)DBNull.Value : obj;
        }
    }
}