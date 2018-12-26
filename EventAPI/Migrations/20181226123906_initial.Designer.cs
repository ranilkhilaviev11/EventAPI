﻿// <auto-generated />
using System;
using EventAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EventAPI.Migrations
{
    [DbContext(typeof(MailingContext))]
    [Migration("20181226123906_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EventAPI.Company", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CompanyFieldOfActivity")
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("MainOfficeCountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(120)");

                    b.HasKey("Id");

                    b.HasIndex("MainOfficeCountryId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Company_name_key");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EventAPI.Country", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(60)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("EventAPI.EventProgElem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp(6) without time zone");

                    b.Property<int>("EventId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(120)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp(6) without time zone");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TypeId");

                    b.ToTable("EventProgElem");
                });

            modelBuilder.Entity("EventAPI.Events", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Enddate")
                        .HasColumnName("enddate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Endreg")
                        .HasColumnName("endreg")
                        .HasColumnType("date");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("character varying(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(120)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartReg")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Event_Name_key");

                    b.ToTable("event");
                });

            modelBuilder.Entity("EventAPI.Hotel", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("EventAPI.HotelRoomType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("HotelId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("Type")
                        .IsUnique()
                        .HasName("HotelRoomType_Type_key");

                    b.ToTable("HotelRoomType");
                });

            modelBuilder.Entity("EventAPI.Newsletter", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("EventId");

                    b.Property<string>("File")
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("SendDateTime");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Newsletter");
                });

            modelBuilder.Entity("EventAPI.NewsletterToParticipant", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("NewsletterId");

                    b.Property<int>("ParticipantId");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("NewsletterId", "ParticipantId")
                        .IsUnique()
                        .HasName("UI_Newsletter_to_Participant");

                    b.ToTable("Newsletter_to_Participant");
                });

            modelBuilder.Entity("EventAPI.Participant", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("CitizenshipId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("EventId");

                    b.Property<int?>("HotelId");

                    b.Property<int?>("HotelRoomTypeId");

                    b.Property<string>("MiddleName")
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Post")
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("ResidenceCountryId");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EventId");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelRoomTypeId");

                    b.HasIndex("ResidenceCountryId");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("EventAPI.ParticipantToEventProgElem", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("EventProgElemId");

                    b.Property<int>("ParticipantId");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("EventProgElemId", "ParticipantId")
                        .IsUnique()
                        .HasName("UI_Participant_to_EventProgElem_EventProgElemId_ParticipantId");

                    b.ToTable("Participant_to_EventProgElem");
                });

            modelBuilder.Entity("EventAPI.Type", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("Type_Name_key");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("EventAPI.Company", b =>
                {
                    b.HasOne("EventAPI.Country", "MainOfficeCountry")
                        .WithMany("Company")
                        .HasForeignKey("MainOfficeCountryId")
                        .HasConstraintName("Company_MainOfficeCountryId_fkey");
                });

            modelBuilder.Entity("EventAPI.EventProgElem", b =>
                {
                    b.HasOne("EventAPI.Events", "Event")
                        .WithMany("EventProgElem")
                        .HasForeignKey("EventId")
                        .HasConstraintName("EventProgElem_EventId_fkey");

                    b.HasOne("EventAPI.Type", "Type")
                        .WithMany("EventProgElem")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("EventProgElem_TypeId_fkey");
                });

            modelBuilder.Entity("EventAPI.HotelRoomType", b =>
                {
                    b.HasOne("EventAPI.Hotel", "hotel")
                        .WithMany("HotelRoomType")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("HotelRoomType_HotelId_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventAPI.Newsletter", b =>
                {
                    b.HasOne("EventAPI.Events", "Event")
                        .WithMany("Newsletter")
                        .HasForeignKey("EventId")
                        .HasConstraintName("Newsletter_EventId_fkey");
                });

            modelBuilder.Entity("EventAPI.NewsletterToParticipant", b =>
                {
                    b.HasOne("EventAPI.Newsletter", "Newsletter")
                        .WithMany("NewsletterToParticipant")
                        .HasForeignKey("NewsletterId")
                        .HasConstraintName("Newsletter_to_Participant_NewsletterId_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventAPI.Participant", "Participant")
                        .WithMany("NewsletterToParticipant")
                        .HasForeignKey("ParticipantId")
                        .HasConstraintName("Newsletter_to_Participant_ParticipantId_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EventAPI.Participant", b =>
                {
                    b.HasOne("EventAPI.Country", "Citizenship")
                        .WithMany("ParticipantCitizenship")
                        .HasForeignKey("CitizenshipId")
                        .HasConstraintName("Participant_CitizenshipId_fkey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EventAPI.Company", "Company")
                        .WithMany("Participant")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("Participant_CompanyId_fkey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EventAPI.Events", "Event")
                        .WithMany("Participant")
                        .HasForeignKey("EventId")
                        .HasConstraintName("Participant_EventId_fkey");

                    b.HasOne("EventAPI.Hotel", "Hotel")
                        .WithMany("Participant")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("Participant_HotelId_fkey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EventAPI.HotelRoomType", "HotelRoomType")
                        .WithMany("Participant")
                        .HasForeignKey("HotelRoomTypeId")
                        .HasConstraintName("Participant_HotelRoomTypeId_fkey")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("EventAPI.Country", "ResidenceCountry")
                        .WithMany("ParticipantResidenceCountry")
                        .HasForeignKey("ResidenceCountryId")
                        .HasConstraintName("Participant_ResidenceCountryId_fkey")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("EventAPI.ParticipantToEventProgElem", b =>
                {
                    b.HasOne("EventAPI.EventProgElem", "EventProgElem")
                        .WithMany("ParticipantToEventProgElem")
                        .HasForeignKey("EventProgElemId")
                        .HasConstraintName("Participant_to_EventProgElem_EventProgElemId_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventAPI.Participant", "Participant")
                        .WithMany("ParticipantToEventProgElem")
                        .HasForeignKey("ParticipantId")
                        .HasConstraintName("Participant_to_EventProgElem_ParticipantId_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
