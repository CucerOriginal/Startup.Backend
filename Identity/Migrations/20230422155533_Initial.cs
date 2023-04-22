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
                values: new object[,]
                {
                    { "88aec81d-b5b0-45f3-0721-1241560b01f7", null },
                    { "88aec81d-b5b0-45f3-0721-1241560b02f8", null },
                    { "88aec81d-b5b0-45f3-0721-1241560b02f9", null },
                    { "88aec81d-b5b0-45f3-0721-1241560b02fa", null },
                    { "88aec81d-b5b0-45f3-0721-1241560b02fb", null }
                });

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
                    { 7, "Юристы", "Юристы" },
                    { 8, "Искусство", "Искусство" },
                    { 9, "Производство", "Производство" }
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "Id", "CommentsCount", "CompanyName", "Description", "PostsCount", "RatingCount" },
                values: new object[,]
                {
                    { "88aec81d-b5b0-43f3-8721-8d21560b0288", 0, "ТрансЛогистика", "Транспортная компания", 0, 0 },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a7", 0, "РазрабыМы", "Разработка платформ", 0, 0 },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a8", 0, "ООО 'Аврора'", "Производство строительных материалов", 0, 0 },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a9", 0, "Здоровье", "Медицинский центр", 0, 0 },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02b0", 0, "Юристы-Правозащитники", "Юридическая компания", 0, 0 }
                });

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
                    { "88aec81d-b5b0-45f3-8721-8d41560b0111", 0, null, "e7cb5ee3-5a1e-4dfd-b670-9ba46bcd9f6a", "ivan@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b02a7", false, null, null, null, "EtoHash", null, false, "Employer", "f7a8197b-6bdf-441d-9412-816b8c8cf1ca", false, "Иван" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0222", 0, "88aec81d-b5b0-45f3-0721-1241560b02f8", "582525a3-2785-4d25-8128-11b31e18c522", "katya@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "a942ebf2-8da6-4464-9de0-9195aabd26c7", false, "Катя" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b02f7", 0, "88aec81d-b5b0-45f3-0721-1241560b01f7", "f5215daa-589b-415f-932f-a8851355c22a", "vanya@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "326c53fe-a49e-4712-b76c-c7cd95c85b2a", false, "Ваня" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0333", 0, null, "5892d094-fc8f-4893-830d-ef767db94d18", "peter@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b02a8", false, null, null, null, "EtoHash", null, false, "Employer", "4b5c5a77-a4c7-4fae-ae0c-d69ba7b4eea7", false, "Петр" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0444", 0, "88aec81d-b5b0-45f3-0721-1241560b02f9", "ffe9082e-ea1f-4ef4-9bfc-41132d18cb9e", "anna@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "68da4367-f008-4c93-91e0-316ec512ffd8", false, "Анна" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0555", 0, null, "1cfcb260-a664-4e78-be88-2bceac177042", "maria@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b0288", false, null, null, null, "EtoHash", null, false, "Employer", "b3cd6bee-a352-4059-b8d2-3fb040f92384", false, "Мария" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0666", 0, "88aec81d-b5b0-45f3-0721-1241560b02fa", "c655ad97-9897-4d13-a0a8-bfbba9ddfcd7", "max@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "091d4eab-199c-4a73-bb4a-f061a00cc6ea", false, "Максим" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0777", 0, null, "fafcb544-97ea-4a71-8841-592dcaf6b780", "dima@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b02a9", false, null, null, null, "EtoHash", null, false, "Employer", "10934c78-6cf7-4f67-b768-ff3a32e1aebd", false, "Дмитрий" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0888", 0, "88aec81d-b5b0-45f3-0721-1241560b02fb", "fe1e4e8a-d312-42ad-9075-8299f5fc0085", "olga@mail.ru", false, null, false, null, null, null, "EtoHash", null, false, "Applicant", "5032af0e-ecd7-4ef5-9ba4-3745de7577dc", false, "Ольга" },
                    { "88aec81d-b5b0-45f3-8721-8d41560b0999", 0, null, "e4dd43f0-5090-44df-aef1-6d906af01eac", "sergey@mail.ru", false, "88aec81d-b5b0-43f3-8721-8d21560b02b0", false, null, null, null, "EtoHash", null, false, "Employer", "87d94a53-3887-43e6-b245-10a43f5cceed", false, "Сергей" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "ApplicantId", "Content", "CreatedDate", "EmployerId" },
                values: new object[,]
                {
                    { 1, "88aec81d-b5b0-45f3-0721-1241560b01f7", "Норм тема", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5656), "88aec81d-b5b0-43f3-8721-8d21560b02a7" },
                    { 2, "88aec81d-b5b0-45f3-0721-1241560b01f7", "Хорошее место для работы", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5657), "88aec81d-b5b0-43f3-8721-8d21560b02a8" },
                    { 3, "88aec81d-b5b0-45f3-0721-1241560b01f7", "Отличная команда, интересные проекты", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5658), "88aec81d-b5b0-43f3-8721-8d21560b0288" },
                    { 4, "88aec81d-b5b0-45f3-0721-1241560b02fa", "Организация современная, все на высшем уровне", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5660), "88aec81d-b5b0-43f3-8721-8d21560b02a7" },
                    { 5, "88aec81d-b5b0-45f3-0721-1241560b02f9", "Руководство компетентное, всегда можно рассчитывать на поддержку", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5661), "88aec81d-b5b0-43f3-8721-8d21560b0288" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "CategoryId", "Content", "DateCreated", "Description", "EmployerId", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Что от Вас требуется? Знание основ SQL, 1С (выбор, связи, вложенные запросы); Аналитический склад ума; Стремление к саморазвитию; Инициативность, желание искать новые инструменты и пути решения поставленных задач.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5623), "Требуемый опыт работы: 1–3 года Полная занятость, полный день", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 40000.0, "Младший программист" },
                    { 2, 1, "Требования: - C# + .NET 4.7 с опытом разработки не менее 2 лет - ООП - уверенное владение. - Опыт разработки desktop приложений (Windows). - Многопоточные приложения - уверенное владение. - WPF - уверенное владение - знание MVVM, понимание принципов SOLID, DI Будет плюсом: WinForms, Unity, Prism", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5626), "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 100000.0, "Программист С# (middle)" },
                    { 3, 1, "Требования: Уверенные знания C#; Знание ASP.NET Core; Знание SQL, опыт работы с MSSQL, PostgreSQL; Entity Framework Core; Понимание ООП; Знать и применять на практике шаблоны проектирования; Опыт разработки REST API; Опыт работы с GIT.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5627), "Требуемый опыт работы: 1–3 года Полная занятость, удаленная работа", "88aec81d-b5b0-43f3-8721-8d21560b02a7", 160000.0, "Разработчик C# (Middle)" },
                    { 4, 2, "Требования: Опыт вождения от 1 года; Владение управлением грузовой техники; Знание Москвы и Московской области; Наличие водительских прав категории B и C; Опыт работы в экспедиции.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5629), "Требуемый опыт работы: от 1 года Полная занятость, график 5/2", "88aec81d-b5b0-43f3-8721-8d21560b0288", 50000.0, "Водитель-экспедитор" },
                    { 5, 5, "Требования: Опыт работы терапевтом от 3 лет; Знание современных методик диагностики и лечения заболеваний; Коммуникабельность, умение налаживать контакт с пациентами.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5630), "Требуемый опыт работы: от 3 лет Полная занятость, график посменный", "88aec81d-b5b0-43f3-8721-8d21560b02a9", 150000.0, "Врач-терапевт" },
                    { 6, 7, "Требования: Опыт работы юристом от 2 лет; Знание гражданского, трудового, налогового, корпоративного права; Опыт ведения переговоров; Уверенный пользователь ПК, знание офисных программ.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5631), "Требуемый опыт работы: от 2 лет Полная занятость, график 5/2", "88aec81d-b5b0-43f3-8721-8d21560b02b0", 100000.0, "Юрист-консультант" },
                    { 7, 9, "Требования: Опыт работы инженером-технологом от 3 лет; Знание технологий машиностроения; Навыки проектирования и внедрения технологических процессов; Знание нормативной документации по организации производства.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5632), "Требуемый опыт работы: от 3 лет Полная занятость, график 5/2", "88aec81d-b5b0-43f3-8721-8d21560b02a8", 120000.0, "Инженер-технолог" },
                    { 8, 2, "Требования: Категория В, С; Опыт экспедиторской работы не менее 3 лет; Знание города и области; Умение работать с документами; Ответственность, пунктуальность.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5633), "Требуемый опыт работы: от 3 лет, Полная занятость, гибкий график", "88aec81d-b5b0-43f3-8721-8d21560b0288", 50000.0, "Водитель-экспедитор" },
                    { 9, 5, "Требования: Высшее медицинское образование; Стаж работы от 3 лет; Владение методами диагностики и лечения заболеваний; Навыки взаимодействия с пациентами; Знание медицинской терминологии.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5635), "Требуемый опыт работы: от 3 лет, Полная занятость, график 5/2", "88aec81d-b5b0-43f3-8721-8d21560b02a9", 80000.0, "Врач-терапевт" },
                    { 10, 7, "Требования: Высшее юридическое образование; Опыт работы не менее 2 лет; Знание трудового законодательства, налогового права; Уверенное владение гражданским и арбитражным законодательством; Опыт ведения дел в суде; Навыки составления правовых документов.", new DateTime(2023, 4, 22, 15, 55, 33, 162, DateTimeKind.Utc).AddTicks(5636), "Требуемый опыт работы: от 2 лет, Полная занятость, гибкий график", "88aec81d-b5b0-43f3-8721-8d21560b02b0", 90000.0, "Юрист-консультант" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "ApplicantId", "EmployerId", "LikeStatus" },
                values: new object[,]
                {
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-43f3-8721-8d21560b02a7", true },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b02f8", "88aec81d-b5b0-45f3-0721-1241560b02f9", "88aec81d-b5b0-43f3-8721-8d21560b02a7", true },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b02f9", "88aec81d-b5b0-45f3-0721-1241560b02f8", "88aec81d-b5b0-43f3-8721-8d21560b02a7", false },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02a988aec81d-b5b0-45f3-0721-1241560b02f7", "88aec81d-b5b0-45f3-0721-1241560b02f9", "88aec81d-b5b0-43f3-8721-8d21560b02a9", true },
                    { "88aec81d-b5b0-43f3-8721-8d21560b02b088aec81d-b5b0-45f3-0721-1241560b02f7", "88aec81d-b5b0-45f3-0721-1241560b02f9", "88aec81d-b5b0-43f3-8721-8d21560b02b0", false }
                });

            migrationBuilder.InsertData(
                table: "Resume",
                columns: new[] { "Id", "ApplicantId", "Description", "Education", "Email", "GenderId", "Middlename", "Name", "PhoneNumber", "Salary", "Surname", "WorkExperience" },
                values: new object[,]
                {
                    { "88aec81d-b5b0-45f3-1721-8d41560b02f1", "88aec81d-b5b0-45f3-0721-1241560b01f7", "С 2020 года самостоятельно изучаю C#", "Университет управления 'ТИСБИ', Казань, ИТ, Программная инженерия", "dementiev12@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Петрович", "Ваня", "+79242453413", 45000.0, "Дементьев", "20.11.2019 - 20.09.2022 Завод имени Ленина" },
                    { "88aec81d-b5b0-45f3-1721-8d41560b02f2", "88aec81d-b5b0-45f3-0721-1241560b02f8", "Опыт работы с Java, C++ и Python", "Московский государственный технический университет им. Баумана, Москва, Информатика и вычислительная техника", "ivan2@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Сергеевич", "Иван", "+79123456789", 55000.0, "Иванов", "01.02.2020 - 01.09.2022 ООО 'Рога и копыта'" },
                    { "88aec81d-b5b0-45f3-1721-8d41560b02f3", "88aec81d-b5b0-45f3-0721-1241560b02f9", "Опыт работы в веб-разработке с HTML, CSS, JavaScript", "Университет ИТМО, Санкт-Петербург, Информационные системы и технологии", "anna3@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Ивановна", "Анна", "+79090909090", 65000.0, "Петрова", "15.09.2020 - 10.03.2023 ООО 'Красный Октябрь'" },
                    { "88aec81d-b5b0-45f3-1721-8d41560b02f4", "88aec81d-b5b0-45f3-0721-1241560b02fa", "Опыт работы с Python и MATLAB", "Московский государственный университет им. М.В. Ломоносова, Москва, Факультет прикладной математики и информатики", "sergey4@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Петрович", "Сергей", "+79001234567", 50000.0, "Сидоров", "01.10.2019 - 01.09.2022 ООО 'Рога и копыта'" },
                    { "88aec81d-b5b0-45f3-1721-8d41560b02f5", "88aec81d-b5b0-45f3-0721-1241560b02fb", "Опыт работы в разработке мобильных приложений на Java и Kotlin", "Университет ИТМО, Санкт-Петербург, Информатика и вычислительная техника", "marya5@mail.ru", "18aec81d-b5b0-45f3-1721-8d41560b02f1", "Сергеевна", "Мария", "+79123456789", 60000.0, "Кузнецова", "01.09.2020 - 01.03.2023 ООО 'Рога и копыта'" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "ApplicantId", "PostId" },
                values: new object[,]
                {
                    { "188aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", 1 },
                    { "188aec81d-b5b0-45f3-0721-1241560b02f8", "88aec81d-b5b0-45f3-0721-1241560b02f8", 1 },
                    { "288aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", 2 },
                    { "388aec81d-b5b0-45f3-0721-1241560b01f7", "88aec81d-b5b0-45f3-0721-1241560b01f7", 3 },
                    { "488aec81d-b5b0-45f3-0721-1241560b02f9", "88aec81d-b5b0-45f3-0721-1241560b02f9", 4 }
                });

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
