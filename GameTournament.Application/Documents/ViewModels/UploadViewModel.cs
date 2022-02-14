using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTournament.Application.Documents.ViewModels
{
    public class UploadViewModel
    {
        internal UploadViewModel(bool succeeded,
               IEnumerable<string> errors,
               Guid documentGuid,
               string url)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            DocumentGuid = documentGuid;
            Url = url;
        }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public Guid DocumentGuid { get; set; }
        public string Url { get; set; }

        public static UploadViewModel Success(Guid documentGuid, string url)
        {
            return new UploadViewModel(true,
                new string[] { },
                documentGuid,
                url);
        }

        public static UploadViewModel Failure(IEnumerable<string> errors)
        {
            return new UploadViewModel(false,
                errors,
                Guid.Empty,
                string.Empty);
        }
    }
}
