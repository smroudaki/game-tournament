using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using GameTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(GameTournamentTournamentContext context)
            : base(context)
        {
        }

        public async Task<Document> GetByGuidAsync(Guid documentGuid)
        {
            return await _context.Document
                .SingleOrDefaultAsync(u => u.DocumentGuid.Equals(documentGuid));
        }

        public string GetDocumentType(DocumentType documentType)
        {
            string type;

            // Check if the file's extension is valid
            switch (documentType)
            {
                case DocumentType.PNG:
                    type = "image/png";
                    break;
                case DocumentType.JPG:
                    type = "image/jpg";
                    break;
                case DocumentType.JPEG:
                    type = "image/jpeg";
                    break;
                default:
                    type = null;
                    break;
            }

            return type;
        }
    }
}
