using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Provinces.ViewModels
{
    public class ProvinceViewModel : ResultViewModel
    {
        public ProvinceViewModel(bool succeeded, IEnumerable<string> errors)
            : base(succeeded, errors)
        {
        }

        public ProvinceDto Province { get; set; }
    }

    public class ProvinceDto
    {
        [JsonIgnore]
        public int ProvinceId { get; set; }
        public Guid ProvinceGuid { get; set; }
        public string Name { get; set; }
    }
}
