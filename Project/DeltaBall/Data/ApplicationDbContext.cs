using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeltaBall.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //Таблицы для базы
        public DbSet<Client> Clients { get; set; }
        public DbSet<GameScenario> GameScenarios { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<ScheduleGame> ScheduleGames { get; set; }
        public DbSet<ShootRange> ShootRanges { get; set; }
        public DbSet<UserExpChange> UserExpChanges { get; set; }
        public DbSet<UserExpChangeMode> UserExpChangeModes { get; set; }

        //Вносим первоначальные данные для базы
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Rank>().HasData(
                new Rank
                {
                    Id = 1,
                    Name = "Бронза",
                    Discount = 1,
                    MinExp = 0,
                    MaxExp = 100,
                    ImagePath = "~/Images/Ranks/bronze.png",
                }
            );
            #region Добавление ролей пользователей
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "0531adfe-8fad-4e95-8d59-0b2294b982fc",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "514087fb-c72f-4712-b1e1-a3128e44e478",
                    Name = "Client",
                    NormalizedName = "CLIENT"
                }
            );
            #endregion

            #region Добавление администратора
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "41dd2d65-6650-4cce-b3fd-dead95a3ee7a",
                    Email = "ivanov_delta@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "IVANOV_DELTA@GMAIL.COM",
                    UserName = "Иванов Иван Иванович",
                    NormalizedUserName = "ИВАНОВ ИВАН ИВАНОВИЧ",
                    PhoneNumber = "8(123)456-78-90",
                    PhoneNumberConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "1van0v_d1l4a")
                }
            );
            builder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("ce8681a1-a903-42b2-b181-df7502bf9dfd"),
                    FullName = "Новоселов Святослав Дмитриевич",
                    Email = "slavanovosyolov@gmail.com",
                    PhoneNumber = "8(123)456-78-91",
                    Experience = 0,
                    RankId = 1
                }
            );
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "ce301bc6-b3f6-4ff7-b425-bd4777a1e9ac",
                    Email = "slavanovosyolov@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "SLAVANOVOSYOLOV@GMAIL.COM",
                    UserName = "Новоселов Святослав Дмитриевич",
                    NormalizedUserName = "НОВОСЕЛОВ СВЯТОСЛАВ ДМИТРИЕВИЧ",
                    PhoneNumber = "8(123)456-78-91",
                    PhoneNumberConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "sla39457195")
                }
            );
            #endregion

        }
    }
}