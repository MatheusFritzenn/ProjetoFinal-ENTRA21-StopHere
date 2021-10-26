using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataInfrastructure.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CEP = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CNPJ = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: true),
                    Nome = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    CPF = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abre = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fecha = table.Column<TimeSpan>(type: "time", nullable: false),
                    DiasDisponiveis = table.Column<int>(type: "int", nullable: false),
                    IsCoberta = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsVigiada = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeixarChave = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parkings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Marca = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Cor = table.Column<int>(type: "int", unicode: false, maxLength: 20, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    TamanhoVeiculo = table.Column<int>(type: "int", nullable: false),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiasDisponiveis = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    ParkingID = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<double>(type: "float", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_Parkings_ParkingID",
                        column: x => x.ParkingID,
                        principalTable: "Parkings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParkingID",
                table: "Locations",
                column: "ParkingID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_VehicleID",
                table: "Locations",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_UserID",
                table: "Parkings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CNPJ",
                table: "Users",
                column: "CNPJ",
                unique: true,
                filter: "[CNPJ] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CPF",
                table: "Users",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_InscricaoEstadual",
                table: "Users",
                column: "InscricaoEstadual",
                unique: true,
                filter: "[InscricaoEstadual] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Placa",
                table: "Vehicles",
                column: "Placa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserID",
                table: "Vehicles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
