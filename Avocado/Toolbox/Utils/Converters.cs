using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Avocado.Toolbox.Utils {
    public static class Converters {
        public static int ConvertToInt(float value) {
            return (int) Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static string GetEnumMemberValue<T>(this T value) where T : Enum {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        public static string GetEnumNameByMemberValue<T>(this string str) where T : Enum {
            var members = typeof(T).GetTypeInfo().DeclaredMembers;
            var nameInfo =
                members.FirstOrDefault(info => info.GetCustomAttribute<EnumMemberAttribute>(false)?.Value == str);

            return nameInfo.Name;
        }

        public static T ConvertToEnum<T>(this string str) where T : Enum {
            var memberStr = str.GetEnumNameByMemberValue<T>();
            return (T) Enum.Parse(typeof(T), memberStr);
        }
    }
}
