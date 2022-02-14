using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Activities.ViewModels
{
    public class ActivitiesViewModel : ResultViewModel
    {
        public ActivitiesViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public List<ActivityDto> Activities { get; set; }
    }
}
