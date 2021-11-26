
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("task_folders")]
    public class TaskFolder {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("change_key")]
        public String ChangeKey { get; set; }
        
        [Column("is_default"), DefaultValue(0)]
        public Int64 IsDefault { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
        [Column("delta_link")]
        public String DeltaLink { get; set; }
        
        [Column("group_local_id")]
        public String GroupLocalId { get; set; }
        
        [Column("group_local_id_changed"), DefaultValue(0)]
        public Int64 GroupLocalIdChanged { get; set; }
        
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
        
        [Column("show_completed_tasks"), DefaultValue(1)]
        public Int64 ShowCompletedTasks { get; set; }
        
        [Column("show_completed_tasks_changed"), DefaultValue(0)]
        public Int64 ShowCompletedTasksChanged { get; set; }
        
        [Column("sorting_order"), DefaultValue("STORED_POSITION")]
        public String SortingOrder { get; set; }
        
        [Column("sorting_order_changed"), DefaultValue(0)]
        public Int64 SortingOrderChanged { get; set; }
        
        [Column("sorting_direction"), DefaultValue("DESCENDING")]
        public String SortingDirection { get; set; }
        
        [Column("sorting_direction_changed"), DefaultValue(0)]
        public Int64 SortingDirectionChanged { get; set; }
        
        [Column("theme_background"), DefaultValue("mountain")]
        public String ThemeBackground { get; set; }
        
        [Column("theme_background_changed"), DefaultValue(0)]
        public Int64 ThemeBackgroundChanged { get; set; }
        
        [Column("theme_color"), DefaultValue("dark_blue")]
        public String ThemeColor { get; set; }
        
        [Column("theme_color_changed"), DefaultValue(0)]
        public Int64 ThemeColorChanged { get; set; }
        
        [Column("is_owner"), DefaultValue(1)]
        public Int64 IsOwner { get; set; }
        
        [Column("sync_update_required"), DefaultValue(0)]
        public Int64 SyncUpdateRequired { get; set; }
        
        [Column("sharing_link")]
        public String SharingLink { get; set; }
        
        [Column("is_folder_shared"), DefaultValue(0)]
        public Int64 IsFolderShared { get; set; }
        
        [Column("folder_type")]
        public String FolderType { get; set; }
        
        [Column("sync_status"), DefaultValue("Synced")]
        public String SyncStatus { get; set; }
        
        [Column("sharing_status"), DefaultValue("NotShared")]
        public String SharingStatus { get; set; }
        
        [Column("sharing_status_changed"), DefaultValue(0)]
        public Int64 SharingStatusChanged { get; set; }
        
        [Column("is_cross_tenant"), DefaultValue(0)]
        public Int64 IsCrossTenant { get; set; }
        
    }

    public class TaskFolderAODComparer : IEqualityComparer<TaskFolder>
    {
        public bool Equals(TaskFolder x, TaskFolder y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] TaskFolder obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class TaskFolderChangedComparer : IEqualityComparer<TaskFolder>
    {
        public bool Equals(TaskFolder x, TaskFolder y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.ChangeKey == y.ChangeKey &&
                x.IsDefault == y.IsDefault &&
                x.Deleted == y.Deleted &&
                x.DeltaLink == y.DeltaLink &&
                x.GroupLocalId == y.GroupLocalId &&
                x.GroupLocalIdChanged == y.GroupLocalIdChanged &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.Name == y.Name &&
                x.NameChanged == y.NameChanged &&
                x.Position == y.Position &&
                x.PositionChanged == y.PositionChanged &&
                x.ShowCompletedTasks == y.ShowCompletedTasks &&
                x.ShowCompletedTasksChanged == y.ShowCompletedTasksChanged &&
                x.SortingOrder == y.SortingOrder &&
                x.SortingOrderChanged == y.SortingOrderChanged &&
                x.SortingDirection == y.SortingDirection &&
                x.SortingDirectionChanged == y.SortingDirectionChanged &&
                x.ThemeBackground == y.ThemeBackground &&
                x.ThemeBackgroundChanged == y.ThemeBackgroundChanged &&
                x.ThemeColor == y.ThemeColor &&
                x.ThemeColorChanged == y.ThemeColorChanged &&
                x.IsOwner == y.IsOwner &&
                x.SyncUpdateRequired == y.SyncUpdateRequired &&
                x.SharingLink == y.SharingLink &&
                x.IsFolderShared == y.IsFolderShared &&
                x.FolderType == y.FolderType &&
                x.SyncStatus == y.SyncStatus &&
                x.SharingStatus == y.SharingStatus &&
                x.SharingStatusChanged == y.SharingStatusChanged &&
                x.IsCrossTenant == y.IsCrossTenant;
        }

        public int GetHashCode([DisallowNull] TaskFolder obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int ChangeKeyHashCode = obj.ChangeKey?.GetHashCode()??0;
            int IsDefaultHashCode = obj.IsDefault.GetHashCode();
            int DeletedHashCode = obj.Deleted.GetHashCode();
            int DeltaLinkHashCode = obj.DeltaLink?.GetHashCode()??0;
            int GroupLocalIdHashCode = obj.GroupLocalId?.GetHashCode()??0;
            int GroupLocalIdChangedHashCode = obj.GroupLocalIdChanged.GetHashCode();
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int NameHashCode = obj.Name?.GetHashCode()??0;
            int NameChangedHashCode = obj.NameChanged.GetHashCode();
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            int PositionChangedHashCode = obj.PositionChanged.GetHashCode();
            int ShowCompletedTasksHashCode = obj.ShowCompletedTasks.GetHashCode();
            int ShowCompletedTasksChangedHashCode = obj.ShowCompletedTasksChanged.GetHashCode();
            int SortingOrderHashCode = obj.SortingOrder?.GetHashCode()??0;
            int SortingOrderChangedHashCode = obj.SortingOrderChanged.GetHashCode();
            int SortingDirectionHashCode = obj.SortingDirection?.GetHashCode()??0;
            int SortingDirectionChangedHashCode = obj.SortingDirectionChanged.GetHashCode();
            int ThemeBackgroundHashCode = obj.ThemeBackground?.GetHashCode()??0;
            int ThemeBackgroundChangedHashCode = obj.ThemeBackgroundChanged.GetHashCode();
            int ThemeColorHashCode = obj.ThemeColor?.GetHashCode()??0;
            int ThemeColorChangedHashCode = obj.ThemeColorChanged.GetHashCode();
            int IsOwnerHashCode = obj.IsOwner.GetHashCode();
            int SyncUpdateRequiredHashCode = obj.SyncUpdateRequired.GetHashCode();
            int SharingLinkHashCode = obj.SharingLink?.GetHashCode()??0;
            int IsFolderSharedHashCode = obj.IsFolderShared.GetHashCode();
            int FolderTypeHashCode = obj.FolderType?.GetHashCode()??0;
            int SyncStatusHashCode = obj.SyncStatus?.GetHashCode()??0;
            int SharingStatusHashCode = obj.SharingStatus?.GetHashCode()??0;
            int SharingStatusChangedHashCode = obj.SharingStatusChanged.GetHashCode();
            int IsCrossTenantHashCode = obj.IsCrossTenant.GetHashCode();
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                ChangeKeyHashCode ^
                IsDefaultHashCode ^
                DeletedHashCode ^
                DeltaLinkHashCode ^
                GroupLocalIdHashCode ^
                GroupLocalIdChangedHashCode ^
                DeleteAfterSyncHashCode ^
                NameHashCode ^
                NameChangedHashCode ^
                PositionHashCode ^
                PositionChangedHashCode ^
                ShowCompletedTasksHashCode ^
                ShowCompletedTasksChangedHashCode ^
                SortingOrderHashCode ^
                SortingOrderChangedHashCode ^
                SortingDirectionHashCode ^
                SortingDirectionChangedHashCode ^
                ThemeBackgroundHashCode ^
                ThemeBackgroundChangedHashCode ^
                ThemeColorHashCode ^
                ThemeColorChangedHashCode ^
                IsOwnerHashCode ^
                SyncUpdateRequiredHashCode ^
                SharingLinkHashCode ^
                IsFolderSharedHashCode ^
                FolderTypeHashCode ^
                SyncStatusHashCode ^
                SharingStatusHashCode ^
                SharingStatusChangedHashCode ^
                IsCrossTenantHashCode;
        }
    }
}

