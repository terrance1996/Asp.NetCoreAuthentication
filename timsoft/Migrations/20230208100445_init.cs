using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace timsoft.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    IdQuest = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Intitule = table.Column<string>(type: "text", nullable: false),
                    Durée = table.Column<int>(type: "integer", nullable: false),
                    Catégorie = table.Column<string>(type: "text", nullable: false),
                    Point = table.Column<int>(type: "integer", nullable: false),
                    NbRep = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.IdQuest);
                });

            migrationBuilder.CreateTable(
                name: "Réclamation",
                columns: table => new
                {
                    IdReclam = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Objet = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Réclamation", x => x.IdReclam);
                });

            migrationBuilder.CreateTable(
                name: "Reponse",
                columns: table => new
                {
                    IdReponse = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Flag = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reponse", x => x.IdReponse);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Type_Epreuve",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Epreuve", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prénom = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "ReponseQuest",
                columns: table => new
                {
                    QuestionIdQuest = table.Column<int>(type: "integer", nullable: false),
                    ReponseIdReponse = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseQuest", x => new { x.QuestionIdQuest, x.ReponseIdReponse });
                    table.ForeignKey(
                        name: "FK_ReponseQuest_Question_QuestionIdQuest",
                        column: x => x.QuestionIdQuest,
                        principalTable: "Question",
                        principalColumn: "IdQuest",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReponseQuest_Reponse_ReponseIdReponse",
                        column: x => x.ReponseIdReponse,
                        principalTable: "Reponse",
                        principalColumn: "IdReponse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Epreuve",
                columns: table => new
                {
                    IdEpreuve = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomEpreuve = table.Column<string>(type: "text", nullable: true),
                    Duree = table.Column<int>(type: "integer", nullable: false),
                    SommePoints = table.Column<int>(type: "integer", nullable: false),
                    Complexité = table.Column<string>(type: "text", nullable: true),
                    Type_EpreuvesIdType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epreuve", x => x.IdEpreuve);
                    table.ForeignKey(
                        name: "FK_Epreuve_Type_Epreuve_Type_EpreuvesIdType",
                        column: x => x.Type_EpreuvesIdType,
                        principalTable: "Type_Epreuve",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    IdInv = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_inv = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    UserIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.IdInv);
                    table.ForeignKey(
                        name: "FK_Invitation_Users_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesIdRole = table.Column<int>(type: "integer", nullable: false),
                    UsersIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesIdRole, x.UsersIdUser });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesIdRole",
                        column: x => x.RolesIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReclam",
                columns: table => new
                {
                    RéclamationIdReclam = table.Column<int>(type: "integer", nullable: false),
                    UsersIdUser = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReclam", x => new { x.RéclamationIdReclam, x.UsersIdUser });
                    table.ForeignKey(
                        name: "FK_UserReclam_Réclamation_RéclamationIdReclam",
                        column: x => x.RéclamationIdReclam,
                        principalTable: "Réclamation",
                        principalColumn: "IdReclam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReclam_Users_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REpreuveQuest",
                columns: table => new
                {
                    EpreuveIdEpreuve = table.Column<int>(type: "integer", nullable: false),
                    QuestionIdQuest = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REpreuveQuest", x => new { x.EpreuveIdEpreuve, x.QuestionIdQuest });
                    table.ForeignKey(
                        name: "FK_REpreuveQuest_Epreuve_EpreuveIdEpreuve",
                        column: x => x.EpreuveIdEpreuve,
                        principalTable: "Epreuve",
                        principalColumn: "IdEpreuve",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REpreuveQuest_Question_QuestionIdQuest",
                        column: x => x.QuestionIdQuest,
                        principalTable: "Question",
                        principalColumn: "IdQuest",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEpreuve",
                columns: table => new
                {
                    IdEpreuve = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Resultat = table.Column<string>(type: "text", nullable: true),
                    date_lim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEpreuve", x => new { x.IdUser, x.IdEpreuve });
                    table.ForeignKey(
                        name: "FK_UserEpreuve_Epreuve_IdEpreuve",
                        column: x => x.IdEpreuve,
                        principalTable: "Epreuve",
                        principalColumn: "IdEpreuve",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEpreuve_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Epreuve_Type_EpreuvesIdType",
                table: "Epreuve",
                column: "Type_EpreuvesIdType");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_UserIdUser",
                table: "Invitation",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ReponseQuest_ReponseIdReponse",
                table: "ReponseQuest",
                column: "ReponseIdReponse");

            migrationBuilder.CreateIndex(
                name: "IX_REpreuveQuest_QuestionIdQuest",
                table: "REpreuveQuest",
                column: "QuestionIdQuest");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersIdUser",
                table: "RoleUser",
                column: "UsersIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserEpreuve_IdEpreuve",
                table: "UserEpreuve",
                column: "IdEpreuve");

            migrationBuilder.CreateIndex(
                name: "IX_UserReclam_UsersIdUser",
                table: "UserReclam",
                column: "UsersIdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "ReponseQuest");

            migrationBuilder.DropTable(
                name: "REpreuveQuest");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "UserEpreuve");

            migrationBuilder.DropTable(
                name: "UserReclam");

            migrationBuilder.DropTable(
                name: "Reponse");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Epreuve");

            migrationBuilder.DropTable(
                name: "Réclamation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Type_Epreuve");
        }
    }
}
