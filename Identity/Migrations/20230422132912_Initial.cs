using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Requisite = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CommentsCount = table.Column<int>(type: "integer", nullable: false),
                    PostsCount = table.Column<int>(type: "integer", nullable: false),
                    RatingCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    GenderName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<string>(type: "text", nullable: true),
                    EmployerId = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    EmployerId = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployerId = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LikeStatus = table.Column<bool>(type: "boolean", nullable: false),
                    EmployerId = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Middlename = table.Column<string>(type: "text", nullable: true),
                    GenderId = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    WorkExperience = table.Column<string>(type: "text", nullable: true),
                    Education = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ApplicantId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resume_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ApplicantId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedback_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applicant",
                columns: new[] { "Id", "Requisite" },
                values: new object[] { "88aec81d-b5b0-45f3-0721-1241560b01f7", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "ИТ", "ИТ" },
                    { 2, "Транспорт", "Транспорт" },
                    { 3, "Закупки", "Закупки" },
                    { 4, "Финансы", "Финансы" },
                    { 5, "Медицина", "Медицина" },
                    { 6, "Рабочий персонал", "Рабочий персонал" },
                    { 7, "Юристы", "Юристы" }
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "Id", "CommentsCount", "CompanyName", "Description", "PostsCount", "RatingCount" },
                values: new object[] { "88aec81d-b5b0-43f3-8721-8d21560b02a7", 0, "КГС", "Интернет провайдер", 0, 0 });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Мужской" },
                    { "28aec81d-b5b0-45f3-1721-8d41560b02f1", "Женский" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicantId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployerId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "88aec81d-b5b0-45f3-8721-8d41560b0111", 0, null, "d9d72123-602c-4e98-a95c-0a98c7cd4105", "321@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b02a7", false, null, null, null, "EtoHash", null, false, "Employer", "f089199f-92b7-4db2-91d0-4670ff382f81", false, "Ivan" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b02f7", 0, "88aec81d-b5b0-45f3-0721-1241560b01f7", "f6d1b285-fabe-4f5d-8e1b-b0793fee780a", "1@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "d7c80b33-8f3f-4dd5-8cc3-1cd0ab2fbad0", false, "Vanya" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicantId", "Content", "CreatedDate", "EmployerId" },
                values: new object[] { 1, "88aec81d-b5b0-45f3-0721-1241560b01f7", "Норм тема", new DateTime(2023, 4, 22, 13, 29, 12, 533, DateTimeKind.Utc).AddTicks(4805), "88aec81d-b5b0-43f3-8721-8d21560b02a7" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "DateCreated", "Description", "EmployerId", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Что от Вас требуется? Знание основ SQL, 1С (выбор, связи, вложенные запросы); Аналитический склад ума; Стремление к саморазвитию; Инициативность, желание искать новые инструменты и пути решения поставленных задач.", new DateTime(2023, 4, 22, 13, 29, 12, 533, DateTimeKind.Utc).AddTicks(4779), "Требуемый опыт работы: 1–3 года Полная занятость, полный день", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 40000.0, "Младший программист" },
                    { 2, 1, "Требования: - C# + .NET 4.7 с опытом разработки не менее 2 лет - ООП - уверенное владение. - Опыт разработки desktop приложений (Windows). - Многопоточные приложения - уверенное владение. - WPF - уверенное владение - знание MVVM, понимание принципов SOLID, DI Будет плюсом: WinForms, Unity, Prism", new DateTime(2023, 4, 22, 13, 29, 12, 533, DateTimeKind.Utc).AddTicks(4783), "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 100000.0, "Программист С# (middle)" },
                    { 3, 1, "Требования: Уверенные знания C#; Знание ASP.NET Core; Знание SQL, опыт работы с MSSQL, PostgreSQL; Entity Framework Core; Понимание ООП; Знать и применять на практике шаблоны проектирования; Опыт разработки REST API; Опыт работы с GIT.", new DateTime(2023, 4, 22, 13, 29, 12, 533, DateTimeKind.Utc).AddTicks(4784), "Требуемый опыт работы: 1–3 года Полная занятость, удаленная работа", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 160000.0, "Разработчик C# (Middle)" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "ApplicantId", "EmployerId", "LikeStatus" },
                values: new object[] { "188aec81d-b5b0-45f3-8721-8d41560b02f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-43f3-8721-8d21560b02a7", true });

            migrationBuilder.InsertData(
                table: "Resume",
                columns: new[] { "Id", "ApplicantId", "Description", "Education", "Email", "GenderId", "Middlename", "Name", "PhoneNumber", "Salary", "Surname", "WorkExperience" },
                values: new object[] { "88aec81d-b5b0-45f3-1721-8d41560b02f1", "88aec81d-b5b0-45f3-0721-1241560b01f7", "С 2020 года самостоятельно изучаю C#", "Университет управления 'ТИСБИ', Казань, ИТ, Программная инженерия", "1@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Petrovich", "Vanya", "+79242453413", 45000.0, "Dementiev", "20.11.2019 - 20.09.2022 Завод имени Ленина" });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "ApplicantId", "PostId" },
                values: new object[] { "188aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicantId",
                table: "AspNetUsers",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmployerId",
                table: "AspNetUsers",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicantId",
                table: "Comment",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EmployerId",
                table: "Comment",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ApplicantId",
                table: "Feedback",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PostId",
                table: "Feedback",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CategoryId",
                table: "Post",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_EmployerId",
                table: "Post",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ApplicantId",
                table: "Rating",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_EmployerId",
                table: "Rating",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_ApplicantId",
                table: "Resume",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_GenderId",
                table: "Resume",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}
