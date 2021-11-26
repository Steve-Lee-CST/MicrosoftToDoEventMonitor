
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("linked_entities")]
    public class LinkedEntity {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("web_link")]
        public String WebLink { get; set; }
        
        [Column("entity_type")]
        public String EntityType { get; set; }
        
        [Column("entity_subtype")]
        public String EntitySubtype { get; set; }
        
        [Column("display_name")]
        public String DisplayName { get; set; }
        
        [Column("preview")]
        public String Preview { get; set; }
        
        [Column("application_name")]
        public String ApplicationName { get; set; }
        
        [Column("client_state")]
        public String ClientState { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("task_local_id")]
        public String TaskLocalId { get; set; }
        
        [Column("position")]
        public String Position { get; set; }
        
        [Column("position_changed"), DefaultValue(0)]
        public Int64 PositionChanged { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
    }

    public class LinkedEntityAODComparer : IEqualityComparer<LinkedEntity>
    {
        public bool Equals(LinkedEntity x, LinkedEntity y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] LinkedEntity obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class LinkedEntityChangedComparer : IEqualityComparer<LinkedEntity>
    {
        public bool Equals(LinkedEntity x, LinkedEntity y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.WebLink == y.WebLink &&
                x.EntityType == y.EntityType &&
                x.EntitySubtype == y.EntitySubtype &&
                x.DisplayName == y.DisplayName &&
                x.Preview == y.Preview &&
                x.ApplicationName == y.ApplicationName &&
                x.ClientState == y.ClientState &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.TaskLocalId == y.TaskLocalId &&
                x.Position == y.Position &&
                x.PositionChanged == y.PositionChanged &&
                x.Deleted == y.Deleted;
        }

        public int GetHashCode([DisallowNull] LinkedEntity obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int WebLinkHashCode = obj.WebLink?.GetHashCode()??0;
            int EntityTypeHashCode = obj.EntityType?.GetHashCode()??0;
            int EntitySubtypeHashCode = obj.EntitySubtype?.GetHashCode()??0;
            int DisplayNameHashCode = obj.DisplayName?.GetHashCode()??0;
            int PreviewHashCode = obj.Preview?.GetHashCode()??0;
            int ApplicationNameHashCode = obj.ApplicationName?.GetHashCode()??0;
            int ClientStateHashCode = obj.ClientState?.GetHashCode()??0;
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int TaskLocalIdHashCode = obj.TaskLocalId?.GetHashCode()??0;
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            int PositionChangedHashCode = obj.PositionChanged.GetHashCode();
            int DeletedHashCode = obj.Deleted.GetHashCode();
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                WebLinkHashCode ^
                EntityTypeHashCode ^
                EntitySubtypeHashCode ^
                DisplayNameHashCode ^
                PreviewHashCode ^
                ApplicationNameHashCode ^
                ClientStateHashCode ^
                DeleteAfterSyncHashCode ^
                TaskLocalIdHashCode ^
                PositionHashCode ^
                PositionChangedHashCode ^
                DeletedHashCode;
        }
    }
}

