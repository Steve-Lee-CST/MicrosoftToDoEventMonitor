using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using MicrosoftToDoEventMonitor.Modules;

namespace MicrosoftToDoEventMonitor
{
    public class EventMonitor
    {
        #region events
        public event Action<List<Activity>> OnActivityAdded;
        public event Action<List<Activity>> OnActivityDeleted;
        public event Action<List<(Activity, Activity)>> OnActivityChanged;

        public event Action<List<Assignment>> OnAssignmentAdded;
        public event Action<List<Assignment>> OnAssignmentDeleted;
        public event Action<List<(Assignment, Assignment)>> OnAssignmentChanged;

        public event Action<List<Capability>> OnCapabilityAdded;
        public event Action<List<Capability>> OnCapabilityDeleted;
        public event Action<List<(Capability, Capability)>> OnCapabilityChanged;

        public event Action<List<FolderImportMetadata>> OnFolderImportMetadataAdded;
        public event Action<List<FolderImportMetadata>> OnFolderImportMetadataDeleted;
        public event Action<List<(FolderImportMetadata, FolderImportMetadata)>> OnFolderImportMetadataChanged;

        public event Action<List<Group>> OnGroupAdded;
        public event Action<List<Group>> OnGroupDeleted;
        public event Action<List<(Group, Group)>> OnGroupChanged;

        public event Action<List<LinkedEntity>> OnLinkedEntityAdded;
        public event Action<List<LinkedEntity>> OnLinkedEntityDeleted;
        public event Action<List<(LinkedEntity, LinkedEntity)>> OnLinkedEntityChanged;

        public event Action<List<Member>> OnMemberAdded;
        public event Action<List<Member>> OnMemberDeleted;
        public event Action<List<(Member, Member)>> OnMemberChanged;

        public event Action<List<Setting>> OnSettingAdded;
        public event Action<List<Setting>> OnSettingDeleted;
        public event Action<List<(Setting, Setting)>> OnSettingChanged;

        public event Action<List<Step>> OnStepAdded;
        public event Action<List<Step>> OnStepDeleted;
        public event Action<List<(Step, Step)>> OnStepChanged;

        public event Action<List<Task>> OnTaskAdded;
        public event Action<List<Task>> OnTaskDeleted;
        public event Action<List<(Task, Task)>> OnTaskChanged;

        public event Action<List<TaskFolder>> OnTaskFolderAdded;
        public event Action<List<TaskFolder>> OnTaskFolderDeleted;
        public event Action<List<(TaskFolder, TaskFolder)>> OnTaskFolderChanged;
        #endregion

        public DBContext ToDoDBContext { get; protected set; }
        public DBContext SnapshotDBContext { get; protected set; }
        public DBDataCollection ToDoDBData { get; protected set; } = new();
        public DBDataCollection SnapshotDBData { get; protected set; } = new();
        public int QueryFrequence { get; protected set; }

        protected Timer Timer;
        protected readonly object timerLocker = new object();

        public EventMonitor(string todoDBPath, string snapshotDBPath, int queryFrequence = 3000)
        {
            ToDoDBContext = new DBContext(DBContext.CreateConnectionStringWithDBPath(todoDBPath));
            SnapshotDBContext = new DBContext(DBContext.CreateConnectionStringWithDBPath(snapshotDBPath));
            if (!File.Exists(snapshotDBPath))
                SnapshotDBContext.Database.EnsureCreated();
            QueryFrequence = queryFrequence;

            SnapshotDBData.Refresh(SnapshotDBContext);

            Timer = new Timer(QueryFrequence);
            Timer.Elapsed += (s, e) =>
            {
                lock(timerLocker)
                {
                    QueryData();
                }
            };
            Timer.AutoReset = true;
            Timer.Start();
        }

        protected virtual void QueryData()
        {
            ToDoDBData.Refresh(ToDoDBContext);

            QueryActivity();
            QueryAssignment();
            QueryCapability();
            QueryFolderImportMetadata();
            QueryGroup();
            QueryLinkedEntity();
            QueryMember();
            QuerySetting();
            QueryStep();
            QueryTaskFolder();
            QueryTask();

            SnapshotDBData.Refresh(ToDoDBContext);
        }

        protected virtual void QueryActivity()
        {
            List<Activity> added = ToDoDBData.Activities.Except(SnapshotDBData.Activities, new ActivityAODComparer()).ToList();
            List<Activity> deleted = SnapshotDBData.Activities.Except(ToDoDBData.Activities, new ActivityAODComparer()).ToList();
            List<Activity> todo = ToDoDBData.Activities.Intersect(SnapshotDBData.Activities, new ActivityAODComparer()).ToList();
            List<Activity> snapshot = SnapshotDBData.Activities.Intersect(ToDoDBData.Activities, new ActivityAODComparer()).ToList();
            List<Activity> pres = snapshot.Except(todo, new ActivityAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Activity> nows = todo.Except(snapshot, new ActivityAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnActivityAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnActivityDeleted?.Invoke(deleted);
            }

            List<(Activity, Activity)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnActivityChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryAssignment()
        {
            List<Assignment> added = ToDoDBData.Assignments.Except(SnapshotDBData.Assignments, new AssignmentAODComparer()).ToList();
            List<Assignment> deleted = SnapshotDBData.Assignments.Except(ToDoDBData.Assignments, new AssignmentAODComparer()).ToList();
            List<Assignment> todo = ToDoDBData.Assignments.Intersect(SnapshotDBData.Assignments, new AssignmentAODComparer()).ToList();
            List<Assignment> snapshot = SnapshotDBData.Assignments.Intersect(ToDoDBData.Assignments, new AssignmentAODComparer()).ToList();
            List<Assignment> pres = snapshot.Except(todo, new AssignmentAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Assignment> nows = todo.Except(snapshot, new AssignmentAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnAssignmentAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnAssignmentDeleted?.Invoke(deleted);
            }

            List<(Assignment, Assignment)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnAssignmentChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryCapability()
        {
            List<Capability> added = ToDoDBData.Capabilities.Except(SnapshotDBData.Capabilities, new CapabilityAODComparer()).ToList();
            List<Capability> deleted = SnapshotDBData.Capabilities.Except(ToDoDBData.Capabilities, new CapabilityAODComparer()).ToList();
            List<Capability> todo = ToDoDBData.Capabilities.Intersect(SnapshotDBData.Capabilities, new CapabilityAODComparer()).ToList();
            List<Capability> snapshot = SnapshotDBData.Capabilities.Intersect(ToDoDBData.Capabilities, new CapabilityAODComparer()).ToList();
            List<Capability> pres = snapshot.Except(todo, new CapabilityAODComparer()).OrderBy(t => t.Id).ToList();
            List<Capability> nows = todo.Except(snapshot, new CapabilityAODComparer()).OrderBy(t => t.Id).ToList();

            if (added.Count != 0)
            {
                OnCapabilityAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnCapabilityDeleted?.Invoke(deleted);
            }

            List<(Capability, Capability)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnCapabilityChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryFolderImportMetadata()
        {
            List<FolderImportMetadata> added = ToDoDBData.FolderImportMetadatas.Except(SnapshotDBData.FolderImportMetadatas, new FolderImportMetadataAODComparer()).ToList();
            List<FolderImportMetadata> deleted = SnapshotDBData.FolderImportMetadatas.Except(ToDoDBData.FolderImportMetadatas, new FolderImportMetadataAODComparer()).ToList();
            List<FolderImportMetadata> todo = ToDoDBData.FolderImportMetadatas.Intersect(SnapshotDBData.FolderImportMetadatas, new FolderImportMetadataAODComparer()).ToList();
            List<FolderImportMetadata> snapshot = SnapshotDBData.FolderImportMetadatas.Intersect(ToDoDBData.FolderImportMetadatas, new FolderImportMetadataAODComparer()).ToList();
            List<FolderImportMetadata> pres = snapshot.Except(todo, new FolderImportMetadataAODComparer()).OrderBy(t => t.WunderlistId).ToList();
            List<FolderImportMetadata> nows = todo.Except(snapshot, new FolderImportMetadataAODComparer()).OrderBy(t => t.WunderlistId).ToList();

            if (added.Count != 0)
            {
                OnFolderImportMetadataAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnFolderImportMetadataDeleted?.Invoke(deleted);
            }

            List<(FolderImportMetadata, FolderImportMetadata)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnFolderImportMetadataChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryGroup()
        {
            List<Group> added = ToDoDBData.Groups.Except(SnapshotDBData.Groups, new GroupAODComparer()).ToList();
            List<Group> deleted = SnapshotDBData.Groups.Except(ToDoDBData.Groups, new GroupAODComparer()).ToList();
            List<Group> todo = ToDoDBData.Groups.Intersect(SnapshotDBData.Groups, new GroupAODComparer()).ToList();
            List<Group> snapshot = SnapshotDBData.Groups.Intersect(ToDoDBData.Groups, new GroupAODComparer()).ToList();
            List<Group> pres = snapshot.Except(todo, new GroupAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Group> nows = todo.Except(snapshot, new GroupAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnGroupAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnGroupDeleted?.Invoke(deleted);
            }

            List<(Group, Group)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnGroupChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryLinkedEntity()
        {
            List<LinkedEntity> added = ToDoDBData.LinkedEntities.Except(SnapshotDBData.LinkedEntities, new LinkedEntityAODComparer()).ToList();
            List<LinkedEntity> deleted = SnapshotDBData.LinkedEntities.Except(ToDoDBData.LinkedEntities, new LinkedEntityAODComparer()).ToList();
            List<LinkedEntity> todo = ToDoDBData.LinkedEntities.Intersect(SnapshotDBData.LinkedEntities, new LinkedEntityAODComparer()).ToList();
            List<LinkedEntity> snapshot = SnapshotDBData.LinkedEntities.Intersect(ToDoDBData.LinkedEntities, new LinkedEntityAODComparer()).ToList();
            List<LinkedEntity> pres = snapshot.Except(todo, new LinkedEntityAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<LinkedEntity> nows = todo.Except(snapshot, new LinkedEntityAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnLinkedEntityAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnLinkedEntityDeleted?.Invoke(deleted);
            }

            List<(LinkedEntity, LinkedEntity)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnLinkedEntityChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryMember()
        {
            List<Member> added = ToDoDBData.Members.Except(SnapshotDBData.Members, new MemberAODComparer()).ToList();
            List<Member> deleted = SnapshotDBData.Members.Except(ToDoDBData.Members, new MemberAODComparer()).ToList();
            List<Member> todo = ToDoDBData.Members.Intersect(SnapshotDBData.Members, new MemberAODComparer()).ToList();
            List<Member> snapshot = SnapshotDBData.Members.Intersect(ToDoDBData.Members, new MemberAODComparer()).ToList();
            List<Member> pres = snapshot.Except(todo, new MemberAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Member> nows = todo.Except(snapshot, new MemberAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnMemberAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnMemberDeleted?.Invoke(deleted);
            }

            List<(Member, Member)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnMemberChanged?.Invoke(changeed);
            }
        }

        protected virtual void QuerySetting()
        {
            List<Setting> added = ToDoDBData.Settings.Except(SnapshotDBData.Settings, new SettingAODComparer()).ToList();
            List<Setting> deleted = SnapshotDBData.Settings.Except(ToDoDBData.Settings, new SettingAODComparer()).ToList();
            List<Setting> todo = ToDoDBData.Settings.Intersect(SnapshotDBData.Settings, new SettingAODComparer()).ToList();
            List<Setting> snapshot = SnapshotDBData.Settings.Intersect(ToDoDBData.Settings, new SettingAODComparer()).ToList();
            List<Setting> pres = snapshot.Except(todo, new SettingAODComparer()).OrderBy(t => t.Key).ToList();
            List<Setting> nows = todo.Except(snapshot, new SettingAODComparer()).OrderBy(t => t.Key).ToList();

            if (added.Count != 0)
            {
                OnSettingAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnSettingDeleted?.Invoke(deleted);
            }

            List<(Setting, Setting)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnSettingChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryStep()
        {
            List<Step> added = ToDoDBData.Steps.Except(SnapshotDBData.Steps, new StepAODComparer()).ToList();
            List<Step> deleted = SnapshotDBData.Steps.Except(ToDoDBData.Steps, new StepAODComparer()).ToList();
            List<Step> todo = ToDoDBData.Steps.Intersect(SnapshotDBData.Steps, new StepAODComparer()).ToList();
            List<Step> snapshot = SnapshotDBData.Steps.Intersect(ToDoDBData.Steps, new StepAODComparer()).ToList();
            List<Step> pres = snapshot.Except(todo, new StepAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Step> nows = todo.Except(snapshot, new StepAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnStepAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnStepDeleted?.Invoke(deleted);
            }

            List<(Step, Step)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnStepChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryTaskFolder()
        {
            List<TaskFolder> added = ToDoDBData.TaskFolders.Except(SnapshotDBData.TaskFolders, new TaskFolderAODComparer()).ToList();
            List<TaskFolder> deleted = SnapshotDBData.TaskFolders.Except(ToDoDBData.TaskFolders, new TaskFolderAODComparer()).ToList();
            List<TaskFolder> todo = ToDoDBData.TaskFolders.Intersect(SnapshotDBData.TaskFolders, new TaskFolderAODComparer()).ToList();
            List<TaskFolder> snapshot = SnapshotDBData.TaskFolders.Intersect(ToDoDBData.TaskFolders, new TaskFolderAODComparer()).ToList();
            List<TaskFolder> pres = snapshot.Except(todo, new TaskFolderAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<TaskFolder> nows = todo.Except(snapshot, new TaskFolderAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (added.Count != 0)
            {
                OnTaskFolderAdded?.Invoke(added);
            }

            if (deleted.Count != 0)
            {
                OnTaskFolderDeleted?.Invoke(deleted);
            }

            List<(TaskFolder, TaskFolder)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnTaskFolderChanged?.Invoke(changeed);
            }
        }

        protected virtual void QueryTask()
        {
            List<Task> added = ToDoDBData.Tasks.Except(SnapshotDBData.Tasks, new TaskAODComparer()).ToList();
            List<Task> deleted = SnapshotDBData.Tasks.Except(ToDoDBData.Tasks, new TaskAODComparer()).ToList();
            List<Task> todo = ToDoDBData.Tasks.Intersect(SnapshotDBData.Tasks, new TaskAODComparer()).ToList();
            List<Task> snapshot = SnapshotDBData.Tasks.Intersect(ToDoDBData.Tasks, new TaskAODComparer()).ToList();
            List<Task> pres = snapshot.Except(todo, new TaskAODComparer()).OrderBy(t => t.OnlineId).ToList();
            List<Task> nows = todo.Except(snapshot, new TaskAODComparer()).OrderBy(t => t.OnlineId).ToList();

            if (deleted.Count != 0)
            {
                OnTaskDeleted?.Invoke(deleted);
            }

            if (added.Count != 0)
            {
                OnTaskAdded?.Invoke(added);
            }

            List<(Task, Task)> changeed = new();
            for (int i = 0; i < pres.Count; i++)
            {
                changeed.Add((pres[i], nows[i]));
            }

            if (changeed.Count != 0)
            {
                OnTaskChanged?.Invoke(changeed);
            }
        }
    }
}
