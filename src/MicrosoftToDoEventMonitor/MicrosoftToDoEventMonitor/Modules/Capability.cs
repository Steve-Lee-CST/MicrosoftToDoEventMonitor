
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("capabilities")]
    public class Capability {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("name")]
        public String Name { get; set; }
        
        [Column("is_supported"), DefaultValue(0)]
        public Int64 IsSupported { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
    }

    public class CapabilityAODComparer : IEqualityComparer<Capability>
    {
        public bool Equals(Capability x, Capability y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Capability obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public class CapabilityChangedComparer : IEqualityComparer<Capability>
    {
        public bool Equals(Capability x, Capability y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.Name == y.Name &&
                x.IsSupported == y.IsSupported &&
                x.DeleteAfterSync == y.DeleteAfterSync;
        }

        public int GetHashCode([DisallowNull] Capability obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int NameHashCode = obj.Name?.GetHashCode()??0;
            int IsSupportedHashCode = obj.IsSupported.GetHashCode();
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            return 
                IdHashCode ^
                NameHashCode ^
                IsSupportedHashCode ^
                DeleteAfterSyncHashCode;
        }
    }
}

