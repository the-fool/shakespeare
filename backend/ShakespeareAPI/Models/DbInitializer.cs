namespace ShakespeareAPI.Models {
    public static class DbInitializer {
        public static void Initialize(ApiDbContext context) {
            context.Database.EnsureCreated();
        }
    }
}