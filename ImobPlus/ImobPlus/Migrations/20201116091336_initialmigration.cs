using Microsoft.EntityFrameworkCore.Migrations;

namespace ImobPlus.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conseillers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPrenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Apropos = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DIsponible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conseillers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Construires",
                columns: table => new
                {
                    MyProperty = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameConst = table.Column<string>(nullable: true),
                    TypeConst = table.Column<string>(nullable: true),
                    EmailConst = table.Column<string>(nullable: true),
                    MessageConst = table.Column<string>(nullable: true),
                    LieuConst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Construires", x => x.MyProperty);
                });

            migrationBuilder.CreateTable(
                name: "ContactPros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Bailleur = table.Column<string>(nullable: true),
                    EmailCont = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id_Contact = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPrenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Precoccupation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id_Contact);
                });

            migrationBuilder.CreateTable(
                name: "Demenagements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDem = table.Column<string>(nullable: true),
                    EmailDem = table.Column<string>(nullable: true),
                    LieuDepartDem = table.Column<string>(nullable: true),
                    DestinaDem = table.Column<string>(nullable: true),
                    MessagDem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demenagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investirs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameInvest = table.Column<string>(nullable: true),
                    EmailInvest = table.Column<string>(nullable: true),
                    MessageInvest = table.Column<string>(nullable: true),
                    TypeInvest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investirs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liconseils",
                columns: table => new
                {
                    Id_Liconseil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NomPrenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liconseils", x => x.Id_Liconseil);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id_Post = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    Mini_Describe = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Img_Post = table.Column<string>(nullable: true),
                    Name_Bailleur = table.Column<string>(nullable: true),
                    Email_Bailleur = table.Column<string>(nullable: true),
                    Contact_Bailleur = table.Column<string>(nullable: true),
                    nbre_Chambres = table.Column<int>(nullable: false),
                    nbre_Douches = table.Column<int>(nullable: false),
                    nbre_Cuisines = table.Column<int>(nullable: false),
                    Choix = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id_Post);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conseillers");

            migrationBuilder.DropTable(
                name: "Construires");

            migrationBuilder.DropTable(
                name: "ContactPros");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Demenagements");

            migrationBuilder.DropTable(
                name: "Investirs");

            migrationBuilder.DropTable(
                name: "Liconseils");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
