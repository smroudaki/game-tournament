using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Activities.ViewModels
{
    public class LiteActivityViewModel : ResultViewModel
    {
        public LiteActivityViewModel(bool succeeded, IEnumerable<string> errors)
                  : base(succeeded, errors)
        {
        }

        public LiteActivityDto Category { get; set; }
    }

    public class LiteActivityDto
    {
        public Guid ActivityGuid { get; set; }
        public string Name { get; set; }
    }
}
