using System;
using UnityEngine;

namespace Avocado.Toolbox
{
    [Serializable]
    public struct ConfigId : IEquatable<ConfigId>
    {
        [SerializeField] private string value;

        public ConfigId(string value)
        {
            this.value = value;
        }

        public static implicit operator string(ConfigId id) => id.value;
        public static implicit operator ConfigId(string value) => new(value);

        public override string ToString() => value;
        public bool Equals(ConfigId other) => value == other.value;
        public override bool Equals(object obj) => obj is ConfigId other && Equals(other);
        public override int GetHashCode() => value != null ? value.GetHashCode() : 0;

        public static bool operator ==(ConfigId left, ConfigId right) => left.Equals(right);
        public static bool operator !=(ConfigId left, ConfigId right) => !left.Equals(right);
    }
}
