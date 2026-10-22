using ASP_HW4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW4.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<QuestRoom> QuestRooms { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<FearLevel> FearLevels { get; set; }
        public DbSet<PlayersNumber> PlayersNumbers { get; set; }

        public AppDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = 4,
                Numeric = 4,
                Title = "Hell"
            });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = 3,
                Numeric = 3,
                Title = "High"
            });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = 2,
                Numeric = 2,
                Title = "Medium"
            });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty
            {
                Id = 1,
                Numeric = 1,
                Title = "Easy"
            });
            modelBuilder.Entity<FearLevel>().HasData(new FearLevel {
                Id = 1,
                Numeric = 1,
                Title = "Low"
            });
            modelBuilder.Entity<FearLevel>().HasData(new FearLevel
            {
                Id = 2,
                Numeric = 2,
                Title = "Medium"
            });
            modelBuilder.Entity<FearLevel>().HasData(new FearLevel
            {
                Id = 3,
                Numeric =3,
                Title = "High"
            });
            modelBuilder.Entity<FearLevel>().HasData(new FearLevel
            {
                Id = 4,
                Numeric = 4,
                Title = "Hell"
            });
            modelBuilder.Entity<PlayersNumber>().HasData(new PlayersNumber
            {
                Id=1,
                Number = 2
            });
            modelBuilder.Entity<PlayersNumber>().HasData(new PlayersNumber
            {
                Id = 2,
                Number = 3
            });
            modelBuilder.Entity<PlayersNumber>().HasData(new PlayersNumber
            {
                Id = 3,
                Number = 4
            });
            modelBuilder.Entity<PlayersNumber>().HasData(new PlayersNumber
            {
                Id = 4,
                Number = 5
            });
            modelBuilder.Entity<PlayersNumber>().HasData(new PlayersNumber
            {
                Id = 5,
                Number = 6
            });
            modelBuilder.Entity<QuestRoom>().HasData(new QuestRoom
            {
                Id = 1,
                Title = "QstRm1",
                Quest = "Lorem Ipsum",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. " +
                "Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, " +
                "a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.",
                FearLevelId = 1,
                DifficultyId = 2,
                PlayersNumberId = 1
            });
            modelBuilder.Entity<QuestRoom>().HasData(new QuestRoom
            {
                Id = 2,
                Title = "QstRm2",
                Quest = "Lorem Ipsum",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
               "Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. " +
               "Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, " +
               "a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.",
                FearLevelId = 3,
                DifficultyId = 4,
                PlayersNumberId = 3
            });
            modelBuilder.Entity<QuestRoom>().HasData(new QuestRoom
            {
                Id = 3,
                Title = "QstRm3",
                Quest = "Lorem Ipsum",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
               "Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. " +
               "Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, " +
               "a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.",
                FearLevelId = 4,
                DifficultyId = 4,
                PlayersNumberId = 4
            });
            modelBuilder.Entity<QuestRoom>().HasData(new QuestRoom
            {
                Id = 4,
                Title = "QstRm4",
                Quest = "Lorem Ipsum",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
               "Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. " +
               "Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, " +
               "a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.",
                FearLevelId = 3,
                DifficultyId = 1,
                PlayersNumberId = 1
            });
            modelBuilder.Entity<QuestRoom>().HasData(new QuestRoom
            {
                Id = 5,
                Title = "QstRm5",
                Quest = "Lorem Ipsum",
                Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
               "Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. " +
               "Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, " +
               "a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.",
                FearLevelId = 2,
                DifficultyId = 4,
                PlayersNumberId = 5
            });
        }
    }
}
