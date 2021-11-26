
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("steps")]
    public class Step {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("task_local_id")]
        public String TaskLocalId { get; set; }
        
        [Column("task_local_id_changed"), DefaultValue(0)]
        public Int64 TaskLocalIdChanged { get; set; }
        
        [Column("completed"), DefaultValue(0)]
        public Int64 Completed { get; set; }
        
        [Column("completed_changed"), DefaultValue(0)]
        public Int64 CompletedChanged { get; set; }
        
        [Column("subject")]
        public String Subject { get; set; }
        
        [Column("subject_changed"), DefaultValue(0)]
        public Int64 SubjectChanged { get; set; }
        
        [Column("position")]
        public String Position { get; set; }
        
        [Column("position_changed"), DefaultValue(0)]
        public Int64 PositionChanged { get; set; }
        
        [Column("created_datetime")]
        public String CreatedDatetime { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
    }

    public class StepAODComparer : IEqualityComparer<Step>
    {
        public bool Equals(Step x, Step y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Step obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class StepChangedComparer : IEqualityComparer<Step>
    {
        public bool Equals(Step x, Step y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.TaskLocalId == y.TaskLocalId &&
                x.TaskLocalIdChanged == y.TaskLocalIdChanged &&
                x.Completed == y.Completed &&
                x.CompletedChanged == y.CompletedChanged &&
                x.Subject == y.Subject &&
                x.SubjectChanged == y.SubjectChanged &&
                x.Position == y.Position &&
                x.PositionChanged == y.PositionChanged &&
                x.CreatedDatetime == y.CreatedDatetime &&
                x.Deleted == y.Deleted;
        }

        public int GetHashCode([DisallowNull] Step obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int TaskLocalIdHashCode = obj.TaskLocalId?.GetHashCode()??0;
            int TaskLocalIdChangedHashCode = obj.TaskLocalIdChanged.GetHashCode();
            int CompletedHashCode = obj.Completed.GetHashCode();
            int CompletedChangedHashCode = obj.CompletedChanged.GetHashCode();
            int SubjectHashCode = obj.Subject?.GetHashCode()??0;
            int SubjectChangedHashCode = obj.SubjectChanged.GetHashCode();
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            int PositionChangedHashCode = obj.PositionChanged.GetHashCode();
            int CreatedDatetimeHashCode = obj.CreatedDatetime?.GetHashCode()??0;
            int DeletedHashCode = obj.Deleted.GetHashCode();
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                DeleteAfterSyncHashCode ^
                TaskLocalIdHashCode ^
                TaskLocalIdChangedHashCode ^
                CompletedHashCode ^
                CompletedChangedHashCode ^
                SubjectHashCode ^
                SubjectChangedHashCode ^
                PositionHashCode ^
                PositionChangedHashCode ^
                CreatedDatetimeHashCode ^
                DeletedHashCode;
        }
    }
}

