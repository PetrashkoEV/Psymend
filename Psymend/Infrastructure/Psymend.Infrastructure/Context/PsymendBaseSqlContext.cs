using Microsoft.EntityFrameworkCore;
using Psymend.Infrastructure.Core;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Entities;
using Psymend.Infrastructure.Core.Entities.LusherTest;
using Psymend.Infrastructure.Core.Entities.PsychoBioTest;
using Psymend.Infrastructure.EntityTypeConfigurations;
using Psymend.Infrastructure.EntityTypeConfigurations.LusherTest;
using Psymend.Infrastructure.EntityTypeConfigurations.PsychoBioTest;

namespace Psymend.Infrastructure.Context
{
    public class PsymendBaseSqlContext : BaseSqlContext
    {
        public override string ConnectionStingConfigurationName => "Store";

        public PsymendBaseSqlContext(ISqlConnectionStringProvider connectionStringProvider) : base(connectionStringProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TestEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new LusherTestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LusherResultEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LusherChoiceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LusherChoiceColorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LusherInterpretationEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PsychoBioTestQuestionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PsychoBioTestAnswerDefinitionEntityTypeConfiguration());
        }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<PasswordEntity> Passwords { get; set; }
        public virtual DbSet<TestEntity> Tests { get; set; }

        public virtual DbSet<LusherTestEntity> LusherTests { get; set; }
        public virtual DbSet<LusherResultEntity> LusherResults { get; set; }
        public virtual DbSet<LusherChoiceEntity> LusherChoices { get; set; }
        public virtual DbSet<LusherChoiceColorEntity> LusherChoiceColors { get; set; }
        public virtual DbSet<LusherInterpretationEntity> LusherInterpretations { get; set; }

        public virtual DbSet<PsychoBioTestAnswerDefinitionEntity> PsychoBioTestAnswerDefinitions { get; set; }
        public virtual DbSet<PsychoBioTestQuestionEntity> PsychoBioTestQuestions { get; set; }
    }
}