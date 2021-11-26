using System.Collections.Generic;
using System.Linq;

using MicrosoftToDoEventMonitor.Modules;

namespace MicrosoftToDoEventMonitor
{
    public class DBDataCollection
    {
        public List<Activity> Activities { get; set; } = new();
        public List<Assignment> Assignments { get; set; } = new();
        public List<Capability> Capabilities { get; set; } = new();
        public List<FolderImportMetadata> FolderImportMetadatas { get; set; } = new();
        public List<LinkedEntity> LinkedEntities { get; set; } = new();
        public List<Member> Members { get; set; } = new();
        public List<Setting> Settings { get; set; } = new();
        public List<Group> Groups { get; set; } = new();
        public List<TaskFolder> TaskFolders { get; set; } = new();
        public List<Task> Tasks { get; set; } = new();
        public List<Step> Steps { get; set; } = new();

        public void Refresh(DBContext context)
        {
            foreach (var entity in context.ChangeTracker.Entries().ToList())
            {
                entity.Reload();
            }

            Activities = context.Activities.ToList();
            Assignments = context.Assignments.ToList();
            Capabilities = context.Capabilities.ToList();
            FolderImportMetadatas = context.FolderImportMetadatas.ToList();
            LinkedEntities = context.LinkedEntities.ToList();
            Members = context.Members.ToList();
            Settings = context.Settings.ToList();
            Groups = context.Groups.ToList();
            TaskFolders = context.TaskFolders.ToList();
            Tasks = context.Tasks.ToList();
            Steps = context.Steps.ToList();
        }
    }
}
