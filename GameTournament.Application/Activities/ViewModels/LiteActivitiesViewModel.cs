using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Activities.ViewModels
{
    public class LiteActivitiesViewModel : ResultViewModel
    {
        public LiteActivitiesViewModel(bool succeeded, IEnumerable<string> errors)
                     : base(succeeded, errors)
        {
        }

        public List<LiteActivityDto> LiteActivities { get; set; }
    }
}
