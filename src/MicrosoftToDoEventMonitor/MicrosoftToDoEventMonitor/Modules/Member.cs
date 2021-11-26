
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("members")]
    public class Member {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("display_name")]
        public String DisplayName { get; set; }
        
        [Column("avatar_url")]
        public String AvatarUrl { get; set; }
        
        [Column("task_folder_local_id")]
        public String TaskFolderLocalId { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("owner"), DefaultValue(0)]
        public Int64 Owner { get; set; }
        
    }

    public class MemberAODComparer : IEqualityComparer<Member>
    {
        public bool Equals(Member x, Member y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Member obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class MemberChangedComparer : IEqualityComparer<Member>
    {
        public bool Equals(Member x, Member y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.DisplayName == y.DisplayName &&
                x.AvatarUrl == y.AvatarUrl &&
                x.TaskFolderLocalId == y.TaskFolderLocalId &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.Owner == y.Owner;
        }

        public int GetHashCode([DisallowNull] Member obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int DisplayNameHashCode = obj.DisplayName?.GetHashCode()??0;
            int AvatarUrlHashCode = obj.AvatarUrl?.GetHashCode()??0;
            int TaskFolderLocalIdHashCode = obj.TaskFolderLocalId?.GetHashCode()??0;
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int OwnerHashCode = obj.Owner.GetHashCode();
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                DisplayNameHashCode ^
                AvatarUrlHashCode ^
                TaskFolderLocalIdHashCode ^
                DeleteAfterSyncHashCode ^
                OwnerHashCode;
        }
    }
}

