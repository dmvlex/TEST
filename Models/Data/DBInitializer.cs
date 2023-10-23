namespace TEST.Models.Data
{
    public static class DBInitializer
    {
        public static void Initializer(TestDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
