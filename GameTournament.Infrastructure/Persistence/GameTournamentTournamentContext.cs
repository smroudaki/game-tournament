using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GameTournament.Infrastructure.Persistence
{
    public partial class GameTournamentTournamentContext : DbContext
    {
        public GameTournamentTournamentContext()
        {
        }

        public GameTournamentTournamentContext(DbContextOptions<GameTournamentTournamentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostCategory> PostCategory { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
