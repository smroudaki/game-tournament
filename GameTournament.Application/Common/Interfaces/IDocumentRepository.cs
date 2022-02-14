using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<Document> GetByGuidAsync(Guid documentGuid);
        string GetDocumentType(DocumentType documentType);
    }
}
