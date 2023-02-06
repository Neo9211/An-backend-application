using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectNav1913216.Models
{
    public class Task   
    {
        [Key]
        public string TaskUId { get; set; }
        [Required]
        public string CreatedByUid { get; set; }
        [Required]
        public string CreatedByName { get; set; }
        [Required]
        public string AssignedToUid { get; set; }
        [Required]
        public string AssignedToName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done = false;

        public Task(string TaskUId, string CreatedByUid, string CreatedByName, string AssignedToUid, string AssignedToName, string Description, bool Done)
        {
            Guid Task = Guid.NewGuid();
            TaskUId = TaskUId;
            CreatedByUid = CreatedByUid;
            CreatedByName = CreatedByName;
            AssignedToUid = AssignedToUid;
            AssignedToName = AssignedToName;
            Description = Description;
        }
    }
}
