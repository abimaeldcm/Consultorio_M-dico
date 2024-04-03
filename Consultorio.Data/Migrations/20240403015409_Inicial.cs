using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalSpeciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterCRM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdSpeciality = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Speciality_IdSpeciality",
                        column: x => x.IdSpeciality,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    Convenio = table.Column<byte>(type: "tinyint", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentifiedGoogleCalendar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consults_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consults_Patients_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consults_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "BirthDate", "BloodType", "CPF", "Email", "Height", "LastName", "Name", "PhoneNumber", "Weight" },
                values: new object[,]
                {
                    { 1, "Rua das Flores, Nº 10", new DateTime(1990, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "12345678901", "maria.silva@email.com", 1.3600000000000001, "da Silva", "Maria", "869988776655", 70.0 },
                    { 2, "Av. Central, Nº 50", new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "23456789012", "jose.santos@email.com", 1.8, "Santos", "José", "869977665544", 85.0 },
                    { 3, "Rua dos Pássaros, Nº 25", new DateTime(1993, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "34567890123", "ana.souza@email.com", 1.6499999999999999, "Souza", "Ana", "869966554433", 60.0 },
                    { 4, "Av. Brasil, Nº 100", new DateTime(1980, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "45678901234", "carlos.oliveira@email.com", 1.7, "Oliveira", "Carlos", "869955443322", 75.0 },
                    { 5, "Rua Principal, Nº 300", new DateTime(1975, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "56789012345", "mariana.costa@email.com", 1.6000000000000001, "Costa", "Mariana", "869944332211", 65.0 },
                    { 6, "Av. das Árvores, Nº 15", new DateTime(1992, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "67890123456", "rafael.oliveira@email.com", 1.8500000000000001, "Oliveira", "Rafael", "869933221100", 80.0 },
                    { 7, "Rua do Sol, Nº 200", new DateTime(1987, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "78901234567", "juliana.lima@email.com", 1.75, "Lima", "Juliana", "869922110011", 70.0 },
                    { 8, "Av. das Estrelas, Nº 75", new DateTime(1996, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "89012345678", "fernando.santos@email.com", 1.8, "Santos", "Fernando", "869911001122", 85.0 },
                    { 9, "Av. das Estrelas, Nº 75", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "89012345678", "abimaelmends@hotmail.com", 1.8, "Mendes", "Abimael", "86995287928", 85.0 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Duration", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Atendimento médico geral para pacientes de todas as idades.", 60, "Clínico Geral", 150m },
                    { 2, "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças que acometem o coração.", 60, "Cardiologia", 200m },
                    { 3, "Especialidade médica dedicada à assistência à criança e ao adolescente, nos seus diversos aspectos, sejam eles preventivos ou curativos.", 45, "Pediatria", 120m },
                    { 4, "Especialidade médica que cuida das doenças e deformidades dos ossos, músculos, ligamentos e articulações.", 45, "Ortopedia", 180m },
                    { 5, "Especialidade médica que cuida da saúde da pele, cabelos e unhas.", 30, "Dermatologia", 100m },
                    { 6, "Especialidade médica que trata das doenças relacionadas com os olhos e com a visão.", 30, "Oftalmologia", 150m },
                    { 7, "Especialidade médica que lida com a prevenção, atendimento, diagnóstico, tratamento e reabilitação das diferentes formas de sofrimentos mentais, sejam elas de cunho orgânico ou funcional.", 60, "Psiquiatria", 250m },
                    { 8, "Especialidade médica que trata da saúde da mulher, especialmente do sistema reprodutor feminino.", 45, "Ginecologia", 180m },
                    { 9, "Especialidade médica que trata do trato urinário de homens e mulheres e do sistema reprodutor dos homens.", 45, "Urologia", 200m },
                    { 10, "Especialidade médica que trata dos distúrbios estruturais do sistema nervoso.", 60, "Neurologia", 220m }
                });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "MedicalSpeciality" },
                values: new object[,]
                {
                    { 1, "Clínico Geral" },
                    { 2, "Cardiologia" },
                    { 3, "Pediatria" },
                    { 4, "Ortopedia" },
                    { 5, "Dermatologia" },
                    { 6, "Oftalmologia" },
                    { 7, "Psiquiatria" },
                    { 8, "Ginecologia" },
                    { 9, "Urologia" },
                    { 10, "Neurologia" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Address", "BirthDate", "BloodType", "CPF", "Email", "IdSpeciality", "LastName", "Name", "PhoneNumber", "RegisterCRM" },
                values: new object[,]
                {
                    { 1, "Rua dos Bobos, Nº 0", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "06445663225", "AntonioCaudas@email.com", 1, "Pereira Caudas", "Antônio", "86995287928", "12345/PI" },
                    { 2, "Av. Brasil, Nº 100", new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "09876543210", "joao.silva@email.com", 2, "da Silva", "João", "86995554433", "54321/PI" },
                    { 3, "Rua das Flores, Nº 50", new DateTime(1976, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "11223344556", "maria.oliveira@email.com", 2, "Oliveira", "Maria", "869944332211", "67890/PI" },
                    { 4, "Av. Principal, Nº 300", new DateTime(1990, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "55443322111", "carlos.souza@email.com", 4, "Souza", "Carlos", "869966998877", "13579/PI" },
                    { 5, "Rua da Paz, Nº 15", new DateTime(1983, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "33445566778", "ana.santos@email.com", 5, "Santos", "Ana", "869977776655", "24680/PI" },
                    { 6, "Av. Central, Nº 200", new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "99887766554", "pedro.moraes@email.com", 6, "Moraes", "Pedro", "869988887766", "97531/PI" },
                    { 7, "Rua das Árvores, Nº 30", new DateTime(1980, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "22113344556", "fernanda.costa@email.com", 7, "Costa", "Fernanda", "869933377755", "86420/PI" },
                    { 8, "Av. das Estrelas, Nº 75", new DateTime(1995, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "77889900123", "rafaela.lima@email.com", 8, "Lima", "Rafaela", "869922223344", "54321/PI" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consults_IdDoctor",
                table: "Consults",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_IdPatient",
                table: "Consults",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Consults_IdService",
                table: "Consults",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_IdSpeciality",
                table: "Doctors",
                column: "IdSpeciality");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consults");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}
