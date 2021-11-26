
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("groups")]
    public class Group {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("change_key")]
        public String ChangeKey { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("name")]
        public String Name { get; set; }
        
        [Column("name_changed"), DefaultValue(0)]
        public Int64 NameChanged { get; set; }
        
        [Column("position")]
        public String Position { get; set; }
        
        [Column("position_changed"), DefaultValue(0)]
        public Int64 PositionChanged { get; set; }
        
        [Column("is_expanded"), DefaultValue(0)]
        public Int64 IsExpanded { get; set; }
        
    }

    public class GroupAODComparer : IEqualityComparer<Group>
    {
        public bool Equals(Group x, Group y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Group obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class GroupChangedComparer : IEqualityComparer<Group>
    {
        public bool Equals(Group x, Group y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.ChangeKey == y.ChangeKey &&
                x.Deleted == y.Deleted &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.Name == y.Name &&
                x.NameChanged == y.NameChanged &&
                x.Position == y.Position &&
                x.PositionChanged == y.PositionChanged &&
                x.IsExpanded == y.IsExpanded;
        }

        public int GetHashCode([DisallowNull] Group obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int ChangeKeyHashCode = obj.ChangeKey?.GetHashCode()??0;
            int DeletedHashCode = obj.Deleted.GetHashCode();
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int NameHashCode = obj.Name?.GetHashCode()??0;
            int NameChangedHashCode = obj.NameChanged.GetHashCode();
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            int PositionChangedHashCode = obj.PositionChanged.GetHashCode();
            int IsExpandedHashCode = obj.IsExpanded.GetHashCode();
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                ChangeKeyHashCode ^
                DeletedHashCode ^
                DeleteAfterSyncHashCode ^
                NameHashCode ^
                NameChangedHashCode ^
                PositionHashCode ^
                PositionChangedHashCode ^
                IsExpandedHashCode;
        }
    }
}

