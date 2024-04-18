public static class AppServices
{
    public static IServiceProvider Instance { get; private set; }

    public static void Configure(IServiceProvider serviceProvider)
    {
        Instance = serviceProvider;
    }

    public static AppDbContext GetDbContext()
    {
        return Instance.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
    }
}