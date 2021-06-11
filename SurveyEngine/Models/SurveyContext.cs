namespace SurveyEngine.Models
{
    using Microsoft.EntityFrameworkCore;
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public DbSet<Survey> TodoItems { get; set; }
    }
}