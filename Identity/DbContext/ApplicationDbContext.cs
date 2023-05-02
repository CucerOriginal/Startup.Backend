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
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b02f7", UserName = "Ваня", Email = "vanya@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0111", UserName = "Иван", Email = "ivan@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0222", UserName = "Катя", Email = "katya@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0333", UserName = "Петр", Email = "peter@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0444", UserName = "Анна", Email = "anna@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0555", UserName = "Мария", Email = "maria@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0666", UserName = "Максим", Email = "max@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0777", UserName = "Дмитрий", Email = "dima@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0888", UserName = "Ольга", Email = "olga@mail.ru", PasswordHash = "EtoHash" },
				 new ApplicationUser { Id = "88aec81d-b5b0-45f3-8721-8d41560b0999", UserName = "Сергей", Email = "sergey@mail.ru", PasswordHash = "EtoHash" }
			 );

			builder.Entity<Gender>().HasData(
				new Gender { Id = "18aec81d-b5b0-45f3-1721-8d41560b02f1", GenderName = "Мужской" },
				new Gender { Id = "28aec81d-b5b0-45f3-1721-8d41560b02f1", GenderName = "Женский" }
			);

			builder.Entity<Resume>().HasData(
				new Resume
				{
					Id = "88aec81d-b5b0-45f3-1721-8d41560b02f1",
					Title = "Специалист по ИТ",
					Surname = "Дементьев",
					Name = "Ваня",
					Middlename = "Петрович",
					Email = "dementiev12@mail.ru",
					GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
					PhoneNumber = "+79242453413",
					WorkExperience = "20.11.2019 - 20.09.2022 Завод имени Ленина",
					Salary = 45000,
					Education = "Университет управления 'ТИСБИ', Казань, ИТ, Программная инженерия",
					Description = "С 2020 года самостоятельно изучаю C#",
					ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222",
					CategoryId = 1
				},
				new Resume
				{
					Id = "88aec81d-b5b0-45f3-1721-8d41560b02f2",
					Title = "Специалист по ИТ",
					Surname = "Иванов",
					Name = "Иван",
					Middlename = "Сергеевич",
					Email = "ivan2@mail.ru",
					GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
					PhoneNumber = "+79123456789",
					WorkExperience = "01.02.2020 - 01.09.2022 ООО 'Рога и копыта'",
					Salary = 55000,
					Education = "Московский государственный технический университет им. Баумана, Москва, Информатика и вычислительная техника",
					Description = "Опыт работы с Java, C++ и Python",
					ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222",
					CategoryId = 1
				},
				new Resume
				{
					Id = "88aec81d-b5b0-45f3-1721-8d41560b02f3",
					Title = "Специалист по ИТ",
					Surname = "Петрова",
					Name = "Анна",
					Middlename = "Ивановна",
					Email = "anna3@mail.ru",
					GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
					PhoneNumber = "+79090909090",
					WorkExperience = "15.09.2020 - 10.03.2023 ООО 'Красный Октябрь'",
					Salary = 65000,
					Education = "Университет ИТМО, Санкт-Петербург, Информационные системы и технологии",
					Description = "Опыт работы в веб-разработке с HTML, CSS, JavaScript",
					ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0333",
					CategoryId = 1
				},
				new Resume
				{
					Id = "88aec81d-b5b0-45f3-1721-8d41560b02f4",
					Title = "Специалист по ИТ",
					Surname = "Сидоров",
					Name = "Сергей",
					Middlename = "Петрович",
					Email = "sergey4@mail.ru",
					GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
					PhoneNumber = "+79001234567",
					WorkExperience = "01.10.2019 - 01.09.2022 ООО 'Рога и копыта'",
					Salary = 50000,
					Education = "Московский государственный университет им. М.В. Ломоносова, Москва, Факультет прикладной математики и информатики",
					Description = "Опыт работы с Python и MATLAB",
					ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111",
					CategoryId = 1
				},
				new Resume
				{
					Id = "88aec81d-b5b0-45f3-1721-8d41560b02f5",
					Title = "Специалист по фронту",
					Surname = "Кузнецова",
					Name = "Мария",
					Middlename = "Сергеевна",
					Email = "marya5@mail.ru",
					GenderId = "18aec81d-b5b0-45f3-1721-8d41560b02f1",
					PhoneNumber = "+79123456789",
					WorkExperience = "01.09.2020 - 01.03.2023 ООО 'Рога и копыта'",
					Salary = 60000,
					Education = "Университет ИТМО, Санкт-Петербург, Информатика и вычислительная техника",
					Description = "Опыт работы в разработке мобильных приложений на Java и Kotlin",
					ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222",
					CategoryId = 6
				}
			);

			builder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "ИТ", Description = "ИТ" },
				new Category { Id = 2, Name = "Транспорт", Description = "Транспорт" },
				new Category { Id = 3, Name = "Закупки", Description = "Закупки" },
				new Category { Id = 4, Name = "Финансы", Description = "Финансы" },
				new Category { Id = 5, Name = "Медицина", Description = "Медицина" },
				new Category { Id = 6, Name = "Рабочий персонал", Description = "Рабочий персонал" },
				new Category { Id = 7, Name = "Юристы", Description = "Юристы" },
				new Category { Id = 8, Name = "Искусство", Description = "Искусство" },
				new Category { Id = 9, Name = "Производство", Description = "Производство" }
				);

			builder.Entity<Post>().HasData(
				new Post { Id = 1, CompanyName = "РазрабыМы", Title = "Младший программист", Description = "Требуемый опыт работы: 1–3 года Полная занятость, полный день", Content = "Что от Вас требуется? Знание основ SQL, 1С (выбор, связи, вложенные запросы); Аналитический склад ума; Стремление к саморазвитию; Инициативность, желание искать новые инструменты и пути решения поставленных задач.", CategoryId = 1, Salary = 40000, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7" },
				new Post { Id = 2, CompanyName = "РазрабыМы", Title = "Программист С# (middle)", Description = "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график", Content = "Требования: - C# + .NET 4.7 с опытом разработки не менее 2 лет - ООП - уверенное владение. - Опыт разработки desktop приложений (Windows). - Многопоточные приложения - уверенное владение. - WPF - уверенное владение - знание MVVM, понимание принципов SOLID, DI Будет плюсом: WinForms, Unity, Prism", CategoryId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 100000 },
				new Post { Id = 3, CompanyName = "РазрабыМы", Title = "Разработчик C# (Middle)", Description = "Требуемый опыт работы: 1–3 года Полная занятость, удаленная работа", Content = "Требования: Уверенные знания C#; Знание ASP.NET Core; Знание SQL, опыт работы с MSSQL, PostgreSQL; Entity Framework Core; Понимание ООП; Знать и применять на практике шаблоны проектирования; Опыт разработки REST API; Опыт работы с GIT.", CategoryId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 160000 },
				new Post { Id = 4, CompanyName = "ТрансЛогистика", Title = "Водитель-экспедитор", Description = "Требуемый опыт работы: от 1 года Полная занятость, график 5/2", Content = "Требования: Опыт вождения от 1 года; Владение управлением грузовой техники; Знание Москвы и Московской области; Наличие водительских прав категории B и C; Опыт работы в экспедиции.", CategoryId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 50000 },
				new Post { Id = 5, CompanyName = "Здоровье", Title = "Врач-терапевт", Description = "Требуемый опыт работы: от 3 лет Полная занятость, график посменный", Content = "Требования: Опыт работы терапевтом от 3 лет; Знание современных методик диагностики и лечения заболеваний; Коммуникабельность, умение налаживать контакт с пациентами.", CategoryId = 5, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 150000 },
				new Post { Id = 6, CompanyName = "Юристы-Правозащитники", Title = "Юрист-консультант", Description = "Требуемый опыт работы: от 2 лет Полная занятость, график 5/2", Content = "Требования: Опыт работы юристом от 2 лет; Знание гражданского, трудового, налогового, корпоративного права; Опыт ведения переговоров; Уверенный пользователь ПК, знание офисных программ.", CategoryId = 7, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 100000 },
				new Post { Id = 7, CompanyName = "ООО 'Аврора'", Title = "Инженер-технолог", Description = "Требуемый опыт работы: от 3 лет Полная занятость, график 5/2", Content = "Требования: Опыт работы инженером-технологом от 3 лет; Знание технологий машиностроения; Навыки проектирования и внедрения технологических процессов; Знание нормативной документации по организации производства.", CategoryId = 9, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 120000 },
				new Post { Id = 8, CompanyName = "ТрансЛогистика", Title = "Водитель-экспедитор", Description = "Требуемый опыт работы: от 3 лет, Полная занятость, гибкий график", Content = "Требования: Категория В, С; Опыт экспедиторской работы не менее 3 лет; Знание города и области; Умение работать с документами; Ответственность, пунктуальность.", CategoryId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 50000 },
				new Post { Id = 9, CompanyName = "Здоровье", Title = "Врач-терапевт", Description = "Требуемый опыт работы: от 3 лет, Полная занятость, график 5/2", Content = "Требования: Высшее медицинское образование; Стаж работы от 3 лет; Владение методами диагностики и лечения заболеваний; Навыки взаимодействия с пациентами; Знание медицинской терминологии.", CategoryId = 5, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 80000 },
				new Post { Id = 10, CompanyName = "Юристы-Правозащитники", Title = "Юрист-консультант", Description = "Требуемый опыт работы: от 2 лет, Полная занятость, гибкий график", Content = "Требования: Высшее юридическое образование; Опыт работы не менее 2 лет; Знание трудового законодательства, налогового права; Уверенное владение гражданским и арбитражным законодательством; Опыт ведения дел в суде; Навыки составления правовых документов.", CategoryId = 7, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b02f7", Salary = 90000 }
				);

			builder.Entity<Comment>().HasData(
				new Comment { Id = 1, Content = "Норм тема", PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222", CreatedDate = DateTime.UtcNow },
				new Comment { Id = 2, Content = "Хорошее место для работы", PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", CreatedDate = DateTime.UtcNow },
				new Comment { Id = 3, Content = "Отличная команда, интересные проекты", PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222", CreatedDate = DateTime.UtcNow },
				new Comment { Id = 4, Content = "Организация современная, все на высшем уровне", PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", CreatedDate = DateTime.UtcNow },
				new Comment { Id = 5, Content = "Руководство компетентное, всегда можно рассчитывать на поддержку", PostId = 3, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", CreatedDate = DateTime.UtcNow }
				);

			builder.Entity<Rating>().HasData(
				new Rating { Id = "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b01f7", LikeStatus = true, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222" },
				new Rating { Id = "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b02f9", LikeStatus = false, PostId = 1, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111" },
				new Rating { Id = "88aec81d-b5b0-43f3-8721-8d21560b02a788aec81d-b5b0-45f3-0721-1241560b02f8", LikeStatus = true, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111" },
				new Rating { Id = "88aec81d-b5b0-43f3-8721-8d21560b02a988aec81d-b5b0-45f3-0721-1241560b02f7", LikeStatus = true, PostId = 2, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222" },
				new Rating { Id = "88aec81d-b5b0-43f3-8721-8d21560b02b088aec81d-b5b0-45f3-0721-1241560b02f7", LikeStatus = false, PostId = 3, ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111" }
				);

			builder.Entity<Feedback>().HasData(
				new Feedback { Id = "188aec81d-b5b0-45f3-8721-8d41560b0111", ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", PostId = 1 },
				new Feedback { Id = "188aec81d-b5b0-45f3-8721-8d41560b0222", ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222", PostId = 1 },
				new Feedback { Id = "288aec81d-b5b0-45f3-8721-8d41560b0111", ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", PostId = 2 },
				new Feedback { Id = "288aec81d-b5b0-45f3-8721-8d41560b0222", ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0222", PostId = 2 },
				new Feedback { Id = "388aec81d-b5b0-45f3-8721-8d41560b0111", ApplicationUserId = "88aec81d-b5b0-45f3-8721-8d41560b0111", PostId = 3 }
		   );
		}
        
    }
}
