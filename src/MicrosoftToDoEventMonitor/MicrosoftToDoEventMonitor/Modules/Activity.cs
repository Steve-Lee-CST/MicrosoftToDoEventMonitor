
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("activities")]
    public class Activity {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("entity_id")]
        public String EntityId { get; set; }
        
        [Column("entity_type")]
        public String EntityType { get; set; }
        
        [Column("activity_type")]
        public String ActivityType { get; set; }
        
        [Column("created_date_time")]
        public String CreatedDateTime { get; set; }
        
        [Column("updated_time")]
        public String UpdatedTime { get; set; }
        
        [Column("active"), DefaultValue(0)]
        public Int64 Active { get; set; }
        
        [Column("active_changed"), DefaultValue(0)]
        public Int64 ActiveChanged { get; set; }
        
        [Column("actor_display_name")]
        public String ActorDisplayName { get; set; }
        
        [Column("metadata")]
        public String Metadata { get; set; }
        
    }

    public class ActivityAODComparer : IEqualityComparer<Activity>
    {
        public bool Equals(Activity x, Activity y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Activity obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class ActivityChangedComparer : IEqualityComparer<Activity>
    {
        public bool Equals(Activity x, Activity y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.EntityId == y.EntityId &&
                x.EntityType == y.EntityType &&
                x.ActivityType == y.ActivityType &&
                x.CreatedDateTime == y.CreatedDateTime &&
                x.UpdatedTime == y.UpdatedTime &&
                x.Active == y.Active &&
                x.ActiveChanged == y.ActiveChanged &&
                x.ActorDisplayName == y.ActorDisplayName &&
                x.Metadata == y.Metadata;
        }

        public int GetHashCode([DisallowNull] Activity obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int EntityIdHashCode = obj.EntityId?.GetHashCode()??0;
            int EntityTypeHashCode = obj.EntityType?.GetHashCode()??0;
            int ActivityTypeHashCode = obj.ActivityType?.GetHashCode()??0;
            int CreatedDateTimeHashCode = obj.CreatedDateTime?.GetHashCode()??0;
            int UpdatedTimeHashCode = obj.UpdatedTime?.GetHashCode()??0;
            int ActiveHashCode = obj.Active.GetHashCode();
            int ActiveChangedHashCode = obj.ActiveChanged.GetHashCode();
            int ActorDisplayNameHashCode = obj.ActorDisplayName?.GetHashCode()??0;
            int MetadataHashCode = obj.Metadata?.GetHashCode()??0;
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                EntityIdHashCode ^
                EntityTypeHashCode ^
                ActivityTypeHashCode ^
                CreatedDateTimeHashCode ^
                UpdatedTimeHashCode ^
                ActiveHashCode ^
                ActiveChangedHashCode ^
                ActorDisplayNameHashCode ^
                MetadataHashCode;
        }
    }
}

