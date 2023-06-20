using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using soFine.Models;


namespace soFine
{
    public class SoFineDB : DbContext
    {
        public DbSet<UsersSkinProduct> UsersSkinProducts { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<UsersHairProduct> UsersHairProducts { get; set; }
        public DbSet<SkinAnswer> SkinAnswers { get; set; }

        public DbSet<HairAnswer> HairAnswers { get; set; }

        public SoFineDB()
        {
        }

        public DbSet<SkinProduct> SkinProducts { get; set; }

        public DbSet<HairProduct> HairProducts { get; set; }

        public DbSet<HairQuiz> HairQuizs { get; set; }

        public DbSet<SkinQuiz> SkinQuizs { get; set; }

        public DbSet<SpecialistAccount> SpecialistAccounts { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
