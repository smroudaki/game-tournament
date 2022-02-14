using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Activities.ViewModels
{
    public class ActivityViewModel : ResultViewModel
    {
        public ActivityViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public ActivityDto Activities { get; set; }
    }

    public class ActivityDto
    {
        [JsonIgnore]
        public int ActivityId { get; set; }
        public Guid ActivityGuid { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
