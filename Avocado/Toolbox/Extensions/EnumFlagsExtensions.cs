using System;

namespace Avocado.Toolbox.Extensions {
    // ItemCategory cat = ItemCategory.Food | ItemCategory.Weapon;
    // // Проверка хотя бы одного флага
    // if (cat.HasFlagFast(ItemCategory.Food))
    //     Debug.Log("Содержит Food");
    //
    // // Проверка всех сразу
    // if (cat.HasAllFlags(ItemCategory.Food | ItemCategory.Weapon))
    //     Debug.Log("Есть и еда, и оружие");
    //
    // // Добавление, удаление, переключение
    // cat = cat.AddFlag(ItemCategory.Tool);
    // cat = cat.RemoveFlag(ItemCategory.Weapon);
    // cat = cat.ToggleFlag(ItemCategory.Food);
    
    public static class EnumFlagsExtensions {
        public static bool HasFlagFast<T>(this T value, T flag) where T : struct, Enum {
            long v = Convert.ToInt64(value);
            long f = Convert.ToInt64(flag);
            return (v & f) != 0;
        }

        // Проверка: содержатся ли ВСЕ указанные флаги
        public static bool HasAllFlags<T>(this T value, T flags) where T : struct, Enum {
            long v = Convert.ToInt64(value);
            long f = Convert.ToInt64(flags);
            return (v & f) == f;
        }

        public static T AddFlag<T>(this T value, T flag) where T : struct, Enum {
            long v = Convert.ToInt64(value);
            long f = Convert.ToInt64(flag);
            return (T)Enum.ToObject(typeof(T), v | f);
        }

        public static T RemoveFlag<T>(this T value, T flag) where T : struct, Enum {
            long v = Convert.ToInt64(value);
            long f = Convert.ToInt64(flag);
            return (T)Enum.ToObject(typeof(T), v & ~f);
        }

        public static T ToggleFlag<T>(this T value, T flag) where T : struct, Enum {
            long v = Convert.ToInt64(value);
            long f = Convert.ToInt64(flag);
            return (T)Enum.ToObject(typeof(T), v ^ f);
        }
    }
}
