using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.ViewModels
{
    public class UsersViewModel : ResultViewModel
    {
        public UsersViewModel(bool succeeded, IEnumerable<string> errors)
            : base(succeeded, errors)
        {
        }

        public List<UserDto> Users { get; set; }
    }
}
