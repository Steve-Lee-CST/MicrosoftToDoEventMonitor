
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("folder_import_metadata")]
    public class FolderImportMetadata {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("folder_local_id")]
        public String FolderLocalId { get; set; }
        
        [Column("wunderlist_id")]
        public String WunderlistId { get; set; }
        
        [Column("was_shared"), DefaultValue(0)]
        public Int64 WasShared { get; set; }
        
        [Column("members")]
        public String Members { get; set; }
        
        [Column("dismissed"), DefaultValue(0)]
        public Int64 Dismissed { get; set; }
        
        [Column("dismissed_changed"), DefaultValue(0)]
        public Int64 DismissedChanged { get; set; }
        
    }

    public class FolderImportMetadataAODComparer : IEqualityComparer<FolderImportMetadata>
    {
        public bool Equals(FolderImportMetadata x, FolderImportMetadata y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.WunderlistId == y.WunderlistId;
        }

        public int GetHashCode([DisallowNull] FolderImportMetadata obj)
        {
            return obj.WunderlistId.GetHashCode();
        }
    }

    public class FolderImportMetadataChangedComparer : IEqualityComparer<FolderImportMetadata>
    {
        public bool Equals(FolderImportMetadata x, FolderImportMetadata y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.FolderLocalId == y.FolderLocalId &&
                x.WunderlistId == y.WunderlistId &&
                x.WasShared == y.WasShared &&
                x.Members == y.Members &&
                x.Dismissed == y.Dismissed &&
                x.DismissedChanged == y.DismissedChanged;
        }

        public int GetHashCode([DisallowNull] FolderImportMetadata obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int FolderLocalIdHashCode = obj.FolderLocalId?.GetHashCode()??0;
            int WunderlistIdHashCode = obj.WunderlistId?.GetHashCode()??0;
            int WasSharedHashCode = obj.WasShared.GetHashCode();
            int MembersHashCode = obj.Members?.GetHashCode()??0;
            int DismissedHashCode = obj.Dismissed.GetHashCode();
            int DismissedChangedHashCode = obj.DismissedChanged.GetHashCode();
            return 
                IdHashCode ^
                FolderLocalIdHashCode ^
                WunderlistIdHashCode ^
                WasSharedHashCode ^
                MembersHashCode ^
                DismissedHashCode ^
                DismissedChangedHashCode;
        }
    }
}

