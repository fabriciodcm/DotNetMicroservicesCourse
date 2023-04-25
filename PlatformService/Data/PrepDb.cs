using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("Populando o banco.");
                context.Platforms.AddRange(
                    new Platform(){ Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new Platform(){ Name = "Java", Publisher = "Oracle", Cost = "Free" },
                    new Platform(){ Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform(){ Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Banco populado.");
            }
        }
    }
}