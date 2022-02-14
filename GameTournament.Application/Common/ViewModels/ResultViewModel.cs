using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTournament.Application.Common.ViewModels
{
    public class ResultViewModel
    {
        internal ResultViewModel(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public static ResultViewModel Success()
        {
            return new ResultViewModel(true, new string[] { });
        }

        public static ResultViewModel Failure(IEnumerable<string> errors)
        {
            return new ResultViewModel(false, errors);
        }
    }
}
