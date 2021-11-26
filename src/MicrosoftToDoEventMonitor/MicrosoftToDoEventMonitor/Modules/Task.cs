
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosoftToDoEventMonitor.Modules
{
    [Table("tasks")]
    public class Task {
        
        [Column("_id")]
        public Int64 Id { get; set; }
        
        [Column("online_id")]
        public String OnlineId { get; set; }
        
        [Column("local_id")]
        public String LocalId { get; set; }
        
        [Column("change_key")]
        public String ChangeKey { get; set; }
        
        [Column("delete_after_sync"), DefaultValue(0)]
        public Int64 DeleteAfterSync { get; set; }
        
        [Column("due_date")]
        public String DueDate { get; set; }
        
        [Column("due_date_changed"), DefaultValue(0)]
        public Int64 DueDateChanged { get; set; }
        
        [Column("task_folder_local_id")]
        public String TaskFolderLocalId { get; set; }
        
        [Column("task_folder_local_id_changed"), DefaultValue(0)]
        public Int64 TaskFolderLocalIdChanged { get; set; }
        
        [Column("status"), DefaultValue("NotStarted")]
        public String Status { get; set; }
        
        [Column("status_changed"), DefaultValue(0)]
        public Int64 StatusChanged { get; set; }
        
        [Column("importance"), DefaultValue(0)]
        public Int64 Importance { get; set; }
        
        [Column("importance_changed"), DefaultValue(0)]
        public Int64 ImportanceChanged { get; set; }
        
        [Column("subject")]
        public String Subject { get; set; }
        
        [Column("subject_changed"), DefaultValue(0)]
        public Int64 SubjectChanged { get; set; }
        
        [Column("body_content")]
        public String BodyContent { get; set; }
        
        [Column("body_content_changed"), DefaultValue(0)]
        public Int64 BodyContentChanged { get; set; }
        
        [Column("original_body_content")]
        public String OriginalBodyContent { get; set; }
        
        [Column("body_content_type"), DefaultValue("Text")]
        public String BodyContentType { get; set; }
        
        [Column("body_content_type_changed"), DefaultValue(0)]
        public Int64 BodyContentTypeChanged { get; set; }
        
        [Column("body_last_modified")]
        public String BodyLastModified { get; set; }
        
        [Column("body_last_modified_changed"), DefaultValue(0)]
        public Int64 BodyLastModifiedChanged { get; set; }
        
        [Column("is_reminder_on"), DefaultValue(0)]
        public Int64 IsReminderOn { get; set; }
        
        [Column("is_reminder_on_changed"), DefaultValue(0)]
        public Int64 IsReminderOnChanged { get; set; }
        
        [Column("reminder_datetime")]
        public String ReminderDatetime { get; set; }
        
        [Column("reminder_datetime_changed"), DefaultValue(0)]
        public Int64 ReminderDatetimeChanged { get; set; }
        
        [Column("reminder_type"), DefaultValue("Default")]
        public String ReminderType { get; set; }
        
        [Column("position")]
        public String Position { get; set; }
        
        [Column("position_changed"), DefaultValue(0)]
        public Int64 PositionChanged { get; set; }
        
        [Column("created_datetime")]
        public String CreatedDatetime { get; set; }
        
        [Column("completed_datetime")]
        public String CompletedDatetime { get; set; }
        
        [Column("completed_datetime_changed"), DefaultValue(0)]
        public Int64 CompletedDatetimeChanged { get; set; }
        
        [Column("imported"), DefaultValue(0)]
        public Int64 Imported { get; set; }
        
        [Column("postponed_date")]
        public String PostponedDate { get; set; }
        
        [Column("postponed_date_changed"), DefaultValue(0)]
        public Int64 PostponedDateChanged { get; set; }
        
        [Column("committed_date")]
        public String CommittedDate { get; set; }
        
        [Column("committed_date_changed"), DefaultValue(0)]
        public Int64 CommittedDateChanged { get; set; }
        
        [Column("committed_order")]
        public String CommittedOrder { get; set; }
        
        [Column("committed_order_changed"), DefaultValue(0)]
        public Int64 CommittedOrderChanged { get; set; }
        
        [Column("is_ignored"), DefaultValue(0)]
        public Int64 IsIgnored { get; set; }
        
        [Column("is_ignored_changed"), DefaultValue(0)]
        public Int64 IsIgnoredChanged { get; set; }
        
        [Column("deleted"), DefaultValue(0)]
        public Int64 Deleted { get; set; }
        
        [Column("recurrence_type")]
        public String RecurrenceType { get; set; }
        
        [Column("recurrence_interval"), DefaultValue(1)]
        public Int64 RecurrenceInterval { get; set; }
        
        [Column("recurrence_interval_type")]
        public String RecurrenceIntervalType { get; set; }
        
        [Column("recurrence_days_of_week")]
        public String RecurrenceDaysOfWeek { get; set; }
        
        [Column("recurrence_changed"), DefaultValue(0)]
        public Int64 RecurrenceChanged { get; set; }
        
        [Column("source")]
        public String Source { get; set; }
        
        [Column("created_by")]
        public String CreatedBy { get; set; }
        
        [Column("completed_by")]
        public String CompletedBy { get; set; }
        
        [Column("allowed_scopes")]
        public String AllowedScopes { get; set; }
        
        [Column("last_modified_date_time")]
        public String LastModifiedDateTime { get; set; }
        
    }

    public class TaskAODComparer : IEqualityComparer<Task>
    {
        public bool Equals(Task x, Task y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.OnlineId == y.OnlineId;
        }

        public int GetHashCode([DisallowNull] Task obj)
        {
            return obj.OnlineId.GetHashCode();
        }
    }

    public class TaskChangedComparer : IEqualityComparer<Task>
    {
        public bool Equals(Task x, Task y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return 
                x.Id == y.Id &&
                x.OnlineId == y.OnlineId &&
                x.LocalId == y.LocalId &&
                x.ChangeKey == y.ChangeKey &&
                x.DeleteAfterSync == y.DeleteAfterSync &&
                x.DueDate == y.DueDate &&
                x.DueDateChanged == y.DueDateChanged &&
                x.TaskFolderLocalId == y.TaskFolderLocalId &&
                x.TaskFolderLocalIdChanged == y.TaskFolderLocalIdChanged &&
                x.Status == y.Status &&
                x.StatusChanged == y.StatusChanged &&
                x.Importance == y.Importance &&
                x.ImportanceChanged == y.ImportanceChanged &&
                x.Subject == y.Subject &&
                x.SubjectChanged == y.SubjectChanged &&
                x.BodyContent == y.BodyContent &&
                x.BodyContentChanged == y.BodyContentChanged &&
                x.OriginalBodyContent == y.OriginalBodyContent &&
                x.BodyContentType == y.BodyContentType &&
                x.BodyContentTypeChanged == y.BodyContentTypeChanged &&
                x.BodyLastModified == y.BodyLastModified &&
                x.BodyLastModifiedChanged == y.BodyLastModifiedChanged &&
                x.IsReminderOn == y.IsReminderOn &&
                x.IsReminderOnChanged == y.IsReminderOnChanged &&
                x.ReminderDatetime == y.ReminderDatetime &&
                x.ReminderDatetimeChanged == y.ReminderDatetimeChanged &&
                x.ReminderType == y.ReminderType &&
                x.Position == y.Position &&
                x.PositionChanged == y.PositionChanged &&
                x.CreatedDatetime == y.CreatedDatetime &&
                x.CompletedDatetime == y.CompletedDatetime &&
                x.CompletedDatetimeChanged == y.CompletedDatetimeChanged &&
                x.Imported == y.Imported &&
                x.PostponedDate == y.PostponedDate &&
                x.PostponedDateChanged == y.PostponedDateChanged &&
                x.CommittedDate == y.CommittedDate &&
                x.CommittedDateChanged == y.CommittedDateChanged &&
                x.CommittedOrder == y.CommittedOrder &&
                x.CommittedOrderChanged == y.CommittedOrderChanged &&
                x.IsIgnored == y.IsIgnored &&
                x.IsIgnoredChanged == y.IsIgnoredChanged &&
                x.Deleted == y.Deleted &&
                x.RecurrenceType == y.RecurrenceType &&
                x.RecurrenceInterval == y.RecurrenceInterval &&
                x.RecurrenceIntervalType == y.RecurrenceIntervalType &&
                x.RecurrenceDaysOfWeek == y.RecurrenceDaysOfWeek &&
                x.RecurrenceChanged == y.RecurrenceChanged &&
                x.Source == y.Source &&
                x.CreatedBy == y.CreatedBy &&
                x.CompletedBy == y.CompletedBy &&
                x.AllowedScopes == y.AllowedScopes &&
                x.LastModifiedDateTime == y.LastModifiedDateTime;
        }

        public int GetHashCode([DisallowNull] Task obj)
        {
            
            int IdHashCode = obj.Id.GetHashCode();
            int OnlineIdHashCode = obj.OnlineId?.GetHashCode()??0;
            int LocalIdHashCode = obj.LocalId?.GetHashCode()??0;
            int ChangeKeyHashCode = obj.ChangeKey?.GetHashCode()??0;
            int DeleteAfterSyncHashCode = obj.DeleteAfterSync.GetHashCode();
            int DueDateHashCode = obj.DueDate?.GetHashCode()??0;
            int DueDateChangedHashCode = obj.DueDateChanged.GetHashCode();
            int TaskFolderLocalIdHashCode = obj.TaskFolderLocalId?.GetHashCode()??0;
            int TaskFolderLocalIdChangedHashCode = obj.TaskFolderLocalIdChanged.GetHashCode();
            int StatusHashCode = obj.Status?.GetHashCode()??0;
            int StatusChangedHashCode = obj.StatusChanged.GetHashCode();
            int ImportanceHashCode = obj.Importance.GetHashCode();
            int ImportanceChangedHashCode = obj.ImportanceChanged.GetHashCode();
            int SubjectHashCode = obj.Subject?.GetHashCode()??0;
            int SubjectChangedHashCode = obj.SubjectChanged.GetHashCode();
            int BodyContentHashCode = obj.BodyContent?.GetHashCode()??0;
            int BodyContentChangedHashCode = obj.BodyContentChanged.GetHashCode();
            int OriginalBodyContentHashCode = obj.OriginalBodyContent?.GetHashCode()??0;
            int BodyContentTypeHashCode = obj.BodyContentType?.GetHashCode()??0;
            int BodyContentTypeChangedHashCode = obj.BodyContentTypeChanged.GetHashCode();
            int BodyLastModifiedHashCode = obj.BodyLastModified?.GetHashCode()??0;
            int BodyLastModifiedChangedHashCode = obj.BodyLastModifiedChanged.GetHashCode();
            int IsReminderOnHashCode = obj.IsReminderOn.GetHashCode();
            int IsReminderOnChangedHashCode = obj.IsReminderOnChanged.GetHashCode();
            int ReminderDatetimeHashCode = obj.ReminderDatetime?.GetHashCode()??0;
            int ReminderDatetimeChangedHashCode = obj.ReminderDatetimeChanged.GetHashCode();
            int ReminderTypeHashCode = obj.ReminderType?.GetHashCode()??0;
            int PositionHashCode = obj.Position?.GetHashCode()??0;
            int PositionChangedHashCode = obj.PositionChanged.GetHashCode();
            int CreatedDatetimeHashCode = obj.CreatedDatetime?.GetHashCode()??0;
            int CompletedDatetimeHashCode = obj.CompletedDatetime?.GetHashCode()??0;
            int CompletedDatetimeChangedHashCode = obj.CompletedDatetimeChanged.GetHashCode();
            int ImportedHashCode = obj.Imported.GetHashCode();
            int PostponedDateHashCode = obj.PostponedDate?.GetHashCode()??0;
            int PostponedDateChangedHashCode = obj.PostponedDateChanged.GetHashCode();
            int CommittedDateHashCode = obj.CommittedDate?.GetHashCode()??0;
            int CommittedDateChangedHashCode = obj.CommittedDateChanged.GetHashCode();
            int CommittedOrderHashCode = obj.CommittedOrder?.GetHashCode()??0;
            int CommittedOrderChangedHashCode = obj.CommittedOrderChanged.GetHashCode();
            int IsIgnoredHashCode = obj.IsIgnored.GetHashCode();
            int IsIgnoredChangedHashCode = obj.IsIgnoredChanged.GetHashCode();
            int DeletedHashCode = obj.Deleted.GetHashCode();
            int RecurrenceTypeHashCode = obj.RecurrenceType?.GetHashCode()??0;
            int RecurrenceIntervalHashCode = obj.RecurrenceInterval.GetHashCode();
            int RecurrenceIntervalTypeHashCode = obj.RecurrenceIntervalType?.GetHashCode()??0;
            int RecurrenceDaysOfWeekHashCode = obj.RecurrenceDaysOfWeek?.GetHashCode()??0;
            int RecurrenceChangedHashCode = obj.RecurrenceChanged.GetHashCode();
            int SourceHashCode = obj.Source?.GetHashCode()??0;
            int CreatedByHashCode = obj.CreatedBy?.GetHashCode()??0;
            int CompletedByHashCode = obj.CompletedBy?.GetHashCode()??0;
            int AllowedScopesHashCode = obj.AllowedScopes?.GetHashCode()??0;
            int LastModifiedDateTimeHashCode = obj.LastModifiedDateTime?.GetHashCode()??0;
            return 
                IdHashCode ^
                OnlineIdHashCode ^
                LocalIdHashCode ^
                ChangeKeyHashCode ^
                DeleteAfterSyncHashCode ^
                DueDateHashCode ^
                DueDateChangedHashCode ^
                TaskFolderLocalIdHashCode ^
                TaskFolderLocalIdChangedHashCode ^
                StatusHashCode ^
                StatusChangedHashCode ^
                ImportanceHashCode ^
                ImportanceChangedHashCode ^
                SubjectHashCode ^
                SubjectChangedHashCode ^
                BodyContentHashCode ^
                BodyContentChangedHashCode ^
                OriginalBodyContentHashCode ^
                BodyContentTypeHashCode ^
                BodyContentTypeChangedHashCode ^
                BodyLastModifiedHashCode ^
                BodyLastModifiedChangedHashCode ^
                IsReminderOnHashCode ^
                IsReminderOnChangedHashCode ^
                ReminderDatetimeHashCode ^
                ReminderDatetimeChangedHashCode ^
                ReminderTypeHashCode ^
                PositionHashCode ^
                PositionChangedHashCode ^
                CreatedDatetimeHashCode ^
                CompletedDatetimeHashCode ^
                CompletedDatetimeChangedHashCode ^
                ImportedHashCode ^
                PostponedDateHashCode ^
                PostponedDateChangedHashCode ^
                CommittedDateHashCode ^
                CommittedDateChangedHashCode ^
                CommittedOrderHashCode ^
                CommittedOrderChangedHashCode ^
                IsIgnoredHashCode ^
                IsIgnoredChangedHashCode ^
                DeletedHashCode ^
                RecurrenceTypeHashCode ^
                RecurrenceIntervalHashCode ^
                RecurrenceIntervalTypeHashCode ^
                RecurrenceDaysOfWeekHashCode ^
                RecurrenceChangedHashCode ^
                SourceHashCode ^
                CreatedByHashCode ^
                CompletedByHashCode ^
                AllowedScopesHashCode ^
                LastModifiedDateTimeHashCode;
        }
    }
}

