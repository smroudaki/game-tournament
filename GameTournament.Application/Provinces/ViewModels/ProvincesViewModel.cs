using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Provinces.ViewModels
{
    public class ProvincesViewModel : ResultViewModel
    {
        public ProvincesViewModel(bool succeeded, IEnumerable<string> errors)
            : base(succeeded, errors)
        {
        }

        public List<ProvinceDto> Provinces { get; set; }
    }
}
