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
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadeMedica = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<double>(type: "float", nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSanguineo = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistroCRM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdEspecialidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoSanguineo = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    Convenio = table.Column<byte>(type: "tinyint", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Medicos_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeMedica" },
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
                table: "Pacientes",
                columns: new[] { "Id", "Altura", "CPF", "DataNascimento", "Email", "Endereco", "Nome", "Peso", "Sobrenome", "Telefone", "TipoSanguineo" },
                values: new object[,]
                {
                    { 1, 1.75, "12345678901", new DateTime(1990, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.silva@email.com", "Rua das Flores, Nº 10", "Maria da Silva", 70.0, "da Silva", "869988776655", 0 },
                    { 2, 1.8, "23456789012", new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jose.santos@email.com", "Av. Central, Nº 50", "José Santos", 85.0, "Santos", "869977665544", 3 },
                    { 3, 1.6499999999999999, "34567890123", new DateTime(1993, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.souza@email.com", "Rua dos Pássaros, Nº 25", "Ana Souza", 60.0, "Souza", "869966554433", 5 },
                    { 4, 1.7, "45678901234", new DateTime(1980, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.oliveira@email.com", "Av. Brasil, Nº 100", "Carlos Oliveira", 75.0, "Oliveira", "869955443322", 6 },
                    { 5, 1.6000000000000001, "56789012345", new DateTime(1975, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana.costa@email.com", "Rua Principal, Nº 300", "Mariana Costa", 65.0, "Costa", "869944332211", 0 },
                    { 6, 1.8500000000000001, "67890123456", new DateTime(1992, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafael.oliveira@email.com", "Av. das Árvores, Nº 15", "Rafael Oliveira", 80.0, "Oliveira", "869933221100", 5 },
                    { 7, 1.75, "78901234567", new DateTime(1987, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "juliana.lima@email.com", "Rua do Sol, Nº 200", "Juliana Lima", 70.0, "Lima", "869922110011", 2 },
                    { 8, 1.8, "89012345678", new DateTime(1996, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernando.santos@email.com", "Av. das Estrelas, Nº 75", "Fernando Santos", 85.0, "Santos", "869911001122", 5 }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "CPF", "DataNascimento", "Email", "Endereco", "IdEspecialidade", "Nome", "RegistroCRM", "Sobrenome", "Telefone", "TipoSanguineo" },
                values: new object[,]
                {
                    { 1, "06445663225", new DateTime(1997, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "AntonioCaudas@email.com", "Rua dos Bobos, Nº 0", 1, "Antônio Pereira Caudas", "12345/PI", "Pereira Caudas", "86995287928", 0 },
                    { 2, "09876543210", new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.silva@email.com", "Av. Brasil, Nº 100", 2, "João da Silva", "54321/PI", "da Silva", "86995554433", 7 },
                    { 3, "11223344556", new DateTime(1976, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.oliveira@email.com", "Rua das Flores, Nº 50", 2, "Maria Oliveira", "67890/PI", "Oliveira", "869944332211", 5 },
                    { 4, "55443322111", new DateTime(1990, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.souza@email.com", "Av. Principal, Nº 300", 4, "Carlos Souza", "13579/PI", "Souza", "869966998877", 6 },
                    { 5, "33445566778", new DateTime(1983, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.santos@email.com", "Rua da Paz, Nº 15", 5, "Ana Santos", "24680/PI", "Santos", "869977776655", 5 },
                    { 6, "99887766554", new DateTime(1988, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro.moraes@email.com", "Av. Central, Nº 200", 6, "Pedro Moraes", "97531/PI", "Moraes", "869988887766", 2 },
                    { 7, "22113344556", new DateTime(1980, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernanda.costa@email.com", "Rua das Árvores, Nº 30", 7, "Fernanda Costa", "86420/PI", "Costa", "869933377755", 5 },
                    { 8, "77889900123", new DateTime(1995, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafaela.lima@email.com", "Av. das Estrelas, Nº 75", 8, "Rafaela Lima", "54321/PI", "Lima", "869922223344", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdMedico",
                table: "Atendimentos",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdPaciente",
                table: "Atendimentos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_IdServico",
                table: "Atendimentos",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_IdEspecialidade",
                table: "Medicos",
                column: "IdEspecialidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
