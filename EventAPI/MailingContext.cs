using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EventAPI
{
    public partial class MailingContext : DbContext
    {
        public MailingContext()
        {
        }

        public MailingContext(DbContextOptions<MailingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Events> Event { get; set; }
        public virtual DbSet<EventProgElem> EventProgElem { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelRoomType> HotelRoomType { get; set; }
        public virtual DbSet<Newsletter> Newsletter { get; set; }
        public virtual DbSet<NewsletterToParticipant> NewsletterToParticipant { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<ParticipantToEventProgElem> ParticipantToEventProgElem { get; set; }
        public virtual DbSet<Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");

                var options = optionsBuilder
                    .UseNpgsql(connectionString)
                    .Options;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("Company_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyFieldOfActivity).HasColumnType("character varying(30)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(120)");

                entity.HasOne(d => d.MainOfficeCountry)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.MainOfficeCountryId)
                    .HasConstraintName("Company_MainOfficeCountryId_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(60)");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.Name)
                    .HasName("Event_Name_key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Endreg)
                    .HasColumnName("endreg")
                    .HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("character varying(120)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(120)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StartReg).HasColumnType("date");
            });

            modelBuilder.Entity<EventProgElem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.End).HasColumnType("timestamp(6) without time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying(120)");

                entity.Property(e => e.Start).HasColumnType("timestamp(6) without time zone");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventProgElem)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EventProgElem_EventId_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.EventProgElem)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EventProgElem_TypeId_fkey");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(40)");
            });

            modelBuilder.Entity<HotelRoomType>(entity =>
            {
                entity.HasIndex(e => e.Type)
                    .HasName("HotelRoomType_Type_key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("character varying(30)");

                entity.HasOne(d => d.hotel)
                    .WithMany(p => p.HotelRoomType)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("HotelRoomType_HotelId_fkey");
            });

            modelBuilder.Entity<Newsletter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.File).HasColumnType("character varying(200)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("character varying(1000)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Newsletter)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Newsletter_EventId_fkey");
            });

            modelBuilder.Entity<NewsletterToParticipant>(entity =>
            {
                entity.ToTable("Newsletter_to_Participant");

                entity.HasIndex(e => new { e.NewsletterId, e.ParticipantId })
                    .HasName("UI_Newsletter_to_Participant")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Newsletter)
                    .WithMany(p => p.NewsletterToParticipant)
                    .HasForeignKey(d => d.NewsletterId)
                    .HasConstraintName("Newsletter_to_Participant_NewsletterId_fkey");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.NewsletterToParticipant)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("Newsletter_to_Participant_ParticipantId_fkey");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.MiddleName).HasColumnType("character varying(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.PhoneNum).HasColumnType("character varying(25)");

                entity.Property(e => e.Post).HasColumnType("character varying(30)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("character varying(30)");

                entity.HasOne(d => d.Citizenship)
                    .WithMany(p => p.ParticipantCitizenship)
                    .HasForeignKey(d => d.CitizenshipId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Participant_CitizenshipId_fkey");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Participant_CompanyId_fkey");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("Participant_EventId_fkey");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Participant_HotelId_fkey");

                entity.HasOne(d => d.HotelRoomType)
                    .WithMany(p => p.Participant)
                    .HasForeignKey(d => d.HotelRoomTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Participant_HotelRoomTypeId_fkey");

                entity.HasOne(d => d.ResidenceCountry)
                    .WithMany(p => p.ParticipantResidenceCountry)
                    .HasForeignKey(d => d.ResidenceCountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("Participant_ResidenceCountryId_fkey");
            });

            modelBuilder.Entity<ParticipantToEventProgElem>(entity =>
            {
                entity.ToTable("Participant_to_EventProgElem");

                entity.HasIndex(e => new { e.EventProgElemId, e.ParticipantId })
                    .HasName("UI_Participant_to_EventProgElem_EventProgElemId_ParticipantId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.EventProgElem)
                    .WithMany(p => p.ParticipantToEventProgElem)
                    .HasForeignKey(d => d.EventProgElemId)
                    .HasConstraintName("Participant_to_EventProgElem_EventProgElemId_fkey");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.ParticipantToEventProgElem)
                    .HasForeignKey(d => d.ParticipantId)
                    .HasConstraintName("Participant_to_EventProgElem_ParticipantId_fkey");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("Type_Name_key")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying(10)");
            });
        }
    }
}
