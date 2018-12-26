using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "character varying(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "character varying(120)", nullable: false),
                    Location = table.Column<string>(type: "character varying(120)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    enddate = table.Column<DateTime>(type: "date", nullable: false),
                    StartReg = table.Column<DateTime>(type: "date", nullable: false),
                    endreg = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "character varying(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "character varying(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(type: "character varying(120)", nullable: false),
                    CompanyFieldOfActivity = table.Column<string>(type: "character varying(30)", nullable: true),
                    MainOfficeCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "Company_MainOfficeCountryId_fkey",
                        column: x => x.MainOfficeCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    SendDateTime = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(type: "character varying(1000)", nullable: false),
                    File = table.Column<string>(type: "character varying(200)", nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter", x => x.Id);
                    table.ForeignKey(
                        name: "Newsletter_EventId_fkey",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(type: "character varying(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomType", x => x.Id);
                    table.ForeignKey(
                        name: "HotelRoomType_HotelId_fkey",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProgElem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProgElem", x => x.Id);
                    table.ForeignKey(
                        name: "EventProgElem_EventId_fkey",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EventProgElem_TypeId_fkey",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(type: "character varying(30)", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(20)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNum = table.Column<string>(type: "character varying(25)", nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", nullable: false),
                    Post = table.Column<string>(type: "character varying(30)", nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    ResidenceCountryId = table.Column<int>(nullable: true),
                    CitizenshipId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    HotelId = table.Column<int>(nullable: true),
                    HotelRoomTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "Participant_CitizenshipId_fkey",
                        column: x => x.CitizenshipId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Participant_CompanyId_fkey",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Participant_EventId_fkey",
                        column: x => x.EventId,
                        principalTable: "event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Participant_HotelId_fkey",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Participant_HotelRoomTypeId_fkey",
                        column: x => x.HotelRoomTypeId,
                        principalTable: "HotelRoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "Participant_ResidenceCountryId_fkey",
                        column: x => x.ResidenceCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Newsletter_to_Participant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NewsletterId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter_to_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "Newsletter_to_Participant_NewsletterId_fkey",
                        column: x => x.NewsletterId,
                        principalTable: "Newsletter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Newsletter_to_Participant_ParticipantId_fkey",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant_to_EventProgElem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EventProgElemId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant_to_EventProgElem", x => x.Id);
                    table.ForeignKey(
                        name: "Participant_to_EventProgElem_EventProgElemId_fkey",
                        column: x => x.EventProgElemId,
                        principalTable: "EventProgElem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Participant_to_EventProgElem_ParticipantId_fkey",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_MainOfficeCountryId",
                table: "Company",
                column: "MainOfficeCountryId");

            migrationBuilder.CreateIndex(
                name: "Company_name_key",
                table: "Company",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Event_Name_key",
                table: "event",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventProgElem_EventId",
                table: "EventProgElem",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProgElem_TypeId",
                table: "EventProgElem",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomType_HotelId",
                table: "HotelRoomType",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "HotelRoomType_Type_key",
                table: "HotelRoomType",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Newsletter_EventId",
                table: "Newsletter",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Newsletter_to_Participant_ParticipantId",
                table: "Newsletter_to_Participant",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "UI_Newsletter_to_Participant",
                table: "Newsletter_to_Participant",
                columns: new[] { "NewsletterId", "ParticipantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participant_CitizenshipId",
                table: "Participant",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_CompanyId",
                table: "Participant",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_EventId",
                table: "Participant",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_HotelId",
                table: "Participant",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_HotelRoomTypeId",
                table: "Participant",
                column: "HotelRoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_ResidenceCountryId",
                table: "Participant",
                column: "ResidenceCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_to_EventProgElem_ParticipantId",
                table: "Participant_to_EventProgElem",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "UI_Participant_to_EventProgElem_EventProgElemId_ParticipantId",
                table: "Participant_to_EventProgElem",
                columns: new[] { "EventProgElemId", "ParticipantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Type_Name_key",
                table: "Type",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newsletter_to_Participant");

            migrationBuilder.DropTable(
                name: "Participant_to_EventProgElem");

            migrationBuilder.DropTable(
                name: "Newsletter");

            migrationBuilder.DropTable(
                name: "EventProgElem");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "HotelRoomType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}
