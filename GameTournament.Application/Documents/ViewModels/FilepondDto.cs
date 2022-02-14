using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTournament.Application.Documents.ViewModels
{
    public class FilepondDto
    {
        public Guid Guid { get; set; }
        public string Source { get; set; }
        public FilepondOptions Options { get; set; }
    }

    public class FilepondOptions
    {
        public string Type { get; set; }
        public FilepondFile File { get; set; }
        public FilepondMetadata Metadata { get; set; }
    }

    public class FilepondFile
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
    }

    public class FilepondMetadata
    {
        public string Poster { get; set; }
    }
}
