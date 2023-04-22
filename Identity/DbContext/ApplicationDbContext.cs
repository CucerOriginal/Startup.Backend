using BlogSN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.ModelsBlogSN;
using Models.ModelsIdentity;
using Models.ModelsIdentity.IdentityAuth;

namespace Identity.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b02f7", UserName = "Vanya", Email = "1@mail.ru", PasswordHash = "EtoHash", ApplicantId = "88aec81d-b5b0-45f3-0721-1241560b01f7", Role = UserRole.Applicant },
                new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0111", UserName = "Ivan", Email = "321@mail.ru", PasswordHash = "EtoHash", EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", Role = UserRole.Employer }
            );

            builder.Entity<Applicant>().HasData(
                new Applicant { Id = "88aec81d-b5b0-45f3-0721-1241560b01f7" }
            );

            builder.Entity<Gender>().HasData(
                new Gender { Id = "18aec81d-b5b0-45f3-1721-8d41560b02f1", GenderName = "Мужской"},
                new Gender { Id = "28aec81d-b5b0-45f3-1721-8d41560b02f1", GenderName = "Женский"}
            );

            builder.Entity<Resume>().HasData(
                new Resume
                {
                    Id = "88aec81d-b5b0-45f3-1721-8d41560b02f1",
                    Surname = "Dementiev",
                    Name = "Vanya",
                    Middlename = "Petrovich",
                    Email = "1@mail.ru",
                    GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
                    PhoneNumber = "+79242453413",
                    WorkExperience = "20.11.2019 - 20.09.2022 Завод имени Ленина",
                    Salary = 45000,
                    Education = "Университет управления 'ТИСБИ', Казань, ИТ, Программная инженерия",
                    Description = "С 2020 года самостоятельно изучаю C#",
                    ApplicantId = "88aec81d-b5b0-45f3-0721-1241560b01f7"
                }
            );

            builder.Entity<Employer>().HasData(
                 new Employer { Id = "88aec81d-b5b0-43f3-8721-8d21560b02a7", CompanyName = "КГС", Description = "Интернет провайдер"}
            );

            builder.Entity<Category>().HasData(
                new Category{ Id = 1, Name = "ИТ", Description = "ИТ" },
                new Category {Id = 2, Name = "Транспорт", Description = "Транспорт" },
                new Category { Id = 3, Name = "Закупки", Description = "Закупки" },
                new Category {Id = 4, Name = "Финансы", Description = "Финансы" },
                new Category {Id =5, Name = "Медицина", Description = "Медицина" },
                new Category {Id = 6, Name = "Рабочий персонал", Description = "Рабочий персонал"},
                new Category {Id = 7, Name = "Юристы", Description = "Юристы" }
                );

            builder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Младший программист", Description = "Требуемый опыт работы: 1–3 года Полная занятость, полный день", Content = "Что от Вас требуется? Знание основ SQL, 1С (выбор, связи, вложенные запросы); Аналитический склад ума; Стремление к саморазвитию; Инициативность, желание искать новые инструменты и пути решения поставленных задач.", CategoryId = 1 , EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", Salary = 40000 },
                new Post { Id = 2, Title = "Программист С# (middle)", Description = "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график", Content = "Требования: - C# + .NET 4.7 с опытом разработки не менее 2 лет - ООП - уверенное владение. - Опыт разработки desktop приложений (Windows). - Многопоточные приложения - уверенное владение. - WPF - уверенное владение - знание MVVM, понимание принципов SOLID, DI Будет плюсом: WinForms, Unity, Prism", CategoryId = 1, EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", Salary = 100000 },
                new Post { Id = 3, Title = "Разработчик C# (Middle)", Description = "Требуемый опыт работы: 1–3 года Полная занятость, удаленная работа", Content = "Требования: Уверенные знания C#; Знание ASP.NET Core; Знание SQL, опыт работы с MSSQL, PostgreSQL; Entity Framework Core; Понимание ООП; Знать и применять на практике шаблоны проектирования; Опыт разработки REST API; Опыт работы с GIT.", CategoryId = 1, EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", Salary = 160000 }
                );

            builder.Entity<Comment>().HasData(
                new Comment { Id = 1, Content = "Норм тема", EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", ApplicantId = "88aec81d-b5b0-45f3-0721-1241560b01f7", CreatedDate = DateTime.UtcNow }
                );

            builder.Entity<Rating>().HasData(
                new Rating { Id = "188aec81d-b5b0-45f3-8721-8d41560b02f7", LikeStatus = true, EmployerId = "88aec81d-b5b0-43f3-8721-8d21560b02a7", ApplicantId = "88aec81d-b5b0-45f3-0721-1241560b01f7" }
                );

            builder.Entity<Feedback>().HasData(
               new Feedback { Id = "188aec81d-b5b0-45f3-0721-1241560b01f7", ApplicantId = "88aec81d-b5b0-45f3-0721-1241560b01f7", PostId = 1 }
           );
        }
        
    }
}
