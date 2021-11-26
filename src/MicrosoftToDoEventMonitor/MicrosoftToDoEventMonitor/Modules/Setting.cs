
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("settings")]
    public class Setting {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("key")]
        public String Key { get; set; }
        
        [Column("value")]
        public String Value { get; set; }
        
        [Column("value_changed"), DefaultValue(0)]
        public Int64 ValueChanged { get; set; }
        
    }

    public class SettingAODComparer : IEqualityComparer<Setting>
    {
        public bool Equals(Setting x, Setting y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.Key == y.Key;
        }

        public int GetHashCode([DisallowNull] Setting obj)
        {
            return obj.Key.GetHashCode();
        }
    }

    public class SettingChangedComparer : IEqualityComparer<Setting>
    {
        public bool Equals(Setting x, Setting y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.Key == y.Key &&
                x.Value == y.Value &&
                x.ValueChanged == y.ValueChanged;
        }

        public int GetHashCode([DisallowNull] Setting obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int KeyHashCode = obj.Key?.GetHashCode()??0;
            int ValueHashCode = obj.Value?.GetHashCode()??0;
            int ValueChangedHashCode = obj.ValueChanged.GetHashCode();
            return 
                IdHashCode ^
                KeyHashCode ^
                ValueHashCode ^
                ValueChangedHashCode;
        }
    }
}

