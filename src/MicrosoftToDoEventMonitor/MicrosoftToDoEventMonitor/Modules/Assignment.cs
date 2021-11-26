
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("assignments")]
    public class Assignment {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("task_local_id")]
        public String TaskLocalId { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("assignee_id")]
        public String AssigneeId { get; set; }
        
        [Column("assignee_id_type")]
        public String AssigneeIdType { get; set; }
        
        [Column("assignee_display_name")]
        public String AssigneeDisplayName { get; set; }
        
        [Column("assignee_avatar_url")]
        public String AssigneeAvatarUrl { get; set; }
        
        [Column("assigner_id")]
        public String AssignerId { get; set; }
        
        [Column("assignment_source")]
        public String AssignmentSource { get; set; }
        
        [Column("assigned_datetime")]
        public String AssignedDatetime { get; set; }
        
        [Column("position")]
        public String Position { get; set; }
        
    }

    public class AssignmentAODComparer : IEqualityComparer<Assignment>
    {
        public bool Equals(Assignment x, Assignment y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Assignment obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class AssignmentChangedComparer : IEqualityComparer<Assignment>
    {
        public bool Equals(Assignment x, Assignment y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.TaskLocalId == y.TaskLocalId &&
                x.Deleted == y.Deleted &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.AssigneeId == y.AssigneeId &&
                x.AssigneeIdType == y.AssigneeIdType &&
                x.AssigneeDisplayName == y.AssigneeDisplayName &&
                x.AssigneeAvatarUrl == y.AssigneeAvatarUrl &&
                x.AssignerId == y.AssignerId &&
                x.AssignmentSource == y.AssignmentSource &&
                x.AssignedDatetime == y.AssignedDatetime &&
                x.Position == y.Position;
        }

        public int GetHashCode([DisallowNull] Assignment obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int TaskLocalIdHashCode = obj.TaskLocalId?.GetHashCode()??0;
            int DeletedHashCode = obj.Deleted.GetHashCode();
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int AssigneeIdHashCode = obj.AssigneeId?.GetHashCode()??0;
            int AssigneeIdTypeHashCode = obj.AssigneeIdType?.GetHashCode()??0;
            int AssigneeDisplayNameHashCode = obj.AssigneeDisplayName?.GetHashCode()??0;
            int AssigneeAvatarUrlHashCode = obj.AssigneeAvatarUrl?.GetHashCode()??0;
            int AssignerIdHashCode = obj.AssignerId?.GetHashCode()??0;
            int AssignmentSourceHashCode = obj.AssignmentSource?.GetHashCode()??0;
            int AssignedDatetimeHashCode = obj.AssignedDatetime?.GetHashCode()??0;
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                TaskLocalIdHashCode ^
                DeletedHashCode ^
                DeleteAfterSyncHashCode ^
                AssigneeIdHashCode ^
                AssigneeIdTypeHashCode ^
                AssigneeDisplayNameHashCode ^
                AssigneeAvatarUrlHashCode ^
                AssignerIdHashCode ^
                AssignmentSourceHashCode ^
                AssignedDatetimeHashCode ^
                PositionHashCode;
        }
    }
}

